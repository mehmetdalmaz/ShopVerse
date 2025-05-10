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
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        private readonly ShopVerseContext _context;
        public EfOrderDal(ShopVerseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Order>> TGetByUserIdAsync(Guid userId)
        {
            return await _context.Orders
        .Include(o => o.Address)                       // Adres bilgisi
        .Include(o => o.Items)                         // OrderItem ilişkisi
            .ThenInclude(oi => oi.Product)             // OrderItem içindeki Product ilişkisi
        .Where(o => o.AppUserId == userId)
        .ToListAsync();


        }
    }
}