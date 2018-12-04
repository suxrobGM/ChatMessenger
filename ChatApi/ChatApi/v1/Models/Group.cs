using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatApi.v1.Models
{
    public class Group
    {            
        public Group()
        {
            UserGroups = new List<UserGroup>();
            GroupMessages = new List<GroupMessage>();          
        }      


        public int Id { get; set; }
        public string Name { get; set; }      
        public virtual ICollection<UserGroup> UserGroups { get; set; }
        public virtual ICollection<GroupMessage> GroupMessages { get; set; }


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
