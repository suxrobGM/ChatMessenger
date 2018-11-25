using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using ChatClient.Views;
using ChatClient.Models;

namespace ChatClient.ViewModels
{
    public class BaseViewModel : BindableBase
    {     
        protected SingletonModel model;

        public BaseViewModel()
        {
            model = SingletonModel.GetInstance();         
        }        
    }
}
