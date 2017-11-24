using DAL;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace WebAPI.Controllers
{
    [RoutePrefix("api")]
    public class BookController : ApiController
    {
        private readonly LibraryTestContext db;

        public BookController()
        {
            db = new LibraryTestContext();
        }

        [Route("books")]
        public ICollection<Book> GetBooks()
        {
            ICollection<Book> books;

            using (LibraryTestContext db1 = new LibraryTestContext())
            {
                books = (from d in db1.Books
                        select d).ToList();
            }

            return books;
        }

        [Route("books/{id}")]
        public Book GetById(int id)
        {
            return db.Books.FirstOrDefault(t => t.BookId == id);
        }

        [Route("books")]
        [HttpPost]
        public void CreateBook([FromBody]Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }

        [Route("books/{id}")]
        [HttpDelete]
        public void DeleteBook(int id)
        {
            var book = db.Books.Where(t => t.BookId == id).FirstOrDefault();

            db.Entry(book).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }

        [Route("books")]
        [HttpPut]
        public void Update(Book updatedBook)
        {
            var book = db.Books.Where(t => t.BookId == updatedBook.BookId).FirstOrDefault();

            if (book != null)
            {
                book.Name = updatedBook.Name;
                book.Author = updatedBook.Author;
                book.Code = updatedBook.Code;

                db.SaveChanges();
            }
        }
    }
}
