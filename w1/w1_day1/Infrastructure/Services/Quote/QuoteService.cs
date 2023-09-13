using Dapper;
using Domain;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Services.FileService;

namespace Infrastructure;
public class QuoteService : IQuoteService
{
    private readonly DataContext _dataContext;
    private readonly IFileService _fileService;

    public QuoteService(DataContext dataContext, IFileService fileService)
    {
        _dataContext = dataContext;
        _fileService = fileService;
    }
    public async Task<Response<string>> AddQuoteAsync(AddQuoteDto addQuoteDto)
    {
        try
        {
            using var con=_dataContext.CreateConnection();
            string sql = @"insert into quotes(quote_text,category_id) values (@QuoteText,@CategoryId)";
            if (addQuoteDto.File == null) {
                var res = await con.ExecuteAsync(sql+";",addQuoteDto);
                if (res == 0) return new Response<string>("500");
                return new Response<string>("Successfuly added quote");
            }
            var resp=await con.ExecuteScalarAsync<int>(sql+"returning id",addQuoteDto);
            string filename = await _fileService.AddFileAsync(addQuoteDto.File, "images");
            if (filename != null && resp!=0) {
                var res = await con.ExecuteAsync($"insert into quote_image(quote_id,image_name)values({resp},'{filename}')");
                return new Response<string>("Successfuly added quote with image");
            }
            return new Response<string>("error");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }
    public async Task<Response<string>> DeleteQuoteAsync(int quoteId)
    {
        try
        {
            using var con = _dataContext.CreateConnection();
            var images = await con.QueryAsync<string>($"select image_name from quote_image where quote_id={quoteId}");
            if (images != null) {
                foreach (var image in images)  _fileService.DeleteFile(image,"images");
                var res = await con.ExecuteAsync($"delete from quote_image where quote_id={quoteId}");
                var res1 = await con.ExecuteAsync($"delete from quotes where id={quoteId}");
                if (res != 0 && res1 != 0) return new Response<string>("Successfuly deleted quotes with images");
                return new Response<string>("not found");
            }
            var resp = await con.ExecuteAsync($"delete from quotes where id={quoteId}");
            if (resp != 0) return new Response<string>("Successfuly deleted quote");
            return new Response<string>("not found");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }
    public async Task<Response<GetQuoteDto>> GetQuoteByIdAsync(int quoteId)
    {
        try
        {
            using var con=_dataContext.CreateConnection();
            var res = await con.QueryFirstOrDefaultAsync<GetQuoteDto>($"select id as Id ,quote_text as QuoteText,category_id as CategoryId from quotes where id={quoteId};");
            if (res == null)return new Response<GetQuoteDto>("not found");
            var images = await con.QueryAsync<string>($"select image_name from quote_image where quote_id={quoteId}");
            if(images!=null) res.Images=images.ToList();
            if (res != null) return new Response<GetQuoteDto>("Successfuly founded quote",res);
            return new Response<GetQuoteDto>("500");
        }
        catch (Exception ex)
        {
            return new Response<GetQuoteDto>(ex.Message);
        }
    }
    public async Task<Response<GetQuotesDto>> GetQuotesAsync()
    {
        try
        {
            using var con = _dataContext.CreateConnection();
            GetQuotesDto getQuotesDto = new GetQuotesDto();
            getQuotesDto.Images =( await con.QueryAsync<QuoteIdByImagesDto>($"select quote_id as QuoteId, image_name as NameImage from quote_image")).ToList();
            getQuotesDto.Quotes= (await con.QueryAsync<GetQuoteDto>($"select id as Id ,quote_text as QuoteText,category_id as CategoryId from quotes w;")).ToList();
            if (getQuotesDto.Quotes != null) return new Response<GetQuotesDto>("Successfuly founded quote", getQuotesDto);
            return new Response<GetQuotesDto>("500");
        }
        catch (Exception ex)
        {
            return new Response<GetQuotesDto>(ex.Message);
        }
    }
    public async Task<Response<string>> UpdateQuoteAsync(UpdateQuoteDto updateQuoteDto)
    {
        try
        {
            using var con=_dataContext.CreateConnection();
            string sql = @"update quotes set quote_text=@QuoteText,category_id=@CategoryId where id=@Id;";
            var res = await con.ExecuteAsync(sql, updateQuoteDto);
            if (res != 0) return new Response<string>("Successfuly updated quote");
            return new Response<string>("not found");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }
}
