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
    /// Логика взаимодействия для ChatItem.xaml
    /// </summary>
    public partial class ChatItem : UserControl
    {
        public ChatItem()
        {
            InitializeComponent();
        }

        #region Dependency Properties
        public static readonly DependencyProperty ChatItemTypeProperty = DependencyProperty.Register("ChatItemType", typeof(ChatItemType), typeof(ChatItem), new PropertyMetadata(ChatItemType.IsGroupChattingType));
        public static readonly DependencyProperty ItemNameProperty = DependencyProperty.Register("ItemName", typeof(string), typeof(ChatItem), new PropertyMetadata(null, OnItemNamePropertyChanged));

        private static void OnItemNamePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var chatItem = d as ChatItem;
            (chatItem.DataContext as ChatItemViewModel).ItemName = e.NewValue as string;            
        }      

        [Category("Common")]
        public string ItemName
        {
            get { return (string)GetValue(ItemNameProperty); }
            set { SetValue(ItemNameProperty, value); }
        }

        [Category("Common")]
        public ChatItemType ChatItemType
        {
            get { return (ChatItemType)GetValue(ChatItemTypeProperty); }
            set { SetValue(ChatItemTypeProperty, value); }
        }       
        #endregion
    }
}
