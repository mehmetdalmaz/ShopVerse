using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopVerse.Business.Services
{
     public class OrderManager : IOrderService
    {
        private readonly IOrderDal _OrderDal;
        public OrderManager(IOrderDal OrderDal)
        {
            _OrderDal = OrderDal;
        }
      
        public async Task TAddAsync(Order entity)
        {
            await _OrderDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(Guid id)
        {
            await _OrderDal.DeleteAsync(id);
        }

        public async Task<List<Order>> TGetAllAsync()
        {
            return await _OrderDal.GetAllAsync();
        }

        public async Task<Order> TGetByIdAsync(Guid id)
        {
            return await _OrderDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(Order entity)
        {
            await _OrderDal.UpdateAsync(entity);
        }
    }
}