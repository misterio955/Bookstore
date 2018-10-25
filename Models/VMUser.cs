using System;
using System.Runtime.Serialization;

namespace Bookstore.Models
{
    [DataContract]
    public class VMUser
    {
        [DataMember]
        public Guid UserID { get; set; }

        [DataMember]
        public string UserName { get; set; }
    }
}