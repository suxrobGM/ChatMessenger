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
using ChatClient.Models.ApiClient;

namespace ChatClient.ViewModels
{
    public class SignUpWindowViewModel : BaseViewModel
    {
        private string login;
        private bool agreementChecked;


        public string Login { get => login; set { SetProperty(ref login, value); RegisterCommand.RaiseCanExecuteChanged(); } }
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
               
                var result = await model.PrivateApiClient.AddNewUserAsync(new User
                {
                    Login = Login,
                    Password = passwordBox.Password,
                    Email = Email,
                    TelephoneNumber = TelephoneNumber,
                    FirstName = FirstName,
                    LastName = LastName
                });

                if (result == 200)
                    MessageBox.Show("New user has successfully registered!");
                else if (result == 403)
                    MessageBox.Show("Login already exists");
                else if (result == 500)
                    MessageBox.Show("Server internal error");

            }, CanExecuteRegisterCommand);
        }


        private bool CanExecuteRegisterCommand(PasswordBox passwordBox)
        {
            return Login != String.Empty && AgreementChecked;
        }
    }
}
