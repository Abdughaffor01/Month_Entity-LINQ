using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi;

[ApiController]
[Route("[controller]")]
public class QuoteController:ControllerBase
{
    private readonly IQuoteService _quoteService;
    public QuoteController(IQuoteService quoteService)=>_quoteService = quoteService;

    [HttpPost("AddQuoteAsync")]
    public async Task<Response<string>> AddQuoteAsync([FromForm]AddQuoteDto addQuoteDto)=>await _quoteService.AddQuoteAsync(addQuoteDto);

    [HttpDelete("DeleteQuoteAsync")]
    public async Task<Response<string>> DeleteQuoteAsync(int quoteId)=>await _quoteService.DeleteQuoteAsync(quoteId);

    [HttpPut("UpdateQuoteAsync")]
    public async Task<Response<string>> UpdateQuoteAsync(UpdateQuoteDto updateQuoteDto)=>await _quoteService.UpdateQuoteAsync(updateQuoteDto);

    [HttpGet("GetQuoteByIdAsync")]
    public async Task<Response<GetQuoteDto>> GetQuoteByIdAsync(int quoteId)=>await _quoteService.GetQuoteByIdAsync(quoteId);

    [HttpGet("GetQuotesAsync")]
    public async Task<Response<GetQuotesDto>> GetQuotesAsync()=>await _quoteService.GetQuotesAsync();

}
