using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using Prism.Mvvm;
using Prism.Commands;
using System.Windows;
using System.Windows.Controls;
using ChatClient.Models;

namespace ChatClient.ViewModels
{
    public class SignUpWindowViewModel : BaseViewModel
    {
        private string username;
        private bool agreementChecked;


        public string Username { get => username; set { SetProperty(ref username, value); RegisterCommand.RaiseCanExecuteChanged(); } }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public bool AgreementChecked { get => agreementChecked; set { SetProperty(ref agreementChecked, value); RegisterCommand.RaiseCanExecuteChanged(); } }
        public DelegateCommand<PasswordBox> RegisterCommand { get; }


        public SignUpWindowViewModel()
        {
            RegisterCommand = new DelegateCommand<PasswordBox>(async (passwordBox) =>
            {
               
                var result = await Model.PrivateApiClient.AddNewUserAsync(new User
                {
                    Username = Username,
                    Password = new System.Net.NetworkCredential(Username, passwordBox.Password).SecurePassword,
                    Email = Email,
                    TelephoneNumber = TelephoneNumber,
                    FirstName = FirstName,
                    LastName = LastName
                });

                if (result == 200)
                    MessageBox.Show("New user has successfully registered!");
                else if (result == 403)
                    MessageBox.Show("Username already exists");
                else if (result == 500)
                    MessageBox.Show("Server internal error");

            }, CanExecuteRegisterCommand);
        }


        private bool CanExecuteRegisterCommand(PasswordBox passwordBox)
        {
            return Username != String.Empty && AgreementChecked;
        }
    }
}
