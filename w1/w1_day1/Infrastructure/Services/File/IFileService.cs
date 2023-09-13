using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services.FileService;
public interface IFileService
{
    Task<string> AddFileAsync(IFormFile file, string folder);
    bool DeleteFile(string filename, string folder);
}
