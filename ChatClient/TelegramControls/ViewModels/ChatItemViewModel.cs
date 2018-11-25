using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace TelegramControls.ViewModels
{
    public class ChatItemViewModel : BindableBase
    {
        private string itemName;


        public string ItemName { get => itemName; set { SetProperty(ref itemName, value); } }
    }
}
