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

        public async Task AddItemAsync(Cart cart, Product product, int quantity)
        {
            if (product.Stock < quantity)
            {
                throw new Exception($"Ürün '{product.Name}' için yeterli stok yok.");
            }

            var item = cart.CartItems.FirstOrDefault(c => c.ProductId == product.Id);

            if (item == null)
            {
                cart.CartItems.Add(new CartItem
                {
                    Product = product,
                    ProductId = product.Id,
                    Quantity = quantity
                });
            }
            else
            {
                item.Quantity += quantity;
            }

            product.Stock -= quantity;
            await _CartDal.UpdateAsync(cart);
        }

        public async Task<Cart?> GetOrCreateCartAsync(Guid userId)
        {
            var cart = await _CartDal.GetCartWithItemsAsync(userId);
            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId,
                    CartItems = new List<CartItem>()
                };
                await _CartDal.AddAsync(cart);
            }
            return cart;
        }

        public async Task RemoveItemAsync(Cart cart, Guid productId, int quantity)
        {
            var item = cart.CartItems.FirstOrDefault(c => c.ProductId == productId);
            if (item == null)
            {
                throw new Exception("Sepette bu ürün bulunmuyor.");
            }
            if (quantity <= 0)
            {
                throw new Exception("Geçersiz ürün miktarı.");
            }
            if (item.Product == null)
            {
                throw new Exception("Ürün bulunamadı.");
            }

            if (quantity >= item.Quantity)
            {
                cart.CartItems.Remove(item);
                item.Product.Stock += item.Quantity;
            }
            else
            {
                item.Quantity -= quantity;
                item.Product.Stock += quantity;
            }

            await _CartDal.UpdateAsync(cart);
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