using Domain;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;
public class BookService : IBookService
{
    private readonly DataContext _dataContext;
    private readonly IFileService _fileService;
    public BookService(DataContext dataContext,IFileService fileService) {
        _dataContext = dataContext;
        _fileService= fileService;
    }
    public async Task<Response<string>> AddBookAsync(AddBookDto book)
    {
        try
        {
            string filename = string.Empty;
            if (book.File != null) filename = await _fileService.AddFileAsync(book.File, Folder.images);
            var model = new Book()
            {
                Title = book.Title,
                Author = book.Author,
                FileName = filename
            };
            await _dataContext.Books.AddAsync(model);
            var res = await _dataContext.SaveChangesAsync();
            return res == 0 ? new Response<string>("") : new Response<string>("Successfuly added Book");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }

    public async Task<Response<string>> DeleteBookAsync(int id)
    {
        try
        {
            return await Task.Run(async () =>
            {
                var find = await _dataContext.Books.FindAsync(id);
                if (find == null) return new Response<string>("not found");
                if (find.FileName != null) await _fileService.DeleteFileAsync(find.FileName, Folder.images);
                _dataContext.Books.Remove(find);
                var res = await _dataContext.SaveChangesAsync();
                return new Response<string>("Successfuly deleted book");
            });
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }

    public async Task<Response<string>> UpdateBookAsync(UpdateBookDto book)
    {
        try
        {
            var fine=await _dataContext.Books.FindAsync(book.Id);
            if (fine == null) return new Response<string>("not found");
            if (book.file != null)
            {
                if(fine.FileName!=null)await _fileService.DeleteFileAsync(fine.FileName, Folder.images);
                fine.FileName = await _fileService.AddFileAsync(book.file, Folder.images);
            }
            fine.Title = book.Title;
            fine.Author = book.Author;
            
            await _dataContext.SaveChangesAsync();
            return new Response<string>("Successfuly updated book");
        }
        catch (Exception ex)
        {
            return new Response<string>(ex.Message);
        }
    }

    public async Task<Response<GetBookDto>> GetBookByIdAsync(int id)
    {
        try
        {
            var res =await _dataContext.Books.FindAsync(id);
            if (res == null) return new Response<GetBookDto>("not found");
            var response = new GetBookDto
            {
                Id = res.Id,
                Title = res.Title,
                Author=res.Author,
                FileName=res.FileName
            };
            return new Response<GetBookDto>(response);
        }
        catch (Exception ex)
        {
            return new Response<GetBookDto>(ex.Message);
        }
    }

    public async Task<Response<List<Book>>> GetBooksAsync()
    {
        try
        {
            return new Response<List<Book>>(await _dataContext.Books.ToListAsync());
        }
        catch (Exception ex)
        {
            return new Response<List<Book>>(ex.Message);
        }
    } 
}
