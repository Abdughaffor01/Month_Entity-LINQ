using Microsoft.AspNetCore.Http;

namespace Infrastructure;
public interface IFileService
{
    Task<string> AddFileAsync(IFormFile file, string folder);
    Task<bool> DeleteFile(string filename, string folder);
}
