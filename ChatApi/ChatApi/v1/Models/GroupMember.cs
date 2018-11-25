using System;
using System.Collections.Generic;

namespace ChatApi.v1.Models
{
    public partial class GroupMember
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }

        public Group Group { get; set; }
        public User User { get; set; }
    }
}
