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
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {

        private readonly ShopVerseContext _context;

        public EfCategoryDal(ShopVerseContext context) : base(context)
        {
           _context = context; 
        }

        public async Task<List<Category>> GetAllCategoriesWithProductsAsync()
        {
            var categories = await _context.Categories
                .Include(c => c.Products)
                .ToListAsync();

            return categories;
        }
    }
}