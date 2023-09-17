using Microsoft.AspNetCore.Http;

namespace Domain;
public class AddBookDto : BaseBookDto
{
    public IFormFile? File { get; set; }
}
