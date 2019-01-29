using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Models
{
    public class Group
    {
        public Group()
        {
            Id = GeneratorId.Generate("group");
            Members = new List<UserGroup>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserGroup> Members { get; set; }
    }
}
