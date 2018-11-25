using System;
using System.Collections.Generic;

namespace ChatApi.v1.Models
{
    public partial class PersonalMessageState
    {
        public int PersonalMessageId { get; set; }
        public int UserId { get; set; }
        public bool? IsRead { get; set; }
        public bool? IsNotified { get; set; }

        public PersonalMessage PersonalMessage { get; set; }
        public User User { get; set; }
    }
}
