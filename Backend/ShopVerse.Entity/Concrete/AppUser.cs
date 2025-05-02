using Microsoft.AspNetCore.Identity;

namespace ShopVerse.Entity.Concrete;

public class AppUser : IdentityUser<Guid>
{
    public string? FullName { get; set; }

    public Cart? Cart { get; set; }
    public ICollection<Address>? Addresses { get; set; }
    public ICollection<Order>? Orders { get; set; }
    public ICollection<ProductReview>? Reviews { get; set; }


}