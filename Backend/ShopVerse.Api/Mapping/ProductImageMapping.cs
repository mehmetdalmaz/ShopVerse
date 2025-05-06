using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ShopVerse.Dto.ProductImageDto;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.Api.Mapping.AuthMapping
{
    public class ProductImageMapping : Profile
    {
        public ProductImageMapping()
        {
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UPdateProductImageDto>().ReverseMap();
        }
    }
}