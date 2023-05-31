using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Zahibinden.Business.Abstract;
using Zahibinden.Data.Entities;
using Zahibinden.Models.ViewModels;

namespace Zahibinden.Controllers
{
    [Authorize]
    public class AdvertController : Controller
    {
        private readonly IAdvertService _advertService;
        private readonly UserManager<User> _userManager;

        public AdvertController(IAdvertService advertService, UserManager<User> userManager)
        {
            _advertService = advertService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            VM_CreateAdvert advert = new VM_CreateAdvert();
            advert.Title = "ssadasfa";
            _advertService.AddAdvert(advert);
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VM_CreateAdvert advert)
        {
            _advertService.AddAdvert(advert);
            return View();
        }

        public IActionResult Update(int advertId)
        {
            Advert advert = _advertService.GetAdvertById(advertId);
            return View(advert);
        }

        [HttpPost]
        public IActionResult Update(VM_UpdateAdvert advert)
        {
            _advertService.UpdateAdvert(advert);
            return View();
        }

        public IActionResult Delete(int advertId)
        {
            _advertService.DeleteAdvert(advertId);
            return View();
        }
    }
}
