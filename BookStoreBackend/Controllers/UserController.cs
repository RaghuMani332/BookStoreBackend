/*using BuisinessLayer.ApplicationExcceptionHandler;
using BuisinessLayer.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO.Request;
using ModelLayer.DTO.Responce;
using System.Security.Claims;

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
                return Ok(new ResponseDto<bool>
                {
                    
                    Data= userService.createUser(request),
                    Message="user created"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<bool>
                {
                    Success = false,
                    Data = false,
                    Message = ex.Message
                });
            }
        }
        [HttpGet("{userEmail}/{password}")]
        public IActionResult login(String userEmail,String password)
        {
            //return Ok( userService.login(userEmail, password));
            return Ok( new ResponseDto<string>
            {
                Data= userService.login(userEmail, password),
                Message="logged in"
            } );
        }

       
    }
}
*/

using BuisinessLayer.ApplicationExcceptionHandler;
using BuisinessLayer.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO.Request;
using ModelLayer.DTO.Responce;

namespace BookStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [UserExceptionHandler]
    [EnableCors]
    public class UserController : ControllerBase
    {
        private readonly IUserBL _userService;

        public UserController(IUserBL userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser(UserRequest request)
        {
            try
            {
                bool result = _userService.createUser(request);
                if (result)
                {
                    return Ok(new ResponseDto<bool>
                    {
                        Success = true,
                        Data = result,
                        Message = "User created successfully."
                    });
                }
                return BadRequest(new ResponseDto<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "User creation failed."
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

        [HttpGet("{userEmail}/{password}")]
        public IActionResult Login(string userEmail, string password)
        {
            try
            {
                string[] token = _userService.login(userEmail, password);
                if (!string.IsNullOrEmpty(token[0]))
                {
                    return Ok(new 
                    {
                        Success = true,
                        Data = token[0],
                        Name = token[1],
                        Message = "Logged in successfully."
                    });
                }
                return Unauthorized(new ResponseDto<string>
                {
                    Success = false,
                    Data = null,
                    Message = "Login failed. Invalid email or password."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<string>
                {
                    Success = false,
                    Data = null,
                    Message = ex.Message
                });
            }
        }
    }
}
