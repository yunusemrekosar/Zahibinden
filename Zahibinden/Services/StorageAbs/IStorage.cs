
namespace Zahibinden.Services.StorageAbs
{
    public interface IStorage
    {
        Task<bool> UploadAsync(string path, IFormFile file);

        void Delete(string path, string fileName);

        public string GetSRC(string path, string fileName);

        bool HasFile(string path, string fileName);
    }
}
