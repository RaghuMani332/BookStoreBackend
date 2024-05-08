using Dapper;
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
