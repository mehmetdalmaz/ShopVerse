using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopVerse.Dto.ProductReviewDto
{
    public class UpdateProductReviewDto
    {
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid AppUserId { get; set; }

    public int Rating { get; set; } // 1-5
    public string Comment { get; set; }
    }
}