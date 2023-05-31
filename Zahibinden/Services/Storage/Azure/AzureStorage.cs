
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using Zahibinden.Services.StorageAbs;
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

        public async Task<bool> UploadAsync(string path, IFormFile file)
        {
            try
            {
                _blobContainerClient = _blobServiceClient.GetBlobContainerClient(path);
                await _blobContainerClient.CreateIfNotExistsAsync();
                await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

                BlobClient blobClient = _blobContainerClient.GetBlobClient(file.FileName);

                BlobUploadOptions options = new BlobUploadOptions
                {
                    HttpHeaders = new BlobHttpHeaders { ContentType = "image/png" }
                };

                await blobClient.UploadAsync(file.OpenReadStream(), options);
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

        public string GetSRC(string path, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(path);
            var b = _blobContainerClient.GetBlobs().Select(b => b.Name).ToList();
            string a = $"https://zahibinden.blob.core.windows.net/{path}/{b[0]}";
            return a;
        }

        public bool HasFile(string path, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(path);
            return _blobContainerClient.GetBlobs().Any(b => b.Name == fileName);
        }

      
    }
}
