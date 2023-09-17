using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Infrastructure;
public class FileService : IFileService
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    public FileService(IWebHostEnvironment webHostEnvironment) => _webHostEnvironment = webHostEnvironment;
    public async Task<string> AddFileAsync(IFormFile file, string folder)
    {
        try
        {
            string namefolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
            if (Directory.Exists(namefolder) == false) Directory.CreateDirectory(namefolder);
            string namefile = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string fullpath = Path.Combine(namefolder, namefile);
            var stream = new FileStream(fullpath, FileMode.OpenOrCreate);
            await file.CopyToAsync(stream);
            return namefile;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    public async Task<bool> DeleteFile(string filename, string folder)
    {
        try
        {
            return await Task.Run(() =>
            {
                string fullpath = Path.Combine(_webHostEnvironment.WebRootPath, folder, filename);
                File.Delete(fullpath);
                return true;
            });
        }
        catch (Exception)
        {
            return false;
        }
    }
}
