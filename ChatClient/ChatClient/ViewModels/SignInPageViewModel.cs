using System;
using System.Windows.Controls;
using System.Windows;
using System.Security;
using System.Net;
using Prism.Commands;
using Prism.Regions;
using ChatClient.Views;

namespace ChatClient.ViewModels
{
    public class SignInPageViewModel : BaseViewModel, INavigationAware
    {
        private string loginOrEmail;
        private SecureString password;
        private IRegionManager regionManager;
        private IRegionNavigationJournal regionNavigationJournal;


        public DelegateCommand OpenSignUpWindowCommand { get; }
        public DelegateCommand SignInCommand { get; }
        public DelegateCommand<PasswordBox> PasswordChangedCommand { get; }
        public string LoginOrEmail
        {
            get => loginOrEmail;
            set
            {
                SetProperty(ref loginOrEmail, value);
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
                var result = await Model.PrivateApiClient.CheckUserLoginAsync(new NetworkCredential(loginOrEmail, password));

                if(result)
                {
                    regionManager.RequestNavigate("ContentRegionMainWindow", "MainPage");
                }
                else
                {
                    MessageBox.Show("Login or password is incorrect");
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
            regionNavigationJournal = navigationContext.NavigationService.Journal;
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
            return loginOrEmail != String.Empty && password.Length > 0;
        }
    }
}
