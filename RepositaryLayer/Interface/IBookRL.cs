﻿using ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositaryLayer.Interface
{
    public interface IBookRL
    {
        bool addBook(Book book);
        List<Book> getAllBook();
        Book getBookById(int bId);
    }
}
