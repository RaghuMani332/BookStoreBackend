/*
using BuisinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO.Request;
using ModelLayer.Entities;
using System.Security.Claims;

namespace BookStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AddressController(IAddressBL service) : Controller
    {
        [HttpPost]
       public bool addAddress(AddressRequest addressRequest)
        {
            int userId = int.Parse(User.FindFirstValue("userId"));
            return service.addAddress(addressRequest,userId);
        }

        [HttpGet]
        public List<Address> getAllAddress()
        {
            int userId = int.Parse(User.FindFirstValue("userId"));
            return service.getAllAddress(userId);

        }
        [HttpPut]
        public IActionResult updateAddress(AddressRequest address,int addressId)
        {
            return Ok(service.updateAddress(address,addressId));
        }

        [HttpDelete]
        public IActionResult deleteAddress(int addressId)
        {
            return Ok(service.deleteAddress( addressId));
        }


    }
}
*/
using BuisinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO.Request;
using ModelLayer.DTO.Responce;
using ModelLayer.Entities;
using System.Security.Claims;

namespace BookStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AddressController : ControllerBase
    {
        private readonly IAddressBL _service;

        public AddressController(IAddressBL service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddAddress(AddressRequest addressRequest)
        {
            try
            {
                int userId = int.Parse(User.FindFirstValue("userId"));
                bool result = _service.addAddress(addressRequest, userId);
                if (result)
                {
                    return Ok(new ResponseDto<Object> { Success = true, Message = "Address added successfully." });
                }
                return BadRequest(new { Success = false, Message = "Failed to add address." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<Object> { Success = false, Message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAllAddress()
        {
            try
            {
                int userId = int.Parse(User.FindFirstValue("userId"));
                var addresses = _service.getAllAddress(userId);
                return Ok(new ResponseDto<List<Address>> { Success = true, Data = addresses,Message="Address Retrived Successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<Object> { Success = false, Message = ex.Message });
            }
        }

        [HttpPut("{addressId}")]
        public IActionResult UpdateAddress(AddressRequest addressRequest, int addressId)
        {
            try
            {
                bool result = _service.updateAddress(addressRequest, addressId);
                if (result)
                {
                    return Ok(new ResponseDto<Object> { Success = true, Message = "Address updated successfully." });
                }
                return NotFound(new ResponseDto<Object> { Success = false, Message = "Address not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<Object> { Success = false, Message = ex.Message });
            }
        }

        [HttpDelete("{addressId}")]
        public IActionResult DeleteAddress(int addressId)
        {
            try
            {
                bool result = _service.deleteAddress(addressId);
                if (result)
                {
                    return Ok(new ResponseDto<Object> { Success = true, Message = "Address deleted successfully." });
                }
                return NotFound(new ResponseDto<Object> { Success = false, Message = "Address not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<Object> { Success = false, Message = ex.Message });
            }
        }
    }
}
