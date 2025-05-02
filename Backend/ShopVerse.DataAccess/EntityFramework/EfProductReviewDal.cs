using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopVerse.DataAccess.Abstract;
using ShopVerse.DataAccess.Context;
using ShopVerse.DataAccess.Repository;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.DataAccess.EntityFramework
{
    public class EfProductReviewDal : GenericRepository<ProductReview>, IProductReviewDal
    {
        public EfProductReviewDal(ShopVerseContext context) : base(context)
        {
        }
    }
}