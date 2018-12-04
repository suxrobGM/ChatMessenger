using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApi.v1.Models
{
    public abstract class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsRead { get; set; }
    }
}
