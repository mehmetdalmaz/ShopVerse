using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ShopVerse.Dto.ProductReviewDto;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.Api.Mapping
{
    public class ProductReviewMapping : Profile
    {
        public ProductReviewMapping()
        {
            CreateMap<ProductReview, CreateProductReviewDto>().ReverseMap();
            CreateMap<ProductReview, ResultProductReviewDto>().ReverseMap();
            CreateMap<ProductReview, UpdateProductReviewDto>().ReverseMap();
        }
    }
}