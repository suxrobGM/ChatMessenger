using System;
using System.Collections.Generic;
using System.Text;

namespace ChatCore.Models
{
    public class GroupMessage : Message
    {
        public string GroupId { get; set; }

        public virtual Group Group { get; set; }
    }
}
