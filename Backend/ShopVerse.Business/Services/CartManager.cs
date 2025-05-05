using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopVerse.DataAccess.Abstract;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.Business.Services
{
     public class CartManager : ICartService
    {
        private readonly ICartDal _CartDal;
        public CartManager(ICartDal CartDal)
        {
            _CartDal = CartDal;
        }
      
        public async Task TAddAsync(Cart entity)
        {
            await _CartDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(Guid id)
        {
            await _CartDal.DeleteAsync(id);
        }

        public async Task<List<Cart>> TGetAllAsync()
        {
            return await _CartDal.GetAllAsync();
        }

        public async Task<Cart> TGetByIdAsync(Guid id)
        {
            return await _CartDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(Cart entity)
        {
            await _CartDal.UpdateAsync(entity);
        }
    }
}