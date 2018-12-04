using System;
using System.Collections.Generic;
using System.Text;

namespace TestEntityFrameworkCore.Models
{
    public abstract class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsRead { get; set; }
    }
}
