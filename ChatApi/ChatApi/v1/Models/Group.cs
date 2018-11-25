using System;
using System.Collections.Generic;

namespace ChatApi.v1.Models
{
    public partial class Group
    {
        public Group()
        {
            GroupMember = new HashSet<GroupMember>();
            GroupMessage = new HashSet<GroupMessage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? AdminId { get; set; }
        public int? OwnerId { get; set; }

        public User Admin { get; set; }
        public User Owner { get; set; }
        public ICollection<GroupMember> GroupMember { get; set; }
        public ICollection<GroupMessage> GroupMessage { get; set; }
    }
}
