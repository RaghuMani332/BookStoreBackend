/*using Dapper;
using ModelLayer.Entities;
using RepositaryLayer.Context;
using RepositaryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositaryLayer.Service
{
    public class BookRL(DapperContext context) : IBookRL
    {
        public bool addBook(Book book)
        {
            IDbConnection con = context.CreateConnection();
            string insertQuery = @"INSERT INTO Books (BookName, BookImage, Description, AuthorName, Quantity, Price) 
                                       VALUES (@BookName, @BookImage, @Description, @AuthorName, @Quantity, @Price)";

            int nora=con.Execute(insertQuery, book);
            return nora>0;
        }

        public List<Book> getAllBook()
        {
            IDbConnection con = context.CreateConnection();
            String getAllBook = "select * from Books";
            return con.Query<Book>(getAllBook).ToList();
        }

        public Book getBookById(int bId)
        {
            IDbConnection con = context.CreateConnection();
            String getAllBook = "select * from Books where BookId=@bId";
            return con.Query<Book>(getAllBook,new {bId=bId}).FirstOrDefault();
        }
    }
}
*/
using Dapper;
using ModelLayer.Entities;
using RepositaryLayer.Context;
using RepositaryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RepositaryLayer.Service
{
    public class BookRL(DapperContext context) : IBookRL
    {
        public bool addBook(Book book)
        {
            IDbConnection con = context.CreateConnection();
            string storedProcedure = "AddBook";

            var parameters = new
            {
                BookName = book.BookName,
                BookImage = book.BookImage,
                Description = book.Description,
                AuthorName = book.AuthorName,
                Quantity = book.Quantity,
                Price = book.Price
            };

            try
            {
                int nora = con.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                return nora > 0;
            }
            catch (Exception ex)
            {
                // Handle the exception as needed
                // Log exception
                throw new Exception("An error occurred while adding the book.", ex);
            }
        }

        public List<Book> getAllBook()
        {
            IDbConnection con = context.CreateConnection();
            string storedProcedure = "GetAllBooks";

            try
            {
                return con.Query<Book>(storedProcedure, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception ex)
            {
                // Handle the exception as needed
                // Log exception
                throw new Exception("An error occurred while retrieving all books.", ex);
            }
        }

        public Book getBookById(int bId)
        {
            IDbConnection con = context.CreateConnection();
            string storedProcedure = "GetBookById";

            var parameters = new { BookId = bId };

            try
            {
                return con.Query<Book>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            catch (Exception ex)
            {
                // Handle the exception as needed
                // Log exception
                throw new Exception("An error occurred while retrieving the book by ID.", ex);
            }
        }
    }
}
