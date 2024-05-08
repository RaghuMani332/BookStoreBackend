using BuisinessLayer.Interface;
using ModelLayer.DTO.Request;
using ModelLayer.Entities;
using RepositaryLayer.Interface;

namespace BuisinessLayer.Service
{
    public class BookBL(IBookRL bookRepo) : IBookBL
    {
        public bool addBook(BookRequest request)
        {
            return bookRepo.addBook((MapToEntity(request)));
        }

        private Book MapToEntity(BookRequest request)
        {
            return new Book { 
                AuthorName = request.AuthorName,
                BookImage = request.BookImage,
                BookName = request.BookName,
                Description = request.Description,
                Price = request.Price,
                Quantity = request.Quantity
            };
        }

        public List<Book> getAllBook()
        {
            return bookRepo.getAllBook();
        }

        public Book getBookById(int bId)
        {
            return bookRepo.getBookById(bId);
        }
    }
}
