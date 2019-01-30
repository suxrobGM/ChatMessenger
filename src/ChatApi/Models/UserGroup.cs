using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatServer.Models
{
    public class UserGroup
    {
        public string UserId { get; set; }
        public string GroupId { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsOwner { get; set; }

        public virtual User User { get; set; }
        public virtual Group Group { get; set; }
    }
}
