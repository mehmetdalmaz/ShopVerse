using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // Eklemeyi unutma
using ShopVerse.DataAccess.Abstract;
using ShopVerse.DataAccess.Context;
using ShopVerse.DataAccess.Repository;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.DataAccess.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        private readonly ShopVerseContext _context;

        public EfProductDal(ShopVerseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetByCategoryId(Guid categoryId)
        {
            return await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync(); // Düzenlendi
        }

        public Task<Product?> GetProductWithDetailsAsync(Guid productId)
        {
            return _context.Products
                .Include(p => p.Reviews)
                .Include(p => p.CartItems)
                .FirstOrDefaultAsync(p => p.Id == productId);
        }

        public async Task<List<Product>> Search(string searchString)
        {
            return await _context.Products
                .Where(p =>
                    (p.Name != null && p.Name.Contains(searchString)) ||
                    (p.Description != null && p.Description.Contains(searchString)))
                .ToListAsync(); // Düzenlendi
        }
    }
}
