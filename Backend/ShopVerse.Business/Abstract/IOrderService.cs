using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopVerse.Dto.OrderDto;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.DataAccess.Abstract
{
    public interface IOrderService: IGenericService<Order>
    {
        Task<Guid> CreateOrderAsync( CreateOrderDto createOrderDto, Guid userId);
        Task<List<Order>> TGetByUserIdAsync(Guid userId);

    }
}