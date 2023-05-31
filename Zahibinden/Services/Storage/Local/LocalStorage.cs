using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
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

        public async Task<bool> CopyFileAsync(string path, IFormFileCollection files)
        {
            try
            {
                foreach (var file in files)
                {
                    string NewItemName = file.FileName;
                    var ImageType = NewItemName.Split('.').Reverse().ToArray()[0];
                    
                    int a = 1;

                    while (HasFile(path, NewItemName))
                    {
                        NewItemName = file.FileName.Replace($".{ImageType}", $"{a}.{ImageType}");
                        a++;
                    }

                    using FileStream fileStream = new($"{path}\\{NewItemName}", FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                    await file.CopyToAsync(fileStream);
                    await fileStream.FlushAsync();
                }

                return true;
            }
            catch
            {
                return false;

            }
        }

        public async Task<bool> UploadAsync(string path, IFormFileCollection files)
        {
            try
            {
                string pathv2 = Path.Combine("UserUploads", path);

                string upPath = Path.Combine(_webHostEnvironment.WebRootPath, pathv2);

                if (!Directory.Exists(upPath))
                    Directory.CreateDirectory(upPath);

                if (!await CopyFileAsync(upPath, files))
                    return false;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<string> GetSRC(string path)
        {
            List<string> srcs = new List<string>();
            string pathv2 = $"wwwroot/UserUploads/{path}";

            string[] files = Directory.GetFiles(pathv2);
            foreach (string file in files)
            {
                string src = $"/{file.Replace("wwwroot/", "").Replace("\\", "/")}";

                srcs.Add(src);
            }

            return srcs;
        }


        public bool HasFile(string path, string fileName)
        => File.Exists($"{path}\\{fileName}");

        public void Delete(string path, string fileName)
        => File.Delete($"{path}\\{fileName}");


    }
}
