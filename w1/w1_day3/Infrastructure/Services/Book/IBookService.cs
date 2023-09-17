using Domain;

namespace Infrastructure;
public interface IBookService
{
    Task<Response<string>> AddBookAsync(AddBookDto book);
    Task<Response<string>> UpdateBookAsync(UpdateBookDto book);
    Task<Response<string>> DeleteBookAsync(int id);
    Task<Response<GetBookDto>> GetBookByIdAsync(int id);
    Task<Response<List<Book>>> GetBooksAsync();
}
