using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopVerse.DataAccess.Abstract;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.Business.Services
{
     public class ProductManager : IProductService
    {
        private readonly IProductDal _ProductDal;
        public ProductManager(IProductDal ProductDal)
        {
            _ProductDal = ProductDal;
        }

        public async Task<List<Product>> GetByCategoryId(Guid categoryId)
        {
            return await _ProductDal.GetByCategoryId(categoryId);
        }

        public async Task<Product?> GetProductWithDetailsAsync(Guid productId)
        {
            return await _ProductDal.GetProductWithDetailsAsync(productId);
        }

        public async Task<List<Product>> Search(string searchString)
        {
            return await _ProductDal.Search(searchString);
        }

        public async Task TAddAsync(Product entity)
        {
            await _ProductDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(Guid id)
        {
            await _ProductDal.DeleteAsync(id);
        }

        public async Task<List<Product>> TGetAllAsync()
        {
            return await _ProductDal.GetAllAsync();
        }

      

        public async Task<Product> TGetByIdAsync(Guid id)
        {
            return await _ProductDal.GetByIdAsync(id);
        }

              public async Task TUpdateAsync(Product entity)
        {
            await _ProductDal.UpdateAsync(entity);
        }
    }
}