using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestEntityFrameworkCore.Models
{
    public class UserGroup
    {
        private User user;
        private Group group;
        private ILazyLoader lazyLoader;

        public UserGroup()
        {

        }
        public UserGroup(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }

        public int UserId { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsOwnerGroup { get; set; }
        public User User { get => lazyLoader.Load(this, ref user); set => user = value; }

        public int GroupId { get; set; }
        public Group Group { get => lazyLoader.Load(this, ref group); set => group = value; }
    }
}
