using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopVerse.DataAccess.Abstract;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.Business.Services
{
     public class ProductReviewManager : IProductReviewService
    {
        private readonly IProductReviewDal _ProductReviewDal;
        public ProductReviewManager(IProductReviewDal ProductReviewDal)
        {
            _ProductReviewDal = ProductReviewDal;
        }
      
        public async Task TAddAsync(ProductReview entity)
        {
            await _ProductReviewDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(Guid id)
        {
            await _ProductReviewDal.DeleteAsync(id);
        }

        public async Task<List<ProductReview>> TGetAllAsync()
        {
            return await _ProductReviewDal.GetAllAsync();
        }

        public async Task<ProductReview> TGetByIdAsync(Guid id)
        {
            return await _ProductReviewDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(ProductReview entity)
        {
            await _ProductReviewDal.UpdateAsync(entity);
        }
    }
}