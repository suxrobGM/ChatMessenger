using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatApi.v1.Models
{
    public class Group
    {      
        private ICollection<UserGroup> userGroups;
        private ICollection<GroupMessage> groupMessages;       
        private ILazyLoader lazyLoader;

        public Group()
        {
            UserGroups = new List<UserGroup>();
            GroupMessages = new List<GroupMessage>();          
        }
        public Group(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }

        public int Id { get; set; }
        public string Name { get; set; }             
        public ICollection<UserGroup> UserGroups { get => lazyLoader.Load(this, ref userGroups); set => userGroups = value; }
        public ICollection<GroupMessage> GroupMessages { get => lazyLoader.Load(this, ref groupMessages); set => groupMessages = value; }
        
        public IEnumerable<User> GetAdmins()
        {
            return UserGroups.Where(u => u.IsAdmin == true).Select(u => u.User);
        }
        public User GetOwner()
        {
            return UserGroups.Where(u => u.IsOwnerGroup && u.GroupId == Id).Select(u => u.User).FirstOrDefault();
        }
    }
}
