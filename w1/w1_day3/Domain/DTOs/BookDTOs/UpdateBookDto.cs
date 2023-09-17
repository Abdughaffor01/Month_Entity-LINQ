using Microsoft.AspNetCore.Http;

namespace Domain;
public class UpdateBookDto : BaseBookDto
{
    public int Id { get; set; }
    public IFormFile file { get; set; }
}
