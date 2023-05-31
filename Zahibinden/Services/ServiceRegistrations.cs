using Zahibinden.Services.StorageAbs;

namespace Zahibinden.Services
{

    public static class ServiceRegistations
        { 
            public static void AddStorage<T>(this IServiceCollection services) where T : class, IStorage
            {
                services.AddScoped<IStorage, T>();
            }
        }
    
}
