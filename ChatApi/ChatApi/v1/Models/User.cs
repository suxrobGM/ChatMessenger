using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ChatApi.v1.Models
{
    public class User
    {      
        public User()
        {
            SentPersonalMessages = new List<PersonalMessage>();
            RecievedPersonalMessages = new List<PersonalMessage>();
            GroupMessages = new List<GroupMessage>();
            UserGroups = new List<UserGroup>();           
            Photos = new List<PersonalPhoto>();
        }               
        
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime? RegistrationDate { get; set; }      

        public virtual ICollection<PersonalMessage> SentPersonalMessages { get; set; }
        public virtual ICollection<PersonalMessage> RecievedPersonalMessages { get; set; }
        public virtual ICollection<GroupMessage> GroupMessages { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
        public virtual ICollection<PersonalPhoto> Photos { get; set; }

        public PersonalPhoto GetMainPhoto()
        {
            return Photos.LastOrDefault();
        }
    }
}
