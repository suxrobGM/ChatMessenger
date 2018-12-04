﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Prism.Mvvm;

namespace ChatClient.Models
{
    public class User : BindableBase
    {
        private string login;
        private SecureString password;
        private string email;
        private string firstName;
        private string lastName;
        private string telephoneNumber;
        private byte[] photo;


        public string Login { get => login; set { SetProperty(ref login, value); } }
        public SecureString Password { get => password; set { SetProperty(ref password, value); } }
        public string Email { get => email; set { SetProperty(ref email, value); } }
        public string FirstName { get => firstName; set { SetProperty(ref firstName, value); } }
        public string LastName { get => lastName; set { SetProperty(ref lastName, value); } }
        public string TelephoneNumber { get => telephoneNumber; set { SetProperty(ref telephoneNumber, value); } }
        public byte[] Photo { get => photo; set { SetProperty(ref photo, value); } }


        public string GetJsonFormat()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("{");
            stringBuilder.Append($"'login': '{Login}',");
            stringBuilder.Append($"'password': '{new NetworkCredential(Login, Password).Password}',");

            if (Email != null)
                stringBuilder.Append($"'email': '{Email}',");
            if(TelephoneNumber != null)
                stringBuilder.Append($"'telephoneNumber': '{TelephoneNumber}',");
            if(FirstName != null)
                stringBuilder.Append($"'firstName': '{FirstName}',");
            if(LastName != null)
                stringBuilder.Append($"'lastName': '{LastName}'");
            if (Photo != null)
                stringBuilder.Append($"'photo': '{ByteToBinaryView(Photo)}'");

            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }

        private string ByteToBinaryView(byte[] bytes)
        {
            var bytesBinary = new StringBuilder();
            foreach (var b in bytes)
            {
                bytesBinary.Append(b.ToString());
            }

            return bytesBinary.ToString();
        }
        /*private byte[] BinariesToByte(string binaryString)
        {

        }*/
    }
}