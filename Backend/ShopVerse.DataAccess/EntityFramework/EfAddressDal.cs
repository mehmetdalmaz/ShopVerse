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
    public class EfAddressDal : GenericRepository<Address>, IAddressDal
    {
        private readonly ShopVerseContext _context;

        public EfAddressDal(ShopVerseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Address>> GetAddressesByUserIdAsync(Guid userId)
        {
           return await _context.Addresses
        .Include(a => a.AppUser) 
        .Where(a => a.UserId == userId)
        .ToListAsync();

        }
    }
}