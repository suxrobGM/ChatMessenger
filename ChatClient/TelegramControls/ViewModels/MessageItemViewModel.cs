using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;


namespace TelegramControls.ViewModels
{
    public class MessageItemViewModel : BindableBase
    {
        private string userName;
        private string messageText;


        public string UserName { get => userName; set { SetProperty(ref userName, value); } }
        public string MessageText { get => messageText; set { SetProperty(ref messageText, value); } }
        public string MessageTime { get => DateTime.Now.ToShortTimeString(); }
    }
}
