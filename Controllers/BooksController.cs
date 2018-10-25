using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using Bookstore.Models;
using Bookstore.Services;

namespace Bookstore.Controllers
{
    public class BooksController : Controller
    {
        BooksService booksService = new BooksService();

        public ActionResult Index()
        {
            List<VMBook> books = booksService.GetAllBooks();
            return View(books);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMBook vmbook)
        {
            if (ModelState.IsValid)
            {
                booksService.AddBook(vmbook);
                return RedirectToAction("Index");
            }

            return View(vmbook);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!booksService.BookExist(id))
            {
                return HttpNotFound();
            }
            var book = booksService.GetBook(id);
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VMBook vmBook)
        {
            if (ModelState.IsValid)
            {
                booksService.UpdateBook(vmBook);
                return RedirectToAction("Index");
            }
            return View(vmBook);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!booksService.BookExist(id))
            {
                return HttpNotFound();
            }

            VMBook book = booksService.GetBook(id);
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var book = booksService.GetBook(id);
            booksService.DeleteBook(book);
            return RedirectToAction("Index");
        }
    }
}
