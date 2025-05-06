using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopVerse.Dto.AddressDto
{
    public class ResultAddressDto
    {
    public Guid Id { get; set; }
    public string Title { get; set; } // Ev, iş, vs.
    public string Street { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string PostalCode { get; set; }

    public Guid AppUserId { get; set; }
    }
}