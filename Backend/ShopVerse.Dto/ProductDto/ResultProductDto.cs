using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopVerse.Dto.CartItemDto;
using ShopVerse.Dto.ProductImageDto;
using ShopVerse.Dto.ProductReviewDto;

namespace ShopVerse.Dto.ProductDto
{
    public class ResultProductDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Guid CategoryId { get; set; }

        public ICollection<ResultProductImageDto> Images { get; set; }
        public ICollection<ResultProductReviewDto> Reviews { get; set; }
        public ICollection<ResultCartItemDto> CartItems { get; set; }
    }
}