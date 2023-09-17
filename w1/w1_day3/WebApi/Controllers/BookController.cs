using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    public BookController(IBookService bookService) => _bookService = bookService;

    [HttpPost("AddBookAsync")]
    public async Task<Response<string>> AddBookAsync([FromForm] AddBookDto book) => await _bookService.AddBookAsync(book);

    [HttpDelete("DeleteBookAsync")]
    public async Task<Response<string>> DeleteBookAsync(int id) => await _bookService.DeleteBookAsync(id);

    [HttpPut("UpdateBookAsync")]
    public async Task<Response<string>> UpdateBookAsync([FromForm]UpdateBookDto book)=>await _bookService.UpdateBookAsync(book);

    [HttpGet("GetBookByIdAsync")]
    public async Task<Response<GetBookDto>> GetBookByIdAsync(int id) => await _bookService.GetBookByIdAsync(id);

    [HttpGet("GetBooksAsync")]
    public async Task<Response<List<Book>>> GetBooksAsync() => await _bookService.GetBooksAsync(); 
}
