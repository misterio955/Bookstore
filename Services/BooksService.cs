using System;
using System.Collections.Generic;
using System.Linq;
using Bookstore.Context;
using Bookstore.DBModels;
using Bookstore.Models;

namespace Bookstore.Services
{
    public class BooksService
    {
        BookstoreContext db = new BookstoreContext();

        public List<VMBook> GetAllBooks()
        {
            var books = db.Books.Where(x => x.IsActive).Select(x => new VMBook { BookID = x.BookID, BookName = x.BookName, IsActive = x.IsActive }).ToList();
            return books;
        }

        public void AddBook(VMBook vmbook)
        {
            if (vmbook.BookName != null)
            {
                var newBook = new DBBook { BookID = vmbook.BookID, BookName = vmbook.BookName, IsActive = true };
                db.Books.Add(newBook);
                db.SaveChanges();
            }
        }

        public void DeleteBook(VMBook vmbook)
        {
            var x = (from y in db.Books
                     where y.BookID == vmbook.BookID
                     select y).FirstOrDefault();
            if (x != null)
            {
                x.IsActive = false;
            }
        }

        public void UpdateBook(VMBook vmbook)
        {
            var x = (from y in db.Books
                     where y.BookID == vmbook.BookID
                     select y).FirstOrDefault();
            if (x != null)
            {
                db.Entry(x).CurrentValues.SetValues(vmbook);
                db.SaveChanges();
            }
        }

        public VMBook GetBook(int? id)
        {
            var x = (from y in db.Books
                     where y.BookID == id
                     select y).FirstOrDefault();
            if (x == null)
            {
                return null;
            }
            else return new VMBook { BookID = x.BookID, BookName = x.BookName, IsActive = x.IsActive };
        }

        public bool BookExist(int? id)
        {
            var x = (from y in db.Books
                     where y.BookID == id
                     select y).FirstOrDefault();
            if (x != null) return true;
            else return false;
        }
    }
}