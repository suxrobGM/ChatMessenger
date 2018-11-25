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
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class MessageControl : UserControl
    {
        private MessageControlViewModel viewModel;

        public MessageControl()
        {
            InitializeComponent();
            viewModel = new MessageControlViewModel();
            this.DataContext = viewModel;
        }

        #region Dependency Properties
        public static readonly DependencyProperty ControlStateProperty = DependencyProperty.Register("ControlState", typeof(MessageControlState), typeof(MessageControl), new PropertyMetadata(MessageControlState.WelcomeState, ControlStatePropertyChanged));
        public static readonly DependencyProperty BackgroundImageSourceProperty = DependencyProperty.Register("BackgroundImageSource", typeof(string), typeof(MessageControl), new PropertyMetadata(null, OnDependencyPropertyChanged));

        [Category("Common")]
        public string BackgroundImageSource
        {
            get { return GetValue(BackgroundImageSourceProperty) as string; }
            set { SetValue(BackgroundImageSourceProperty, value); }
        }

        [Category("Common")]
        public MessageControlState ControlState
        {
            get { return (MessageControlState)GetValue(ControlStateProperty); }
            set { SetValue(ControlStateProperty, value); }
        }

        private static void OnDependencyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MessageControl)d).viewModel.BackgroundImageSource = e.NewValue as string;
        }             

        private static void ControlStatePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MessageControl)d).viewModel.ControlState = (MessageControlState)e.NewValue;

            //ChangeState(ControlState);
        }

        private void ChangeState(MessageControlState controlState)
        {
            switch (controlState)
            {
                case MessageControlState.WelcomeState:
                    {
                        topBarGrid.Visibility = Visibility.Hidden;
                        keyboardDockPanel.Visibility = Visibility.Hidden;
                        break;
                    }
                   
                case MessageControlState.UserChattingState:
                    {
                        topBarGrid.Visibility = Visibility.Visible;
                        keyboardDockPanel.Visibility = Visibility.Visible;
                        break;
                    }
                    
                case MessageControlState.GroupChattingState:
                    {
                        topBarGrid.Visibility = Visibility.Visible;
                        keyboardDockPanel.Visibility = Visibility.Visible;
                        break;
                    }
                    
                case MessageControlState.ChannelState:
                    {
                        topBarGrid.Visibility = Visibility.Visible;
                        keyboardDockPanel.Visibility = Visibility.Hidden;
                        break;
                    }
                    
                default:
                    break;
            }
        }
        #endregion

    }
}
