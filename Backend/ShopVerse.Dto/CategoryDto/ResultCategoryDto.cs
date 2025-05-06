using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopVerse.Dto.ProductDto;

namespace ShopVerse.Dto.CategoryDto
{
    public class ResultCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ResultProductDto> Products { get; set; }
    }
}