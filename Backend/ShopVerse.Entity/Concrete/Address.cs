namespace ShopVerse.Entity.Concrete;

public class Address
{
    public Guid Id { get; set; }
    public string? Title { get; set; } // Ev, iş, vs.
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? District { get; set; }
    public string? PostalCode { get; set; }

    public string? ApplicationUserId { get; set; }
    public AppUser? AppUser { get; set; }
}