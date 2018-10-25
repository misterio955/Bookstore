using Bookstore.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.DBModels
{
    public class DBUser
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; }
    }
}