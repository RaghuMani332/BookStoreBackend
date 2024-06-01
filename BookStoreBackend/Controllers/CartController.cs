/*using Azure.Core;
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
    public class CartController(ICartBL cartservice):ControllerBase
    {
        [HttpPost]
        public IActionResult addCart(CartRequest request)
        {
            int uId = int.Parse(User.FindFirstValue("userId"));
            request.userId = uId;
            return Ok(cartservice.addCart(request));
        }

        [HttpPut("{cartId}/{quantity}")]
        public IActionResult updateCartquantity(int cartId,int quantity)
        {
            return Ok(cartservice.updateCartquantity(cartId,quantity));
        }

        [HttpPut("/Order")]
        public IActionResult updateCartOrder(int cartId, bool isOrdered)
        {
            return Ok(cartservice.updateCartOrder(cartId,isOrdered));
        }
        [HttpPatch]
        public IActionResult uncart(int cartId) 
        {
            int userId= int.Parse(User.FindFirstValue("userId"));
            return Ok(cartservice.unCart(cartId, userId));
        }

        [HttpGet]
        public IActionResult getCartByUserId()
        {
            int id = int.Parse(User.FindFirstValue("userId"));
            List<CartResponce> c = cartservice.getByUserId(id);
            return Ok(c);
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
    public class CartController : ControllerBase
    {
        private readonly ICartBL _cartService;

        public CartController(ICartBL cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        public IActionResult AddCart(CartRequest request)
        {
            try
            {
                int uId = int.Parse(User.FindFirstValue("userId"));
                request.userId = uId;
                var result = _cartService.addCart(request);
                if (result != null)
                {
                    return Ok(new ResponseDto<int> { Success = true, Message = "Cart added successfully.", Data = result });
                }
                return BadRequest(new ResponseDto<Cart> { Success = false, Message = "Failed to add cart." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<Cart> { Success = false, Message = ex.Message });
            }
        }

        [HttpPut("{cartId}/{quantity}")]
        public IActionResult UpdateCartQuantity(int cartId, int quantity)
        {
            try
            {
                var result = _cartService.updateCartquantity(cartId, quantity);
                if (result)
                {
                    return Ok(new ResponseDto<bool> { Success = true, Message = "Cart quantity updated successfully.", Data = result });
                }
                return NotFound(new ResponseDto<bool> { Success = false, Message = "Cart not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<bool> { Success = false, Message = ex.Message });
            }
        }

        [HttpPut("Order/{cartId}/{isOrdered}")]
        public IActionResult UpdateCartOrder(int cartId, bool isOrdered)
        {
            try
            {
                var result = _cartService.updateCartOrder(cartId, isOrdered);
                if (result)
                {
                    return Ok(new ResponseDto<bool> { Success = true, Message = "Cart order status updated successfully.", Data = result });
                }
                return NotFound(new ResponseDto<bool> { Success = false, Message = "Cart not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<bool> { Success = false, Message = ex.Message });
            }
        }

        [HttpPatch("{cartId}")]
        public IActionResult Uncart(int cartId)
        {
            try
            {
                int userId = int.Parse(User.FindFirstValue("userId"));
                var result = _cartService.unCart(cartId, userId);
                if (result)
                {
                    return Ok(new ResponseDto<bool> { Success = true, Message = "Cart uncategorized successfully.", Data = result });
                }
                return NotFound(new ResponseDto<bool> { Success = false, Message = "Cart not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<bool> { Success = false, Message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetCartByUserId()
        {
            try
            {
                int userId = int.Parse(User.FindFirstValue("userId"));
                var carts = _cartService.getByUserId(userId);
                return Ok(new ResponseDto<List<CartResponce>> { Success = true, Data = carts,Message="Cart retrived" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<List<CartResponce>> { Success = false, Message = ex.Message });
            }
        }
    }
}
