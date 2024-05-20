using BuisinessLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO.Request;
using System.Security.Claims;

namespace BookStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController(IWishListBL service) : ControllerBase
    {
        [HttpPost]
        public IActionResult addWishList(WishListRequest request)
        {
            int uId = int.Parse(User.FindFirstValue("userId"));

            return Ok( service.addWishList(request,uId));
        }
        [HttpGet]
        public IActionResult getWishList()
        {
            int uId = int.Parse(User.FindFirstValue("userId"));
           return Ok(service.getWishList(uId));
        }

        [HttpDelete]
        public IActionResult deleteWishList(int cartId)
        {
            int uId = int.Parse(User.FindFirstValue("userId"));
           return Ok(service.deleteWishList(uId,cartId));
        }
    }
}
