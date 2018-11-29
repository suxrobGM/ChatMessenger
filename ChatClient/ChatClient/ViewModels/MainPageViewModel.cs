using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Prism.Commands;
using Prism.Regions;
using TelegramControls;
using TelegramControls.Views;

namespace ChatClient.ViewModels
{
    public class MainPageViewModel : BaseViewModel, INavigationAware
    {
        private IRegionManager regionManager;
        private IRegionNavigationJournal _journal;
        private MessageControlState messageControlState;
        private ChatItem selectedChatItem;
        private string groupName;


        public string GroupName
        {
            get => groupName;
            set
            {
                SetProperty(ref groupName, value);
            }
        }
        public MessageControlState MessageControlStateProperty
        {
            get => messageControlState;
            set
            {
                SetProperty(ref messageControlState, value);
            }
        }
        public ChatItem SelectedChatItem
        {
            get => selectedChatItem;
            set
            {
                SetProperty(ref selectedChatItem, value);
                ChangeState(selectedChatItem.ChatItemType);
                GroupName = selectedChatItem.ItemName;
            }
        }
        public string FullName { get => Model.CurrentUser.FirstName + " " + Model.CurrentUser.LastName; }
        public string Email { get => Model.CurrentUser.Email; }
        public string TelephoneNumber { get => Model.CurrentUser.TelephoneNumber; }


        public MainPageViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }


        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
                    
        }
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _journal = navigationContext.NavigationService.Journal;
        }
        private void ChangeState(ChatItemType chatItemType)
        {
            switch (chatItemType)
            {
                case ChatItemType.IsChannelType:
                    {
                        MessageControlStateProperty = MessageControlState.ChannelState;
                        break;
                    }
                    
                case ChatItemType.IsPersonalChattingType:
                    {
                        MessageControlStateProperty = MessageControlState.GroupChattingState;
                        break;
                    }
                                       
                case ChatItemType.IsGroupChattingType:
                    {
                        MessageControlStateProperty = MessageControlState.UserChattingState;
                        break;
                    }                  
                default:
                    break;
            }          
        }
    }
}
