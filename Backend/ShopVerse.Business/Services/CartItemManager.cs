using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopVerse.DataAccess.Abstract;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.Business.Services
{
     public class CartItemManager : ICartItemService
    {
        private readonly ICartItemDal _CartItemDal;
        public CartItemManager(ICartItemDal CartItemDal)
        {
            _CartItemDal = CartItemDal;
        }
      
        public async Task TAddAsync(CartItem entity)
        {
            await _CartItemDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(Guid id)
        {
            await _CartItemDal.DeleteAsync(id);
        }

        public async Task<List<CartItem>> TGetAllAsync()
        {
            return await _CartItemDal.GetAllAsync();
        }

        public async Task<CartItem> TGetByIdAsync(Guid id)
        {
            return await _CartItemDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(CartItem entity)
        {
            await _CartItemDal.UpdateAsync(entity);
        }
    }
}