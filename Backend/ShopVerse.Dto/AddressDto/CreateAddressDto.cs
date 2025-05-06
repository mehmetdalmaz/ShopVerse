using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopVerse.Dto.AddressDto
{
    public class CreateAddressDto
    {
        public string Title { get; set; } 
        public string Street { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string PostalCode { get; set; }
        public Guid AppUserId { get; set; }
    }
}