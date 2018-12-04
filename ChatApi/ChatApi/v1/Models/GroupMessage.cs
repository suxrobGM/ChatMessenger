using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApi.v1.Models
{
    public class GroupMessage : Message
    {
        private Group group;
        private User sender;
        private ILazyLoader lazyLoader;

        public GroupMessage()
        {

        }
        public GroupMessage(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }

        public int GroupId { get; set; }
        public Group Group { get => lazyLoader.Load(this, ref group); set => group = value; }

        public int GroupSenderUserId { get; set; }
        public User Sender { get => lazyLoader.Load(this, ref sender); set => sender = value; }
    }
}
