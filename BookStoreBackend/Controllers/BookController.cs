using BuisinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO.Request;
using ModelLayer.Entities;
using RepositaryLayer.Interface;

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
    }
}
