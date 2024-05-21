using BuisinessLayer.Interface;
using BuisinessLayer.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO.Request;
using System.Security.Claims;

namespace BookStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderBL orderBL) : ControllerBase
    {
        [HttpPost]
        public IActionResult AddOrder(OrderRequest requestDto)
        {
            try
            {
                int userId = int.Parse(User.FindFirstValue("userId"));
                var result = orderBL.AddOrder(requestDto, userId);
                    return Ok(result);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("GetOrder")]
        public IActionResult GetOrder()
        {
            int userId = int.Parse(User.FindFirstValue("userId"));
            var cartBooks = orderBL.GetOrder(userId);
            return Ok(cartBooks);
        }
    }
}
