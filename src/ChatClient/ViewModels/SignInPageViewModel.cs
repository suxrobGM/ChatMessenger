using System;
using System.Windows.Controls;
using System.Windows;
using System.Security;
using System.Net;
using Prism.Commands;
using Prism.Regions;
using ChatClient.Views;
using ChatCore.Api;

namespace ChatClient.ViewModels
{
    public class SignInPageViewModel : BaseViewModel, INavigationAware
    {
        private string username;
        private SecureString password;
        private IRegionManager regionManager;
        private IRegionNavigationJournal _journal;


        public DelegateCommand OpenSignUpWindowCommand { get; }
        public DelegateCommand SignInCommand { get; }
        public DelegateCommand<PasswordBox> PasswordChangedCommand { get; }
        public string Username
        {
            get => username;
            set
            {
                SetProperty(ref username, value);
                SignInCommand.RaiseCanExecuteChanged();
            }
        }              


        public SignInPageViewModel(IRegionManager regionManager) 
        {
            this.regionManager = regionManager;
            this.password = new SecureString();

            OpenSignUpWindowCommand = new DelegateCommand(() =>
            {             
                var signUpWindow = new SignUpWindow();
                signUpWindow.ShowDialog();
            });

            SignInCommand = new DelegateCommand(async () =>
            {
                var client = new ChatApiClient();
                var result = await client.CheckUserExists(new NetworkCredential(username, password));

                if(result)
                {
                    regionManager.RequestNavigate("ContentRegionMainWindow", "MainPage");
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect");
                }
            }, 
                CanExecuteSignInCommand
            );

            PasswordChangedCommand = new DelegateCommand<PasswordBox>(passbox =>
            {
                password.Clear();

                foreach (var c in passbox.Password)
                {
                    password.AppendChar(c);
                }
                SignInCommand.RaiseCanExecuteChanged();
            });
        }

        
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _journal = navigationContext.NavigationService.Journal;
        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }
        private bool CanExecuteSignInCommand()
        {
            return username != String.Empty && password.Length > 0;
        }
    }
}
