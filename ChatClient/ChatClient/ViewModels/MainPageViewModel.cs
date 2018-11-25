using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ChatClient.ViewModels
{
    public class MainPageViewModel : BaseViewModel, INavigationAware
    {
        private IRegionManager regionManager;
        private IRegionNavigationJournal regionNavigationJournal;

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
    }
}
