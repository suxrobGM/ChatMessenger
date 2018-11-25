using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TelegramControls.ViewModels;

namespace TelegramControls.Views
{
    /// <summary>
    /// Логика взаимодействия для MessageItem.xaml
    /// </summary>
    public partial class MessageItem : UserControl
    {      
        public MessageItem()
        {
            InitializeComponent();            
        }

        #region Dependency Properties
        public static readonly DependencyProperty UserNameProperty = DependencyProperty.Register("UserName", typeof(string), typeof(MessageItem), new PropertyMetadata(null, OnUserNamePropertyChanged));
        public static readonly DependencyProperty MessageTextProperty = DependencyProperty.Register("MessageText", typeof(string), typeof(MessageItem), new PropertyMetadata(null, OnMessageTextPropertyChanged));

        [Category("Common")]
        public string UserName
        {
            get { return GetValue(UserNameProperty) as string; }
            set { SetValue(UserNameProperty, value); }
        }

        [Category("Common")]
        public string MessageText
        {
            get { return GetValue(MessageTextProperty) as string; }
            set { SetValue(MessageTextProperty, value); }
        }

        private static void OnMessageTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (((MessageItem)d).DataContext as MessageItemViewModel).MessageText = e.NewValue as string;
        }
        private static void OnUserNamePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (((MessageItem)d).DataContext as MessageItemViewModel).UserName = e.NewValue as string;
        }
        #endregion
    }
}
