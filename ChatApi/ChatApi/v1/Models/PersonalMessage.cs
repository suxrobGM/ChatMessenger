using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChatApi.v1.Models
{
    public class PersonalMessage : Message
    {        
        public PersonalMessage()
        {

        }       

        public int SenderUserId { get; set; }          
        public int ReceiverUserId { get; set; }        
        public virtual User Sender { get; set; }
        public virtual User Receiver { get; set; }
    }
}
