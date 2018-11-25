using System;
using System.Collections.Generic;

namespace ChatApi.v1.Models
{
    public partial class GroupMessageState
    {
        public int GroupMessageId { get; set; }
        public int UserId { get; set; }
        public bool? IsRead { get; set; }
        public bool? IsNotified { get; set; }

        public GroupMessage GroupMessage { get; set; }
        public User User { get; set; }
    }
}
