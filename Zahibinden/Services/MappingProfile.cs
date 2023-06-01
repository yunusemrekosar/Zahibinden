using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Zahibinden.Data.Entities;
using Zahibinden.Models.ViewModels;

namespace Zahibinden.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VM_CreateAdvert, Advert>();
            CreateMap<Advert, VM_CreateAdvert>();

            CreateMap<VM_UpdateAdvert, Advert>();
            CreateMap<Advert, VM_UpdateAdvert>();

            CreateMap<User, IdentityUser>();
            CreateMap<IdentityUser, User>();
        }
    }
}
