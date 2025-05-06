using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopVerse.Dto.CartItemDto;

namespace ShopVerse.Dto.CartDto
{
    public class ResultCartDto
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }

        public List<ResultCartItemDto> CartItems { get; set; } = new();

    }
}