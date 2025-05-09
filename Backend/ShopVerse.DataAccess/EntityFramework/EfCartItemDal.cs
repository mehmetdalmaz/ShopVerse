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
    public class EfCartItemDal : GenericRepository<CartItem>, ICartItemDal
    {
        public EfCartItemDal(ShopVerseContext context) : base(context)
        {
        }
    }
}