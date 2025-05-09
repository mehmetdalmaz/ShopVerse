using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.DataAccess.Abstract
{
    public interface ICartService: IGenericService<Cart>
    {
        Task<Cart?> GetOrCreateCartAsync(Guid userId);
        Task AddItemAsync(Cart cart, Product product, int quantity);
        Task RemoveItemAsync(Cart cart, Guid productId, int quantity);

    }
}