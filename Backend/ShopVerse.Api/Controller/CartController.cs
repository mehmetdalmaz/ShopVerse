using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopVerse.DataAccess.Abstract;
using ShopVerse.Dto.CartDto;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public CartController(ICartService cartService, IProductService productService, IMapper mapper)
        {
            _cartService = cartService;
            _productService = productService;
            _mapper = mapper;
        }

        private Guid GetUserId()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                throw new UnauthorizedAccessException("Kullanıcı kimliği bulunamadı.");
            }
            return Guid.Parse(userIdClaim.Value);
        }

        [HttpGet]
        public async Task<ActionResult<ResultCartDto>> GetCart()
        {
            var userId = GetUserId();
            var cart = await _cartService.GetOrCreateCartAsync(userId);
            var cartDto = _mapper.Map<ResultCartDto>(cart);
            return Ok(cartDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddItemToCart(Guid productId, int quantity)
        {
            var userId = GetUserId();
            var cart = await _cartService.GetOrCreateCartAsync(userId);
            var product = await _productService.TGetByIdAsync(productId);
            if (cart == null)
                return NotFound("cart not found");

            if (product == null)
                return NotFound("Product not found");

            await _cartService.AddItemAsync(cart, product, quantity);
            var cartDto = _mapper.Map<CreateCartDto>(cart);
            return Ok(cartDto);
        }
        
        [HttpDelete("{productId}")]
        public async Task<IActionResult> RemoveItemFromCart(Guid productId)
        {
            {
                var userId = GetUserId();
                var cart = await _cartService.GetOrCreateCartAsync(userId);
                if (cart == null)
                    return NotFound("Cart not found");

                await _cartService.RemoveItemAsync(cart, productId, quantity: 1);
                var cartDto = _mapper.Map<CreateCartDto>(cart);
                return Ok(cartDto);
            }

        }
    }
}
