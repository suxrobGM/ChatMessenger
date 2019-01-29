using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using ChatClient.Models;

namespace ChatClient.ViewModels
{
    public class BaseViewModel : BindableBase
    {     
        protected SingletonModel Model;


        public BaseViewModel()
        {
            Model = SingletonModel.GetInstance();         
        }        
    }
}
