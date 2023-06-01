using Zahibinden.Data.Entities;
using Zahibinden.Models.ViewModels;

namespace Zahibinden.Business.Abstract
{
    public interface IAdvertService
    {
        bool AddAdvert(VM_CreateAdvert advert);
        bool UpdateAdvert(VM_UpdateAdvert advert);
        bool DeleteAdvert(int advertId);
        Advert GetAdvertById(int advertId);
        List<Advert> GetAllAdverts();
        List<Advert> GetAdvertsByUserId(int userId);
    }
}
