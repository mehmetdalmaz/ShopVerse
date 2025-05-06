using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopVerse.Entity.Concrete
{
    public class Cart
    {
        public Guid Id { get; set; }

        public Guid? UserId { get; set; }
        public AppUser? User { get; set; }

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}