﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TestEntityFrameworkCore.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public byte[] PhotoBinary { get; set; }
    }
}
