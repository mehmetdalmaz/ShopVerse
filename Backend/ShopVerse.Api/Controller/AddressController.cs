using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopVerse.DataAccess.Abstract;
using ShopVerse.Dto.AddressDto;
using ShopVerse.Entity.Concrete;

namespace ShopVerse.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;
        public AddressController(IAddressService addressService, IMapper mapper)
        {
            _mapper = mapper;

            _addressService = addressService;
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
        

        [HttpGet("getall")]
        public async Task<ActionResult<List<ResultAddressDto>>> GetAll()
        {
            var userId = GetUserId();
            var addresses = await _addressService.GetAddressesByUserIdAsync(userId);
            var resultAddressDto = _mapper.Map<List<ResultAddressDto>>(addresses);
            return Ok(resultAddressDto);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddAddress(CreateAddressDto createAddressDto)
        {
            var userId = GetUserId();
            var address = _mapper.Map<Address>(createAddressDto);
            address.UserId = userId;
            await _addressService.TAddAsync(address);
            return Ok("Adres Başarılı bir şekilde Kaydedildi.");
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAddress(UpdateAddressDto updateAddressDto)
        {
            var userId = GetUserId();
            var address = await _addressService.TGetByIdAsync(updateAddressDto.Id);
            if (address == null)
            {
                return NotFound("Adres bulunamadı.");
            }
            if (address.UserId != userId)
            {
                return Forbid("Bu adrese erişim izniniz yok.");
            }
            address.City = updateAddressDto.City;
            address.District = updateAddressDto.District;
            address.City = updateAddressDto.City;
            address.Street = updateAddressDto.Street;
            address.PostalCode = updateAddressDto.PostalCode;
            address.Title = updateAddressDto.Title;
            await _addressService.TUpdateAsync(address);
            return Ok("Adres Başarılı bir şekilde Güncellendi.");
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAddress(Guid id)
        {
            var userId = GetUserId();
            var address = await _addressService.TGetByIdAsync(id);
            if (address == null)
            {
                return NotFound("Adres bulunamadı.");
            }
            if (address.UserId != userId)
            {
                return Forbid("Bu adrese erişim izniniz yok.");
            }
            await _addressService.TDeleteAsync(id);
            return Ok("Adres Başarılı bir şekilde Silindi.");
        }
    }
}