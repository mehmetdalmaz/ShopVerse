using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopVerse.Dto.OrderDto
{
    public class CreateOrderDto
    {
        public Guid AppUserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Guid AddressId { get; set; }
    }
}