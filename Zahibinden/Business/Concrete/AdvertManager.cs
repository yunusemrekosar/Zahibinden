using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using Zahibinden.Business.Abstract;
using Zahibinden.Data;
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
        private readonly ApplicationDbContext _context;

        public AdvertManager(IAdvertDal advertDal, IMapper mapper, IHttpContextAccessor httpContextAccessor, ICategoryDal categoryDal, ICityDal cityDal, IAdvertTypeDal advertTypeDal, UserManager<User> userManager, ApplicationDbContext context)
        {
            _advertDal = advertDal;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _categoryDal = categoryDal;
            _cityDal = cityDal;
            _advertTypeDal = advertTypeDal;
            _context = context;
        }

        public bool AddAdvert(VM_CreateAdvert advert)
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            int intUserId = int.Parse(userId);

            User user = _userManager.Users.FirstOrDefault(x => x.Id == intUserId);

            Advert add = _mapper.Map<Advert>(advert);
            add.Category = _categoryDal.GetById(advert.CategoryId);
            add.City = _cityDal.GetById(advert.CityId);
            add.Type = _advertTypeDal.GetById(advert.TypeId);
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

        public List<VM_ShowAdvert> GetAdvertsByUserIdShow(int userId)
        {
            List<Advert> list = GetAdvertsByUserId(userId);

            return AdvertToVmAdvertShow(list);
        }

        public List<Advert> GetAllAdverts()
        {
            return _advertDal.GetAll();
        }

        public List<VM_ShowAdvert> GetAllAdvertsShow()
        {
            List<Advert> list = GetAllAdverts();

            return AdvertToVmAdvertShow(list);
        }

        public List<VM_ShowAdvert> AdvertToVmAdvertShow(List<Advert> list)
        {
            List<VM_ShowAdvert> adverts = new List<VM_ShowAdvert>();
            foreach (var item in list)
            {
                VM_ShowAdvert advert = _mapper.Map<VM_ShowAdvert>(item);
                advert.CategoryName = _categoryDal.GetById(advert.CategoryId).Title;
                advert.CityName = _cityDal.GetById(advert.CityId).Name;
                advert.TypeName = _advertTypeDal.GetById(advert.TypeId).Title;
                //advert.UserName = _context.Users.FirstOrDefault(x => x.Id == advert.UserId).UserName;
                adverts.Add(advert);
            }
            return adverts;
        }

        public VM_ShowAdvert AdvertToVmAdvertShow(Advert advert)
        {
            VM_ShowAdvert VMadvert = _mapper.Map<VM_ShowAdvert>(advert);
            VMadvert.CategoryName = _categoryDal.GetById(advert.CategoryId).Title;
            VMadvert.CityName = _cityDal.GetById(advert.CityId).Name;
            VMadvert.TypeName = _advertTypeDal.GetById(advert.TypeId).Title;
            //advert.UserName = _context.Users.FirstOrDefault(x => x.Id == advert.UserId).UserName;
            return VMadvert;
        }

        public bool UpdateAdvert(VM_UpdateAdvert advert)
        {
            Advert add = _mapper.Map<Advert>(advert);
            // user islemleri
            _advertDal.Update(add);
            return true;
        }

        public VM_ShowAdvert GetAdvertByIdShow(int advertId)
        {
            return AdvertToVmAdvertShow(GetAdvertById(advertId)); 
        }

        public VM_UpdateAdvert GetAdvertByIdUpdate(int advertId)
        {
            Advert advert = GetAdvertById(advertId);
            VM_UpdateAdvert update = _mapper.Map<VM_UpdateAdvert>(advert);

            return update;
        }
    }
}
