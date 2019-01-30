using ChatCore.Models.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatCore.Models
{
    public class Media
    {
        public Media()
        {
            Id = GeneratorId.Generate("media");
        }

        public string Id { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}
