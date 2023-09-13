using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
namespace Infrastructure.Services.FileService;
public class FileService : IFileService
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    public FileService(IWebHostEnvironment webHostEnvironment) => _webHostEnvironment = webHostEnvironment;
    public async Task<string> AddFileAsync(IFormFile file, string folder)
    {
        try
        {
            string foldername=Path.Combine(_webHostEnvironment.WebRootPath,folder);
            if (File.Exists(foldername)==false) Directory.CreateDirectory(foldername);
            string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string fullpath = Path.Combine(_webHostEnvironment.WebRootPath, folder, filename);
            using var stream = new FileStream(fullpath, FileMode.OpenOrCreate);
            await file.CopyToAsync(stream);
            return filename;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    public bool DeleteFile(string filename, string folder)
    {
        try
        {
            string fullpath = Path.Combine(_webHostEnvironment.WebRootPath, folder, filename);
            if (File.Exists(fullpath))
            {
                File.Delete(fullpath);
                return true;
            }
            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
