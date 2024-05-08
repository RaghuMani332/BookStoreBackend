using Azure.Core;
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
    public class CartController(ICartBL cartservice):ControllerBase
    {
        [HttpPost]
        public IActionResult addCart(CartRequest request)
        {
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

        [HttpGet]
        public IActionResult getCartByUserId()
        {
            int id = int.Parse(User.FindFirstValue("userId"));
            Cart c = cartservice.getByUserId(id);
            return Ok(c);
        }
    }
}
