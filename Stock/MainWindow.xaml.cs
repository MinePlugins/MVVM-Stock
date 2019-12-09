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

namespace Stock
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new List();
        }

        private void MenuItem_Click_List(object sender, RoutedEventArgs e)
        {
            Main.Content = new List();
        }
        private void MenuItem_Click_Main(object sender, RoutedEventArgs e)
        {
            Main.Content = new Add();
        }
    }
}
