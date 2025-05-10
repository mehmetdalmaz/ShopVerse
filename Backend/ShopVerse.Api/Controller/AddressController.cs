using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopVerse.DataAccess.Abstract;
using ShopVerse.Dto.AddressDto;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;
        public AddressController(IAddressService addressService, IMapper mapper)
        {
            _mapper = mapper;
        
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<List<ResultAddressDto>> GetAllAddressesAsync()
        {
            var addresses = await _addressService.TGetAllAsync();
            return _mapper.Map<List<ResultAddressDto>>(addresses);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ResultAddressDto>> GetAddressByIdAsync(Guid id)
        {
            var address = await _addressService.TGetByIdAsync(id);
            var result = _mapper.Map<ResultAddressDto>(address);
            if (result == null)
            {
                return NotFound("Adres bulunamadı");
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAddressAsync(CreateAddressDto createAddressDto)
        {
            var address = _mapper.Map<Address>(createAddressDto);
            await _addressService.TAddAsync(address);
            return Ok("Adres başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAddressAsync(UpdateAddressDto updateAddressDto)
        {
            var address = _mapper.Map<Address>(updateAddressDto);
            await _addressService.TUpdateAsync(address);
            return Ok("Adres başarıyla güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddressAsync(Guid id)
        {
            var address = await _addressService.TGetByIdAsync(id);
            if (address == null)
            {
                return NotFound("Adres bulunamadı");
            }
            await _addressService.TDeleteAsync(id);
            return Ok("Adres başarıyla silindi");
        }
    }
}