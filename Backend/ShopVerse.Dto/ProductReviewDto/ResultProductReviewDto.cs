using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopVerse.Dto.ProductReviewDto
{
    public class ResultProductReviewDto
    {
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }

    public Guid AppUserId { get; set; }

    public int Rating { get; set; } // 1-5
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}