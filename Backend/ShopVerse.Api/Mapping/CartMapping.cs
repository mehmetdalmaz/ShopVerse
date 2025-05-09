using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ShopVerse.Dto.CartDto;
using ShopVerse.Dto.CartItemDto;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.Api.Mapping
{
    public class CartMapping : Profile
    {
        public CartMapping()
        {
            CreateMap<Cart, CreateCartDto>().ReverseMap();
            CreateMap<Cart, UpdateCartDto>().ReverseMap();
            CreateMap<Cart, ResultCartDto>()
                .ForMember(dest => dest.TotalPrice,
                    opt => opt.MapFrom(src => src.CartItems.Sum(ci => ci.Quantity * (ci.Product == null ? 0 : ci.Product.Price))))
                .ForMember(dest => dest.CartItems, opt => opt.MapFrom(src => src.CartItems));

            CreateMap<CartItem, ResultCartItemDto>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product == null ? null : src.Product.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product == null ? 0 : src.Product.Price))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));
        }
    }
}