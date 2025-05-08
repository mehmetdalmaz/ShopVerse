using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopVerse.DataAccess.Abstract;
using ShopVerse.DataAccess.Context;
using ShopVerse.DataAccess.Repository;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.DataAccess.EntityFramework
{
    public class EfCartItemDal : GenericRepository<CartItem>, ICartItemDal
    {
        private readonly ShopVerseContext _context;

        public EfCartItemDal(ShopVerseContext context) : base(context)
        {
            _context = context;
        }

        public Task<CartItem?> GetByCartAndProductIdAsync(Guid cartId, Guid productId)
        {
            return _context.CartItems
                .Where(ci => ci.CartId == cartId && ci.ProductId == productId)
                .Include(ci => ci.Product)
                .Include(ci => ci.Cart)
                .FirstOrDefaultAsync();
        }
    }
}