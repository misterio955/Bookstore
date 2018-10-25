using Bookstore.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.DBModels
{
    public class DBBook
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public bool IsActive { get; set; }
    }
}
