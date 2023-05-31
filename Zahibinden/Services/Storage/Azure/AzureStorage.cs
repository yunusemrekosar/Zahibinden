using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.Data;
using Zahibinden.Services.StorageAbs.AzureAbs;

namespace Zahibinden.Services.Storage.Azure
{
    public class AzureStorage : IAzureStorage
    {
        readonly BlobServiceClient _blobServiceClient;
        BlobContainerClient _blobContainerClient;
        public AzureStorage(IConfiguration configuration)
        {
            _blobServiceClient = new(configuration["Storage:Azure"]);
        }

        public async Task<bool> UploadAsync(string path, IFormFileCollection files)
        {
            try
            {
                _blobContainerClient = _blobServiceClient.GetBlobContainerClient(path);
                await _blobContainerClient.CreateIfNotExistsAsync();
                await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

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

                    BlobClient blobClient = _blobContainerClient.GetBlobClient(NewItemName);
                    BlobUploadOptions options = new BlobUploadOptions
                    {
                        HttpHeaders = new BlobHttpHeaders { ContentType = $"image/{ImageType}" }
                        //todo: burada tip kontrolü yap
                    };
           
                    await blobClient.UploadAsync(file.OpenReadStream(), options);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async void Delete(string path, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(path);
            BlobClient blobClient = _blobContainerClient.GetBlobClient(fileName);
            await blobClient.DeleteAsync();
        }

        public List<string> GetSRC(string path)
        {
            
            List<string> srcs = new();
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(path);
            var b = _blobContainerClient.GetBlobs().Select(b => b.Name).ToList();
            foreach (var item in b)
            {
                string a = $"https://zahibinden.blob.core.windows.net/{path}/{item}";
                srcs.Add(a);
            }
            return srcs;
        }

        public bool HasFile(string path, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(path);
            return _blobContainerClient.GetBlobs().Any(b => b.Name == fileName);
        }
    }
}
