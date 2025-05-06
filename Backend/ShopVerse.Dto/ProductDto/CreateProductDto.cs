using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopVerse.Dto.CartItemDto;
using ShopVerse.Dto.ProductImageDto;
using ShopVerse.Dto.ProductReviewDto;

namespace ShopVerse.Dto.ProductDto
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Guid CategoryId { get; set; }

    }
}