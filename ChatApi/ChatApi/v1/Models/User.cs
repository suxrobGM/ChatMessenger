using System;
using System.Collections.Generic;
using System.Security;

namespace ChatApi.v1.Models
{
    public partial class User
    {
        public User()
        {
            GroupAdmin = new HashSet<Group>();
            GroupMessage = new HashSet<GroupMessage>();
            GroupMessageState = new HashSet<GroupMessageState>();
            GroupOwner = new HashSet<Group>();
            PersonalMessageReceivedUser = new HashSet<PersonalMessage>();
            PersonalMessageSenderUser = new HashSet<PersonalMessage>();
            PersonalMessageState = new HashSet<PersonalMessageState>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? MainPhotoId { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public Photo MainPhoto { get; set; }
        public GroupMember GroupMember { get; set; }
        public ICollection<Group> GroupAdmin { get; set; }
        public ICollection<GroupMessage> GroupMessage { get; set; }
        public ICollection<GroupMessageState> GroupMessageState { get; set; }
        public ICollection<Group> GroupOwner { get; set; }
        public ICollection<PersonalMessage> PersonalMessageReceivedUser { get; set; }
        public ICollection<PersonalMessage> PersonalMessageSenderUser { get; set; }
        public ICollection<PersonalMessageState> PersonalMessageState { get; set; }
    }
}
