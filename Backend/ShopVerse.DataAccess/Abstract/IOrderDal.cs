using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.DataAccess.Abstract
{
    public interface IOrderDal: IGenericDal<Order>
    {
        Task<List<Order>> TGetByUserIdAsync(Guid userId);
        Task<List<Order>> GetAllOrderAdmin();
        

    }
}