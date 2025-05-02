namespace ShopVerse.Entity.Concrete;

public class Product
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }

    public ICollection<ProductImage>? Images { get; set; }
    public ICollection<ProductReview>? Reviews { get; set; }
    public ICollection<CartItem>? CartItems { get; set; }

}