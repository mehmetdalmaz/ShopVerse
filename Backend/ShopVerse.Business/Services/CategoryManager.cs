using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopVerse.DataAccess.Abstract;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.Business.Services
{
     public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _CategoryDal;
        public CategoryManager(ICategoryDal CategoryDal)
        {
            _CategoryDal = CategoryDal;
        }
      
        public async Task TAddAsync(Category entity)
        {
            await _CategoryDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(Guid id)
        {
            await _CategoryDal.DeleteAsync(id);
        }

        public async Task<List<Category>> TGetAllAsync()
        {
            return await _CategoryDal.GetAllAsync();
        }

        public async Task<Category> TGetByIdAsync(Guid id)
        {
            return await _CategoryDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(Category entity)
        {
            await _CategoryDal.UpdateAsync(entity);
        }
    }
}