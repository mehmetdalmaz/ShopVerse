using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopVerse.DataAccess.Abstract;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.Business.Services
{
    public class AddressManager : IAddressService
    {
        private readonly IAddressDal _addressDal;
        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }
      
        public async Task TAddAsync(Address entity)
        {
            await _addressDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(Guid id)
        {
            await _addressDal.DeleteAsync(id);
        }

        public async Task<List<Address>> TGetAllAsync()
        {
            return await _addressDal.GetAllAsync();
        }

        public async Task<Address> TGetByIdAsync(Guid id)
        {
            return await _addressDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(Address entity)
        {
            await _addressDal.UpdateAsync(entity);
        }
    }
}