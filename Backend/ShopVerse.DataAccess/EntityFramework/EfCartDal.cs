using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopVerse.DataAccess.Abstract;
using ShopVerse.DataAccess.Context;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.DataAccess.Repository
{
    public class EfCartDal : GenericRepository<Cart>, ICartDal
    {
        public EfCartDal(ShopVerseContext context) : base(context)
        {
        }
    }

}