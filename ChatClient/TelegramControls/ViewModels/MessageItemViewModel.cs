using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramControls.ViewModels
{
    public class MessageItemViewModel
    {
        public string UserName { get; set; }
        public string MessageText { get; set; }
        public string MessageTime { get => DateTime.Now.ToShortTimeString(); }
    }
}
