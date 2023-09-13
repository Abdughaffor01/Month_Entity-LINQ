using Dapper;
using Domain;
using Infrastructure.Context;
using Infrastructure.Services.FileService;
using Microsoft.AspNetCore.Http;

namespace Infrastructure;
public class QuoteImageService : IQuoteImageService
{
    private readonly DataContext _dataContext;
    private readonly IFileService _fileService;
    public QuoteImageService(DataContext dataContext, IFileService fileService)
    {
        _dataContext = dataContext;
        _fileService = fileService;
    }
    public async Task<Response<string>> AddImageByQuoteIdAsync(int quoteId, IFormFile file)
    {
        try
        {
            using var con = _dataContext.CreateConnection();
            string nameimages = await _fileService.AddFileAsync(file, "images");
            var foundquote = await con.QueryFirstOrDefaultAsync<int>($"select quote_id from quote_image where quote_id={quoteId}");
            if (foundquote == 0) return new Response<string>("not found");
            var res = await con.ExecuteAsync($"insert into quote_image(quote_id,image_name)values({quoteId},'{nameimages}')");
            return new Response<string>("Successfuly added image");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }

    public async Task<Response<string>> DeleteImageByQuoteIdAsync(int quoteId)
    {
        try
        {
            using var con=_dataContext.CreateConnection();
            var foundquote = await con.QueryFirstOrDefaultAsync<int>($"select quote_id from quote_image where quote_id={quoteId}");
            if (foundquote == 0) return new Response<string>("not found");
            var images = await con.QueryAsync<string>($"select image_name from quote_image where quote_id={quoteId}");
            foreach (var image in images) _fileService.DeleteFile(image,"images");
            var res = await con.ExecuteAsync($"delete from quote_image where quote_id={quoteId}");
            return new Response<string>("Successfuly deleted images");

        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }
}
