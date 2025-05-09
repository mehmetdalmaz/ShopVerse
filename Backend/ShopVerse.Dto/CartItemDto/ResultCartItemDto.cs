using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopVerse.Dto.CartItemDto
{
    public class ResultCartItemDto
    {
        public Guid Id { get; set; }

        public Guid CartId { get; set; }

        public Guid ProductId { get; set; }
        public string ProductName { get; set; } 
        public decimal Price { get; set; }


        public int Quantity { get; set; }
    }
}