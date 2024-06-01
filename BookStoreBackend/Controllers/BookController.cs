/*using BuisinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO.Request;
using ModelLayer.DTO.Responce;
using ModelLayer.Entities;
using RepositaryLayer.Interface;
using System.Security.Claims;

namespace BookStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController(IBookBL bookService):ControllerBase
    {
        [HttpPost]
        public IActionResult addBook(BookRequest request) 
        {
           return Ok( bookService.addBook(request));
        }
        [HttpGet]
        public IActionResult GetAllBook() 
        {
            List<Book> li = bookService.getAllBook();
            return Ok( li );
        }
        [HttpGet("{bId}")]
        public IActionResult getBookById(int bId) 
        {
            Book b=bookService.getBookById(bId);
            return Ok( b );
        }



        [HttpGet("getNameByToken")]
        public ResponceDto<string> GetName()
        {
            return new ResponceDto<string> { data = User.FindFirstValue(ClaimTypes.Name) };
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
    public class BookController : ControllerBase
    {
        private readonly IBookBL _bookService;

        public BookController(IBookBL bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public IActionResult AddBook(BookRequest request)
        {
            try
            {
                var result = _bookService.addBook(request);
                if (result != null)
                {
                    return Ok(new ResponseDto<bool> { Success = true, Message = "Book added successfully.", Data = result });
                }
                return BadRequest(new ResponseDto<Book> { Success = false, Message = "Failed to add book." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<Book> { Success = false, Message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _bookService.getAllBook();
                return Ok(new ResponseDto<List<Book>> { Success = true, Data = books,Message="Fetched Data Successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<List<Book>> { Success = false, Message = ex.Message });
            }
        }

        [HttpGet("{bId}")]
        public IActionResult GetBookById(int bId)
        {
            try
            {
                var book = _bookService.getBookById(bId);
                if (book != null)
                {
                    return Ok(new ResponseDto<Book> { Success = true, Data = book,Message="Book Retrived By Id" });
                }
                return NotFound(new ResponseDto<Book> { Success = false, Message = "Book not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<Book> { Success = false, Message = ex.Message });
            }
        }

        /*[HttpGet("getNameByToken")]
        public IActionResult GetName()
        {
            try
            {
                var name = User.FindFirstValue(ClaimTypes.Name);
                return Ok(new ResponseDto<string> { Success = true, Data = name });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<string> { Success = false, Message = ex.Message });
            }
        }*/
    }
}
