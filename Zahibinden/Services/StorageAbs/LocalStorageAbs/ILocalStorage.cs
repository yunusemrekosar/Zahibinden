using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zahibinden.Services.StorageAbs.LocalStorageAbs
{
    public interface ILocalStorage : IStorage
    {
        Task<bool> CopyFileAsync(string path, IFormFileCollection file);
    }
}
