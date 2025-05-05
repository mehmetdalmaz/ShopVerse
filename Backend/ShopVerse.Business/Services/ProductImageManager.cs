using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopVerse.DataAccess.Abstract;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.Business.Services
{
      public class ProductImageManager : IProductImageService
    {
        private readonly IProductImageDal _ProductImageDal;
        public ProductImageManager(IProductImageDal ProductImageDal)
        {
            _ProductImageDal = ProductImageDal;
        }
      
        public async Task TAddAsync(ProductImage entity)
        {
            await _ProductImageDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(Guid id)
        {
            await _ProductImageDal.DeleteAsync(id);
        }

        public async Task<List<ProductImage>> TGetAllAsync()
        {
            return await _ProductImageDal.GetAllAsync();
        }

        public async Task<ProductImage> TGetByIdAsync(Guid id)
        {
            return await _ProductImageDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(ProductImage entity)
        {
            await _ProductImageDal.UpdateAsync(entity);
        }
    }
}