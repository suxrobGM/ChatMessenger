using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer.Models
{
    public class User
    {
        private string _passwordHash { get; set; }

        public User()
        {
            Id = Guid.NewGuid().ToString().Replace("-","");
            UserGroups = new List<UserGroup>();
            RegistrationDate = DateTime.Now;
        }

        
        public string Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get => _passwordHash; set { _passwordHash = ComputeHash_Sha2(value); } }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public virtual ICollection<UserGroup> UserGroups { get; set; }

        public bool CheckPassword(string password)
        {
            return ComputeHash_Sha2(password) == _passwordHash;
        }

        private string ComputeHash_Sha2(string str)
        {
            var sha2 = new SHA256CryptoServiceProvider();
            var hashBytes = sha2.ComputeHash(Encoding.UTF8.GetBytes(str));
            var hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            return hash;
        }
    }
}
