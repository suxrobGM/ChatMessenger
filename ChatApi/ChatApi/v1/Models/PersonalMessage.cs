using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChatApi.v1.Models
{
    public class PersonalMessage : Message
    {
        private User receiver;
        private User sender;
        private ILazyLoader lazyLoader;

        public PersonalMessage()
        {

        }
        public PersonalMessage(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }

        public int SenderUserId { get; set; }
        public User Sender { get => lazyLoader.Load(this, ref sender); set => sender = value; }
     
        public int ReceiverUserId { get; set; }
        public User Receiver { get => lazyLoader.Load(this, ref receiver); set => receiver = value; }
    }
}
