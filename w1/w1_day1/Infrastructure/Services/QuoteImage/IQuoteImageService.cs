using Domain;
using Microsoft.AspNetCore.Http;

namespace Infrastructure;
public interface IQuoteImageService
{
    Task<Response<string>> AddImageByQuoteIdAsync(int quoteId, IFormFile file);
    Task<Response<string>> DeleteImageByQuoteIdAsync(int quoteId);
}
