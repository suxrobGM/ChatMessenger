using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramControls.Views;
using Prism.Mvvm;
using Prism.Commands;

namespace TelegramControls
{
    public enum MessageControlState
    {
        WelcomeState,
        UserChattingState,
        GroupChattingState,
        ChannelState
    }

    public enum ChatItemType
    {
        IsChannelType,
        IsPersonalChattingType,
        IsGroupChattingType
    }
}

namespace TelegramControls.ViewModels
{    
    public class MessageControlViewModel : BindableBase
    {
        private string typingMessage;
        private string groupName;
        private int groupMembers;

       
        public string GroupName { get => groupName; set { SetProperty(ref groupName, value); } }
        public string TypingMessage { get => typingMessage; set { SetProperty(ref typingMessage, value); } }
        public int GroupMembers { get => groupMembers; set { SetProperty(ref groupMembers, value); } }       
        public ObservableCollection<MessageItem> StackMessages { get; set; }
        public DelegateCommand EnterKeyCommand { get; }


        public MessageControlViewModel()
        {
            StackMessages = new ObservableCollection<MessageItem>();          

            EnterKeyCommand = new DelegateCommand(() =>
            {
                if (TypingMessage == String.Empty)
                    return;

                StackMessages.Add(new MessageItem() { MessageText = TypingMessage });
                TypingMessage = String.Empty;
            });
        }
    }
}
