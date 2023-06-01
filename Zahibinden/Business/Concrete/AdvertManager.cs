using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Zahibinden.Business.Abstract;
using Zahibinden.Data.Entities;
using Zahibinden.DataAccess.Abstract;
using Zahibinden.DataAccess.Concrete;
using Zahibinden.Models.ViewModels;

namespace Zahibinden.Business.Concrete
{
    public class AdvertManager : IAdvertService
    {
        private readonly IAdvertDal _advertDal;
        private readonly ICategoryDal _categoryDal;
        private readonly ICityDal _cityDal;
        private readonly IAdvertTypeDal _advertTypeDal;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdvertManager(IAdvertDal advertDal, IMapper mapper, IHttpContextAccessor httpContextAccessor, ICategoryDal categoryDal, ICityDal cityDal, IAdvertTypeDal advertTypeDal, UserManager<User> userManager)
        {
            _advertDal = advertDal;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _categoryDal = categoryDal;
            _cityDal = cityDal;
            _advertTypeDal = advertTypeDal;
        }

        public bool AddAdvert(VM_CreateAdvert advert)
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //Guid guidUserId = Guid.Parse(userId);
            int intUserId = int.Parse(userId);

            User user = _userManager.Users.FirstOrDefault(x => x.Id == intUserId);

            Advert add = _mapper.Map<Advert>(advert);
            //add.Category = _categoryDal.GetById(advert.CategoryId);
            //add.City = _cityDal.GetById(advert.CityId);
            //add.Type = _advertTypeDal.GetById(advert.TypeId);
            add.User = _mapper.Map<User>(user);

            _advertDal.Create(add);
            return true;
        }

        public bool DeleteAdvert(int advertId)
        {
            _advertDal.Delete(advertId);
            return true;
        }

        public Advert GetAdvertById(int advertId)
        {
            return _advertDal.GetById(advertId);
        }

        public List<Advert> GetAdvertsByUserId(int userId)
        {
            return _advertDal.GetAdvertsByUserId(userId);
        }

        public List<Advert> GetAllAdverts()
        {
            return _advertDal.GetAll();
        }

        public bool UpdateAdvert(VM_UpdateAdvert advert)
        {
            Advert add = _mapper.Map<Advert>(advert);
            // user islemleri
            _advertDal.Update(add);
            return true;
        }
    }
}
