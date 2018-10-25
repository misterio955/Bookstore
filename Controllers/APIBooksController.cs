using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Bookstore.Models;
using Bookstore.Services;

namespace Bookstore.Controllers
{
    [Route("api/book/{id}")]
    public class APIBooksController : ApiController
    {

        private readonly BooksService bService = new BooksService();

        // GET: api/APIBooks
        [Route("api/books")]
        [HttpGet]
        public IEnumerable<VMBook> GetBooks()
        {
            return bService.GetAllBooks();
        }

        // GET: api/APIBooks/5
        // [ResponseType(typeof(VMBook))]
        [HttpGet]
        public IHttpActionResult GetBook(int id)
        {
            VMBook book = bService.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // PUT: api/APIBooks/5

        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult PutBook(int id, VMBook book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.BookID)
            {
                return BadRequest();
            }

            bService.UpdateBook(book);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/APIBooks
        [ResponseType(typeof(VMBook))]
        [HttpPost]
        public IHttpActionResult PostBook(VMBook book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bService.AddBook(book);
            return CreatedAtRoute("DefaultApi", new { id = book.BookID }, book);
        }

        // DELETE: api/APIBooks/5
        [ResponseType(typeof(VMBook))]
        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            VMBook book = bService.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

            bService.DeleteBook(book);
            return Ok(book);
        }
    }
}