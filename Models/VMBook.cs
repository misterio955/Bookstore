using System.Runtime.Serialization;

namespace Bookstore.Models
{
    [DataContract]
    public class VMBook
    {
        [DataMember]
        public int BookID { get; set; }

        [DataMember]
        public string BookName { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
    }
}
