using Zahibinden.Business.Abstract;
using Zahibinden.Business.Concrete;
using Zahibinden.DataAccess.Abstract;
using Zahibinden.DataAccess.Concrete;
using Zahibinden.Services.StorageAbs;

namespace Zahibinden.Services
{

    public static class ServiceRegistations
    {
        public static void AddStorage<T>(this IServiceCollection services) where T : class, IStorage
        {
            services.AddScoped<IStorage, T>();
        }

        public static void AddRegister(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program));

            services.AddScoped<IAdvertDal, AdvertDal>();
            services.AddScoped<ICategoryDal, CategoryDal>();
            services.AddScoped<ICityDal, CityDal>();
            services.AddScoped<IAdvertTypeDal, AdvertTypeDal>();

            services.AddScoped<IAdvertService, AdvertManager>();
            //services.AddScoped<ICategoryService, CategoryManager>();
            //services.AddScoped<ICityService, CityManager>();
            //services.AddScoped<IAdvertTypeService, AdvertTypeManager>();
        }
    }

}