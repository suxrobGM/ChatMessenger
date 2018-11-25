using System;
using System.Collections.Generic;

namespace ChatApi.v1.Models
{
    public partial class PersonalMessage
    {
        public int Id { get; set; }
        public int SenderUserId { get; set; }
        public int ReceivedUserId { get; set; }
        public string Text { get; set; }

        public User ReceivedUser { get; set; }
        public User SenderUser { get; set; }
        public PersonalMessageState PersonalMessageState { get; set; }
    }
}
