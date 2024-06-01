/*using BuisinessLayer.Interface;
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
*/
using BuisinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO.Request;
using ModelLayer.DTO.Responce;
using ModelLayer.Entities;
using System.Security.Claims;

namespace BookStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderBL _orderBL;

        public OrderController(IOrderBL orderBL)
        {
            _orderBL = orderBL;
        }

        [HttpPost]
        public IActionResult AddOrder(OrderRequest requestDto)
        {
            try
            {
                int userId = int.Parse(User.FindFirstValue("userId"));
                var result = _orderBL.AddOrder(requestDto, userId);
                if (result != null)
                {
                    return Ok(new ResponseDto<List<Object>> { Success = true, Message = "Order placed successfully.", Data = result });
                }
                return BadRequest(new ResponseDto<Order> { Success = false, Message = "Failed to place order." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<Order> { Success = false, Message = ex.Message });
            }
        }

        [HttpGet("GetOrder")]
        public IActionResult GetOrder()
        {
            try
            {
                int userId = int.Parse(User.FindFirstValue("userId"));
                var orders = _orderBL.GetOrder(userId);
                if (orders != null && orders.Any())
                {
                    return Ok(new ResponseDto<List<Object>> { Success = true, Data = orders,Message= "orders retrived successfully" });
                }
                return NotFound(new ResponseDto<List<Order>> { Success = false, Message = "No orders found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<List<Order>> { Success = false, Message = ex.Message });
            }
        }
    }
}
