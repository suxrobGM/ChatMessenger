﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatCore.Models.Utils;

namespace ChatCore.Models
{
    public class Group
    {
        public Group()
        {
            Id = GeneratorId.Generate("group");
            UserGroups = new List<UserGroup>();
            Messages = new List<GroupMessage>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GroupMessage> Messages { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }

        public IEnumerable<User> GetAdmin()
        {
            return UserGroups.Where(i => i.IsAdmin).Select(i => i.User);
        }

        public User GetOwner()
        {
            return UserGroups.Where(i => i.IsOwner).Select(i => i.User).FirstOrDefault();
        }

        public int GetMembersCount()
        {
            return UserGroups.Select(i => i.User).Count();
        }
    }
}
