using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ShopVerse.Dto.AddressDto;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.Api.Mapping
{
    public class AddressMapping : Profile
    {
        public AddressMapping()
        {
            CreateMap<Address, CreateAddressDto>().ReverseMap();
            CreateMap<AppUser, ResultAddressDto>().ReverseMap();
            CreateMap<Address, UpdateAddressDto>().ReverseMap();
        }
    }
}