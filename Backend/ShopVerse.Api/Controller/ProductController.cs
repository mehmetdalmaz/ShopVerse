using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopVerse.DataAccess.Abstract;
using ShopVerse.Dto.ProductDto;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResultProductDto>>> GetProductsAsync()
        {
            var products = await _productService.TGetAllAsync();
            var result = _mapper.Map<List<ResultProductDto>>(products);
            if (result == null)
            {
                return NotFound("Ürün bulunamadı");
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ResultProductDto>> GetProductByIdAsync(Guid id)
        {
            var product = await _productService.TGetByIdAsync(id);
            var result = _mapper.Map<ResultProductDto>(product);
            if (result == null)
            {
                return NotFound("Ürün bulunamadı");
            }
            return Ok(result);
        }
        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<List<ResultProductDto>>> GetProductsByCategoryIdAsync(Guid categoryId)
        {
            var products = await _productService.GetByCategoryId(categoryId);
            var result = _mapper.Map<List<ResultProductDto>>(products);
            if (result == null)
            {
                return NotFound("Ürün bulunamadı");
            }
            return Ok(result);
        }
        [HttpGet("search")]
        public async Task<ActionResult<List<ResultProductDto>>> SearchProductsAsync(string search)
        {
            var products = await _productService.Search(search);
            var result = _mapper.Map<List<ResultProductDto>>(products);
            if (result == null)
            {
                return NotFound("Ürün bulunamadı");
            }
            return Ok(result);
        }
        [HttpPost("details/{productId}")]
        public async Task<ActionResult<ResultProductDto>> GetProductWithDetailsAsync(Guid productId)
        {
            var product = await _productService.GetProductWithDetailsAsync(productId);
            var result = _mapper.Map<ResultProductDto>(product);
            if (result == null)
            {
                return NotFound("Ürün bulunamadı");
            }
            return Ok(result);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProductAsync(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            await _productService.TAddAsync(product);
            return Ok("Ürün başarıyla eklendi");
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var product = _mapper.Map<Product>(updateProductDto);
            await _productService.TUpdateAsync(product);
            return Ok("Ürün başarıyla güncellendi");
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProductAsync(Guid id)
        {
            var product = await _productService.TGetByIdAsync(id);
            if (product == null)
            {
                return NotFound("Ürün bulunamadı");
            }
            await _productService.TDeleteAsync(id);
            return Ok("Ürün başarıyla silindi");
        }

    }
}