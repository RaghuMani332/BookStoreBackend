
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

    }
}
