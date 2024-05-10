using BuisinessLayer.ApplicationExcceptionHandler;
using BuisinessLayer.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO.Request;
using ModelLayer.DTO.Responce;

namespace BookStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [UserExceptionHandler]
    [EnableCors]
    public class UserController(IUserBL userService) : ControllerBase
    {


        [HttpPost]
        public IActionResult createUser(UserRequest request)
        {
            try
            {
                return Ok(new ResponceDto<bool>
                {
                    data = userService.createUser(request),
                    messasge="user created"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponceDto<bool>
                {
                    isSuccess = false,
                    data = false,
                    messasge = ex.Message
                });
            }
        }
        [HttpGet("{userEmail}/{password}")]
        public IActionResult login(String userEmail,String password)
        {
            //return Ok( userService.login(userEmail, password));
            return Ok( new ResponceDto<string>
            {
                data= userService.login(userEmail, password),
                messasge="logged in"
            } );
        }
    }
}
