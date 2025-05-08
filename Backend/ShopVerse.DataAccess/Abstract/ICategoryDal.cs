using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.DataAccess.Abstract
{
    public interface ICategoryDal: IGenericDal<Category>
    {
        Task<List<Category>> GetAllCategoriesWithProductsAsync();
    }
}