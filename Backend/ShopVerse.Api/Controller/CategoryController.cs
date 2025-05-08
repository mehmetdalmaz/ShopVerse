using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopVerse.DataAccess.Abstract;
using ShopVerse.Dto.CategoryDto;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<List<ResultCategoryDto>> GetAllWithProductsAsync()
        {
            var categories = await _categoryService.GetAllCategoriesWithProductsAsync();
            return _mapper.Map<List<ResultCategoryDto>>(categories);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ResultCategoryDto>> GetCategoryByIdAsync(Guid id)
        {
            var category = await _categoryService.TGetByIdAsync(id);
            var result = _mapper.Map<ResultCategoryDto>(category);
            if (result == null)
            {
                return NotFound("Kategori bulunamadı");
            }
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var values = _mapper.Map<Category>(createCategoryDto);
            await _categoryService.TAddAsync(values);
            return Ok("Kategori başarıyla eklendi");
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var category = _mapper.Map<Category>(updateCategoryDto);
            await _categoryService.TUpdateAsync(category);
            return Ok("Kategori başarıyla güncellendi");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategoryAsync(Guid id)
        {
            var category = await _categoryService.TGetByIdAsync(id);
            if (category == null)
            {
                return NotFound("Kategori bulunamadı");
            }
            await _categoryService.TDeleteAsync(id);
            return Ok("Kategori başarıyla silindi");
        }
    }
}



