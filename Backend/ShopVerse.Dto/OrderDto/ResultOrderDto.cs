using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopVerse.Dto.OrderItemDto;

namespace ShopVerse.Dto.OrderDto
{
    public class ResultOrderDto
    {
        public Guid Id { get; set; }
        public Guid AppUserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<ResultOrderItemDto> Items { get; set; }
        public Guid AddressId { get; set; }
    }
}