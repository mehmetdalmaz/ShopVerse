using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ShopVerse.Dto.OrderItemDto;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.Api.Mapping
{
    public class OrderItemMapping : Profile
    {
        public OrderItemMapping()
        {
            
            CreateMap<OrderItem, ResultOrderItemDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product!.Name)).ReverseMap();
                

              
        }
    }
}