using ChatCore.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatCore.Models
{
    public class Message
    {
        public Message()
        {
            Id = GeneratorId.Generate("msg");
        }

        public string Id { get; set; }
        public string SenderId { get; set; }
        public string Text { get; set; }
        public bool IsRead { get; set; }

        public virtual User Sender { get; set; }
    }
}
