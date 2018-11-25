using System;
using System.Collections.Generic;
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

namespace ChatClient.Views
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            (sender as Expander).Height = 40;
            (sender as Expander).Width = 40;
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            (sender as Expander).Height = 460;
            (sender as Expander).Width = 210;
        }
    }
}
