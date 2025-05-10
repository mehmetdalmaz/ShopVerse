using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ShopVerse.Dto.OrderDto;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.Api.Mapping
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, ResultOrderDto>()
                .ForMember(dest => dest.AddressDto, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
               
        }
    }
}