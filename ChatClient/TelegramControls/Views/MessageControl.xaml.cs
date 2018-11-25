using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TelegramControls.ViewModels;

namespace TelegramControls.Views
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class MessageControl : UserControl
    {     
        public MessageControl()
        {
            InitializeComponent();           
        }

        #region Dependency Properties
        public static readonly DependencyProperty ControlStateProperty = DependencyProperty.Register("ControlState", typeof(MessageControlState), typeof(MessageControl), new PropertyMetadata(MessageControlState.WelcomeState, OnMessageControlStatePropertyChanged));
        public static readonly DependencyProperty GroupNameProperty = DependencyProperty.Register("GroupName", typeof(string), typeof(MessageControl), new PropertyMetadata(null, OnGroupNamePropertyChanged));

        private static void OnMessageControlStatePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var messageControl = d as MessageControl;
            messageControl.ChangeState((MessageControlState)e.NewValue);
        }
       
        private static void OnGroupNamePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var messageControl = d as MessageControl;
            (messageControl.DataContext as MessageControlViewModel).GroupName = e.NewValue as string;
        }

        [Category("Common")]
        public MessageControlState ControlState
        {
            get { return (MessageControlState)GetValue(ControlStateProperty); }
            set { SetValue(ControlStateProperty, value); }
        }

        [Category("Common")]
        public string GroupName
        {
            get { return (string)GetValue(GroupNameProperty); }
            set { SetValue(GroupNameProperty, value); }
        }
              
        private void ChangeState(MessageControlState controlState)
        {
            switch (controlState)
            {
                case MessageControlState.WelcomeState:
                    {
                        topBarGrid.Visibility = Visibility.Collapsed;
                        keyboardDockPanel.Visibility = Visibility.Collapsed;
                        break;
                    }
                   
                case MessageControlState.UserChattingState:
                    {
                        topBarGrid.Visibility = Visibility.Visible;
                        keyboardDockPanel.Visibility = Visibility.Visible;
                        welcomeLabel.Visibility = Visibility.Collapsed;
                        break;
                    }
                    
                case MessageControlState.GroupChattingState:
                    {
                        topBarGrid.Visibility = Visibility.Visible;
                        keyboardDockPanel.Visibility = Visibility.Visible;
                        welcomeLabel.Visibility = Visibility.Collapsed;
                        break;
                    }
                    
                case MessageControlState.ChannelState:
                    {
                        topBarGrid.Visibility = Visibility.Visible;
                        keyboardDockPanel.Visibility = Visibility.Collapsed;
                        welcomeLabel.Visibility = Visibility.Collapsed;
                        break;
                    }
                    
                default:
                    break;
            }
        }       
        #endregion

    }
}
