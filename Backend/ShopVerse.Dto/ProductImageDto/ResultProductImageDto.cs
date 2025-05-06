using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopVerse.Dto.ProductImageDto
{
    public class ResultProductImageDto
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }

        public Guid ProductId { get; set; }
    }
}