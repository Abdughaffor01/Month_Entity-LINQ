using Domain;
namespace Infrastructure;
public interface IQuoteService
{
    Task<Response<string>> AddQuoteAsync(AddQuoteDto addQuoteDto);
    Task<Response<string>> UpdateQuoteAsync(UpdateQuoteDto updateQuoteDto);
    Task<Response<string>> DeleteQuoteAsync(int quoteId);
    Task<Response<GetQuotesDto>> GetQuotesAsync();
    Task<Response<GetQuoteDto>> GetQuoteByIdAsync(int quoteId);
}
