using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramControls.Views;
using Prism.Mvvm;
using Prism.Commands;

namespace TelegramControls.ViewModels
{
    public enum MessageControlState
    {
        WelcomeState,
        UserChattingState,
        GroupChattingState,
        ChannelState
    }

    public class MessageControlViewModel : BindableBase
    {
        private string typingMessage;
        private MessageControlState messageControlState;

        public string BackgroundImageSource { get; set; }
        public string GroupName { get; set; }
        public string TypingMessage { get => typingMessage; set { typingMessage = value; RaisePropertyChanged("TypingMessage"); } }
        public int GroupMembers { get; set; }
        public MessageControlState ControlState { get => messageControlState; set { messageControlState = value; RaisePropertyChanged("ControlState"); } }
        public ObservableCollection<MessageItem> StackMessages { get; set; }
        public DelegateCommand EnterKeyCommand { get; }

        public MessageControlViewModel()
        {
            StackMessages = new ObservableCollection<MessageItem>();
            ControlState = MessageControlState.WelcomeState;

            EnterKeyCommand = new DelegateCommand(() =>
            {
                if (TypingMessage == String.Empty)
                    return;

                StackMessages.Add(new MessageItem() { MessageText = TypingMessage, });
                TypingMessage = String.Empty;
            });
        }
    }
}
