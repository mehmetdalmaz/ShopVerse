namespace ShopVerse.Entity.Concrete;

public class ProductReview
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }

    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }

    public int Rating { get; set; } // 1-5
    public string? Comment { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}