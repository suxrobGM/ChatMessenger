using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.Models
{
    public class User
    {
        private string _password { get; set; }

        public User()
        {
            Id = Guid.NewGuid().ToString();
            UserGroups = new List<UserGroup>();
        }

        
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get => _password; set { _password = ComputeHash(value); } }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }

        public virtual ICollection<UserGroup> UserGroups { get; set; }

        private string ComputeHash(string str)
        {
            var sha2 = new SHA256CryptoServiceProvider();
            var hashBytes = sha2.ComputeHash(Encoding.UTF8.GetBytes(str));
            var hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            return hash;
        }
    }
}
