/*using BuisinessLayer.Interface;
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
        public IActionResult deleteWishList(int wishListId)
        {
            int uId = int.Parse(User.FindFirstValue("userId"));
           return Ok(service.deleteWishList(uId, wishListId));
        }
    }
}
*/
using BuisinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO.Request;
using ModelLayer.DTO.Responce;
using System.Security.Claims;

namespace BookStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly IWishListBL _service;

        public WishListController(IWishListBL service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddWishList(WishListRequest request)
        {
            try
            {
                int uId = int.Parse(User.FindFirstValue("userId"));
                var result = _service.addWishList(request, uId);
                if (result)
                {
                    return Ok(new ResponseDto<bool>
                    {
                        Success = true,
                        Data = result,
                        Message = "Wish list item added successfully."
                    });
                }
                return BadRequest(new ResponseDto<bool>
                {
                    Success = false,
                    Data = result,
                    Message = "Failed to add wish list item."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<bool>
                {
                    Success = false,
                    Data = false,
                    Message = ex.Message
                });
            }
        }

        [HttpGet]
        public IActionResult GetWishList()
        {
            try
            {
                int uId = int.Parse(User.FindFirstValue("userId"));
                var wishList = _service.getWishList(uId);
                return Ok(new ResponseDto<List<Object>>
                {
                    Success = true,
                    Data = wishList,
                    Message = "Wish list retrieved successfully."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<List<Object>>
                {
                    Success = false,
                    Data = null,
                    Message = ex.Message
                });
            }
        }

        [HttpDelete("{wishListId}")]
        public IActionResult DeleteWishList(int wishListId)
        {
            try
            {
                int uId = int.Parse(User.FindFirstValue("userId"));
                var result = _service.deleteWishList(uId, wishListId);
                if (result)
                {
                    return Ok(new ResponseDto<bool>
                    {
                        Success = true,
                        Data = result,
                        Message = "Wish list item deleted successfully."
                    });
                }
                return NotFound(new ResponseDto<bool>
                {
                    Success = false,
                    Data = result,
                    Message = "Wish list item not found."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<bool>
                {
                    Success = false,
                    Data = false,
                    Message = ex.Message
                });
            }
        }
    }
}
