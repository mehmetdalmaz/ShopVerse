using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.DataAccess.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        Task<List<Product>> GetByCategoryId(Guid categoryId);
        Task<List<Product>> Search(string searchString);
        Task<Product?> GetProductWithDetailsAsync(Guid productId);
    }
}