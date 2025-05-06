using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ShopVerse.Dto.RegisterDto;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.Api.Mapping.AuthMapping
{
   public class RegisterMapping: Profile
    {
        public RegisterMapping()
        {
            CreateMap<AppUser, RegisterDto>().ReverseMap();
        }
    }
}