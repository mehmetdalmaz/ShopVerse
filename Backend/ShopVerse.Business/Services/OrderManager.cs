using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopVerse.DataAccess.Abstract;
using ShopVerse.Dto.OrderDto;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.Business.Services
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _OrderDal;
        private readonly ICartService _cartService;
        private readonly IProductService _productService;
        public OrderManager(IOrderDal OrderDal, ICartService cartService, IProductService productService)
        {
            _cartService = cartService;
            _productService = productService;
            _OrderDal = OrderDal;
        }

        public async Task<Guid> CreateOrderAsync(CreateOrderDto createOrderDto, Guid userId)
        {
            var cart = await _cartService.GetOrCreateCartAsync(userId);
            if (cart == null || !cart.CartItems.Any())
                throw new InvalidOperationException("Sepet boş.");

            var orderItems = new List<OrderItem>();

            foreach (var cartItem in cart.CartItems)
            {
                var product = await _productService.TGetByIdAsync(cartItem.ProductId);
                if (product == null)
                    throw new InvalidOperationException("Ürün bulunamadı.");

                if (product.Stock < cartItem.Quantity)
                    throw new Exception(product.Name);

                product.Stock -= cartItem.Quantity;

                orderItems.Add(new OrderItem
                {
                    ProductId = product.Id,
                    Quantity = cartItem.Quantity,
                    UnitPrice = product.Price
                });

                await _productService.TUpdateAsync(product); // Ürün güncellemesi unutulmasın!
            }

            var order = new Order
            {
                AppUserId = userId,
                AddressId = createOrderDto.AddressId,
                Items = orderItems,
                CreatedAt = DateTime.UtcNow
            };

            await _OrderDal.AddAsync(order);
            await _cartService.ClearCartAsync(cart.Id);

            return order.Id;
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

        public async Task<List<Order>> TGetByUserIdAsync(Guid userId)
        {
            var orders = await _OrderDal.TGetByUserIdAsync(userId);
            return orders;


        }

        public async Task TUpdateAsync(Order entity)
        {
            await _OrderDal.UpdateAsync(entity);
        }
    }
}