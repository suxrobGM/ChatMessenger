﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatServer.Models
{
    public class Message
    {
        public Message()
        {

        }

        public string Id { get; set; }

        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        public bool IsRead { get; set; }
    }
}
