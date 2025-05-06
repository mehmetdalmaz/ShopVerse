using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ShopVerse.Dto.LoginDto;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.Api.Mapping.AuthMapping
{
    public class LoginMapping: Profile
    {
        public LoginMapping()
        {
            CreateMap<AppUser, LoginDto>().ReverseMap();
        }
    }
}