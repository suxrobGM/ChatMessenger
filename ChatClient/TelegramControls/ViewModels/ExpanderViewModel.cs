using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramControls.ViewModels
{
    public class ExpanderViewModel : BindableBase
    {
        private string fullName;
        private string email;
        private string telephoneNumber;
        private string exitViewSource;
        private string exitViewRegionName;
        private IRegionManager regionManager;

        public string FullName { get => fullName; set { SetProperty(ref fullName, value); } }
        public string Email { get => email; set { SetProperty(ref email, value); } }
        public string TelephoneNumber { get => telephoneNumber; set { SetProperty(ref telephoneNumber, value); } }
        public string ExitViewSource { get => exitViewSource; set { SetProperty(ref exitViewSource, value); } }
        public string ExitViewRegionName { get => exitViewRegionName; set { SetProperty(ref exitViewRegionName, value); } }
        public DelegateCommand ExitCommand { get; }


        public ExpanderViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

            ExitCommand = new DelegateCommand(() =>
            {
                regionManager.RequestNavigate(ExitViewRegionName, ExitViewSource);
            });
        }      
    }
}
