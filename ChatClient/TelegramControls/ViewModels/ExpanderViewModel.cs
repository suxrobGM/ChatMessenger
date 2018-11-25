using Prism.Mvvm;
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

        public string FullName { get => fullName; set { SetProperty(ref fullName, value); } }
        public string Email { get => email; set { SetProperty(ref email, value); } }
        public string TelephoneNumber { get => telephoneNumber; set { SetProperty(ref telephoneNumber, value); } }
    }
}
