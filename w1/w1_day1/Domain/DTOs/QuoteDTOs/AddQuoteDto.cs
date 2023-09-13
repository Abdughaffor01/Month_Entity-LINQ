using Microsoft.AspNetCore.Http;
namespace Domain;
public class AddQuoteDto:BaseQuoteDto
{
    public IFormFile? File { get; set; }
}
