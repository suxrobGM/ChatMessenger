using System;
using System.Collections.Generic;

namespace ChatApi.v1.Models
{
    public partial class GroupMessage
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }

        public Group Group { get; set; }
        public User User { get; set; }
        public GroupMessageState GroupMessageState { get; set; }
    }
}
