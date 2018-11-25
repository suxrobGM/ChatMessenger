using System;
using System.Collections.Generic;

namespace ChatApi.v1.Models
{
    public partial class Photo
    {
        public Photo()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public byte[] PhotoBinary { get; set; }

        public ICollection<User> User { get; set; }
    }
}
