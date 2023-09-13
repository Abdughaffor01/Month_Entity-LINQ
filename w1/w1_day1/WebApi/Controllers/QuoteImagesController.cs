using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi;

[ApiController]
[Route("[controller]")]
public class QuoteImagesController : ControllerBase
{
    private readonly IQuoteImageService _quoteImageService;
    public QuoteImagesController(IQuoteImageService quoteImageService) => _quoteImageService = quoteImageService;

    [HttpPost("AddImageByQuoteIdAsync")]
    public async Task<Response<string>> AddImageByQuoteIdAsync(int quoteId, IFormFile file) => await _quoteImageService.AddImageByQuoteIdAsync(quoteId, file);

    [HttpDelete("DeleteImageByQuoteIdAsync")]
    public async Task<Response<string>> DeleteImageByQuoteIdAsync(int quoteId) => await _quoteImageService.DeleteImageByQuoteIdAsync(quoteId);
}

