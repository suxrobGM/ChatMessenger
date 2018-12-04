using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApi.v1.Models
{
    public class UserGroup
    {    
        public UserGroup()
        {

        }      

        public int UserId { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsOwnerGroup { get; set; }      
        public int GroupId { get; set; }     
        public virtual User User { get; set; }
        public virtual Group Group { get; set; }
    }
}
