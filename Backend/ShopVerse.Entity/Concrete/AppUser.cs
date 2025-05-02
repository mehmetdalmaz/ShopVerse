using Microsoft.AspNetCore.Identity;

namespace ShopVerse.Entity.Concrete;

public class AppUser : IdentityUser
{
    public string? FullName { get; set; }

    public ICollection<Address>? Addresses { get; set; }
    public ICollection<Order>? Orders { get; set; }
    public ICollection<ProductReview>? Reviews { get; set; }

}