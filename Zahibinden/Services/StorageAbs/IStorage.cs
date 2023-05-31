
namespace Zahibinden.Services.StorageAbs
{
    public interface IStorage
    {
        Task<bool> UploadAsync(string path, IFormFileCollection files);

        void Delete(string path, string fileName);

        public List<string> GetSRC(string path);

        bool HasFile(string path, string fileName);
    }
}
