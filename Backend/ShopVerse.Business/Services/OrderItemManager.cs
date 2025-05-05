using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopVerse.DataAccess.Abstract;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.Business.Services
{
     public class OrderItemManager : IOrderItemService
    {
        private readonly IOrderItemDal _OrderItemDal;
        public OrderItemManager(IOrderItemDal OrderItemDal)
        {
            _OrderItemDal = OrderItemDal;
        }
      
        public async Task TAddAsync(OrderItem entity)
        {
            await _OrderItemDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(Guid id)
        {
            await _OrderItemDal.DeleteAsync(id);
        }

        public async Task<List<OrderItem>> TGetAllAsync()
        {
            return await _OrderItemDal.GetAllAsync();
        }

        public async Task<OrderItem> TGetByIdAsync(Guid id)
        {
            return await _OrderItemDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(OrderItem entity)
        {
            await _OrderItemDal.UpdateAsync(entity);
        }
    }
}