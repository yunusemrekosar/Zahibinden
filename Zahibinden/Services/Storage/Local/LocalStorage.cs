using Zahibinden.Services.StorageAbs.LocalStorageAbs;

namespace WebSite.Infrastructure.Services.Storage.Local
{
    public class LocalStorage : ILocalStorage
    {
        readonly IWebHostEnvironment _webHostEnvironment;

        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch
            {
                return false;

            }
        }

        public async Task<bool> UploadAsync(string path, IFormFile file)
        {
            try
            {
                string pathv2 = Path.Combine("UserUploads", path);

                string upPath = Path.Combine(_webHostEnvironment.WebRootPath, pathv2);

                if (!Directory.Exists(upPath))
                    Directory.CreateDirectory(upPath);

                if(!await CopyFileAsync($"{upPath}\\{file.FileName}", file))
                    return false;

                return true;
            }
            catch 
            {
                return false;
            }
        }

        public string GetSRC(string path, string fileName)
        {
            string pathv2 = $"UserUploads/{path}";
            return $"/{pathv2}/{fileName}";
        }

        public bool HasFile(string path, string fileName)
        => File.Exists($"{path}\\{fileName}");

        public void Delete(string path, string fileName)
        => File.Delete($"{path}\\{fileName}");

      
    }
}
