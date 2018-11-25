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
    /// Логика взаимодействия для ExpanderView.xaml
    /// </summary>
    public partial class ExpanderView : UserControl
    {
        public ExpanderView()
        {
            InitializeComponent();
        }

        #region DependencyProperties
        public static readonly DependencyProperty FullNameProperty = DependencyProperty.Register("FullName", typeof(string), typeof(ExpanderView), new PropertyMetadata(null, OnFullNamePropertyChanged));
        public static readonly DependencyProperty EmailProperty = DependencyProperty.Register("Email", typeof(string), typeof(ExpanderView), new PropertyMetadata(null, OnEmailPropertyChanged));   
        public static readonly DependencyProperty TelephoneNumberProperty = DependencyProperty.Register("TelephoneNumber", typeof(string), typeof(ExpanderView), new PropertyMetadata(null, OnTelephoneNumberPropertyChanged));       


        private static void OnFullNamePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var expanderView = d as ExpanderView;
            (expanderView.DataContext as ExpanderViewModel).FullName = e.NewValue as string;
        }
        private static void OnEmailPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var expanderView = d as ExpanderView;
            (expanderView.DataContext as ExpanderViewModel).Email = e.NewValue as string;
        }
        private static void OnTelephoneNumberPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var expanderView = d as ExpanderView;
            (expanderView.DataContext as ExpanderViewModel).TelephoneNumber = e.NewValue as string;
        }


        [Category("Common")]
        public string FullName
        {
            get { return (string)GetValue(FullNameProperty); }
            set { SetValue(FullNameProperty, value); }
        }

        [Category("Common")]
        public string Email
        {
            get { return (string)GetValue(EmailProperty); }
            set { SetValue(EmailProperty, value); }
        }

        [Category("Common")]
        public string TelephoneNumber
        {
            get { return (string)GetValue(TelephoneNumberProperty); }
            set { SetValue(TelephoneNumberProperty, value); }
        }
        #endregion
    }
}
