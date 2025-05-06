using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ShopVerse.Dto.CartDto;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.Api.Mapping
{
    public class CartMapping : Profile
    {
        public CartMapping()
        {
            CreateMap<Cart, CreateCartDto>().ReverseMap();
            CreateMap<Cart, ResultCartDto>().ReverseMap();
            CreateMap<Cart, UpdateCartDto>().ReverseMap();
        }
    }
}