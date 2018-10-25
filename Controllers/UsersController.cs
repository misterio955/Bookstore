using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using Bookstore.Models;
using Bookstore.Services;

namespace Bookstore.Controllers
{
    public class UsersController : Controller
    {
        private UsersService uService = new UsersService();

        public ActionResult Index()
        {
            List<VMUser> users = uService.GetAllUsers();
            return View(users);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMUser vmUser)
        {
            if (ModelState.IsValid)
            {
                uService.AddUser(vmUser);
                return RedirectToAction("Index");
            }
            return View(vmUser);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!uService.UserExist(id))
            {
                return HttpNotFound();
            }

            var user = uService.GetUser(id);
            return View(user);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VMUser vmUser)
        {
            if (ModelState.IsValid)
            {
                uService.UpdateUser(vmUser);
                return RedirectToAction("Index");
            }
            return View(vmUser);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!uService.UserExist(id))
            {
                return HttpNotFound();
            }

            var user = uService.GetUser(id);
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var user = uService.GetUser(id);
            uService.DeleteUser(user);
            return RedirectToAction("Index");
        }
    }
}
