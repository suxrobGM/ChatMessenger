using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApi.v1.Models
{
    public class PersonalPhoto : Photo
    {
        private User owner;
        private ILazyLoader lazyLoader;

        public PersonalPhoto()
        {

        }
        public PersonalPhoto(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }

        public int OwnerId { get; set; }
        public User Owner { get => lazyLoader.Load(this, ref owner); set => owner = value; }
    }
}
