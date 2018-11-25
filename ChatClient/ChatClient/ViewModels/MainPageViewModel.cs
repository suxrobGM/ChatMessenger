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
        private IRegionNavigationJournal regionNavigationJournal;
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
            regionNavigationJournal = navigationContext.NavigationService.Journal;
        }
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            
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
