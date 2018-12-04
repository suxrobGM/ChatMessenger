using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TestEntityFrameworkCore.Models
{
    public class User
    {
        private ICollection<PersonalMessage> sentPersonalMessages;
        private ICollection<PersonalMessage> recievedPersonalMessages;
        private ICollection<GroupMessage> groupMessages;
        private ICollection<UserGroup> userGroups;
        private ICollection<PersonalPhoto> photos;
        private ILazyLoader lazyLoader;

        public User()
        {
            SentPersonalMessages = new List<PersonalMessage>();
            RecievedPersonalMessages = new List<PersonalMessage>();
            GroupMessages = new List<GroupMessage>();
            UserGroups = new List<UserGroup>();           
            Photos = new List<PersonalPhoto>();
        }
        public User(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }       
        
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public ICollection<PersonalMessage> SentPersonalMessages { get => lazyLoader.Load(this, ref sentPersonalMessages); set => sentPersonalMessages = value; }
        public ICollection<PersonalMessage> RecievedPersonalMessages { get => lazyLoader.Load(this, ref recievedPersonalMessages); set => recievedPersonalMessages = value; }
        public ICollection<GroupMessage> GroupMessages { get => lazyLoader.Load(this, ref groupMessages); set => groupMessages = value; }       
        public ICollection<UserGroup> UserGroups { get => lazyLoader.Load(this, ref userGroups); set => userGroups = value; }
        public ICollection<PersonalPhoto> Photos { get => lazyLoader.Load(this, ref photos); set => photos = value; }
        
        public PersonalPhoto GetMainPhoto()
        {
            return Photos.FirstOrDefault();
        }
    }
}
