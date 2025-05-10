namespace ShopVerse.Entity.Concrete;

public class Order
{
    public Guid Id { get; set; }
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<OrderItem> Items { get; set; } =new List<OrderItem>();
    public Guid AddressId { get; set; }
    public Address? Address { get; set; }

}