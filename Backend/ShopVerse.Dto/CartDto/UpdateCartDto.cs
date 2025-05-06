using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopVerse.Dto.CartDto
{
    public class UpdateCartDto
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }

    }
}