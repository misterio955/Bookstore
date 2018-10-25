using Bookstore.Context;
using Bookstore.DBModels;
using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Services
{
    public class UsersService
    {
        BookstoreContext db = new BookstoreContext();

        public List<VMUser> GetAllUsers()
        {
            var users = db.Users.Select(x => new VMUser { UserID = x.UserID, UserName = x.UserName }).ToList();
            return users;
        }

        public void AddUser(VMUser user)
        {

            if (user.UserID != null)
            {
                var newUser = new DBUser { UserID = user.UserID, UserName = user.UserName };
                db.Users.Add(newUser);
                db.SaveChanges();
            }
        }

        public void DeleteUser(VMUser vmuser)
        {
            var x = (from y in db.Users
                     where y.UserID == vmuser.UserID
                     select y).FirstOrDefault();
            if (x != null)
            {
                db.Users.Remove(x);
                db.SaveChanges();
            }
        }

        public void UpdateUser(VMUser vmuser)
        {
            var x = (from y in db.Users
                     where y.UserID == vmuser.UserID
                     select y).FirstOrDefault();
            if (x != null)
            {
                db.Entry(x).CurrentValues.SetValues(vmuser);
                db.SaveChanges();
            }
        }

        public bool UserExist(Guid? id)
        {
            var x = (from y in db.Users
                     where y.UserID == id
                     select y).FirstOrDefault();
            if (x != null) return true;
            else return false;
        }

        public VMUser GetUser(Guid? id)
        {
            var x = (from y in db.Users
                     where y.UserID == id
                     select y).FirstOrDefault();
            if (x == null)
            {
                return null;
            }
            else return new VMUser { UserID = x.UserID, UserName = x.UserName };
        }
    }
}
