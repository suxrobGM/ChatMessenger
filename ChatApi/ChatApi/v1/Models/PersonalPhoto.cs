using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApi.v1.Models
{
    public class PersonalPhoto : Photo
    {        
        public PersonalPhoto()
        {

        }      

        public int OwnerId { get; set; }      
        public virtual User Owner { get; set; }
    }
}
