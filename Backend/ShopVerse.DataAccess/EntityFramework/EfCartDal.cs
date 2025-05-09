using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopVerse.DataAccess.Abstract;
using ShopVerse.DataAccess.Context;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.DataAccess.Repository
{
    public class EfCartDal : GenericRepository<Cart>, ICartDal
    {
        private readonly ShopVerseContext _context;
        public EfCartDal(ShopVerseContext context) : base(context)
        {
            _context = context;
        }

        public Task<Cart?> GetCartWithItemsAsync(Guid userId)
        {
            return _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }
    }

}