using Stock.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logique d'interaction pour Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        private readonly AddViewModel _viewModel;
        public Add()
        {
            InitializeComponent();
            _viewModel = new AddViewModel();
            DataContext = _viewModel;
        }
        private void Button_Add(object sender, RoutedEventArgs e)
        {
            _viewModel.AddProduct();
        }
        private void Button_Plus(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.ModifyProductStock(1);
            }
            catch
            {

            }
        }
        private void Button_Minus(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.ModifyProductStock(-1);
            }
            catch
            {

            }
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
