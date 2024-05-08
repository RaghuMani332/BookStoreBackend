using ModelLayer.DTO.Request;
using ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLayer.Interface
{
    public interface IBookBL
    {
        bool addBook(BookRequest request);
        List<Book> getAllBook();
        Book getBookById(int bId);
    }
}
