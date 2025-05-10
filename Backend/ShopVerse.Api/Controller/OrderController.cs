using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopVerse.DataAccess.Abstract;
using ShopVerse.Dto.OrderDto;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.Api.Controller
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
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

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder(CreateOrderDto createOrderDto)
        {
            var userId = GetUserId();

            await _orderService.CreateOrderAsync(createOrderDto, userId);

            return Ok("Order created successfully.");
        }
        [HttpGet]
        public async Task<ActionResult<List<ResultOrderDto>>> GetOrders()
        {
            var userId = GetUserId();
            var orders = await _orderService.TGetByUserIdAsync(userId);
            var resultOrderDto = _mapper.Map<List<ResultOrderDto>>(orders);
            return Ok(resultOrderDto);
        }
    }
}