using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApi.v1.Models
{
    public class GroupMessage : Message
    {   
        public GroupMessage()
        {

        }       

        public int GroupId { get; set; }      

        public int GroupSenderUserId { get; set; }      
        public virtual Group Group { get; set; }
        public virtual User Sender { get; set; }
    }
}
