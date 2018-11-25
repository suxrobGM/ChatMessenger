using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Models.ApiClient
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }
        public string GetJsonFormat()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("{");
            stringBuilder.Append($"'login': '{Login}',");
            stringBuilder.Append($"'password': '{Password}',");

            if (Email != null)
                stringBuilder.Append($"'email': '{Email}',");
            if(TelephoneNumber != null)
                stringBuilder.Append($"'telephoneNumber': '{TelephoneNumber}',");
            if(FirstName != null)
                stringBuilder.Append($"'firstName': '{FirstName}',");
            if(LastName != null)
                stringBuilder.Append($"'lastName': '{LastName}'");

            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }
    }
}
