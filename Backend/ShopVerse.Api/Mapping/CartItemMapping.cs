using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ShopVerse.Dto.CartItemDto;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.Api.Mapping
{
    public class CartItemMapping : Profile
    {
        public CartItemMapping()
        {
            CreateMap<CartItem, ResultCartItemDto>().ReverseMap();

        }
    }
}