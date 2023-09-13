using Microsoft.AspNetCore.Http;

namespace Domain.DTOs;
public class AddQuoteDto : QuoteDto
{
    public List<IFormFile> MyProperty { get; set; }
}
