using Stock.Models;
using Stock.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Logique d'interaction pour List.xaml
    /// </summary>
    public partial class List : Page
    {
        private readonly ListViewModel _viewModel;

        public List()
        {
            InitializeComponent();
            _viewModel = new ListViewModel();
            DataContext = _viewModel;
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            _viewModel.SaveSelectedProduct();
            _viewModel.LoadProducts();
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            _viewModel.DeleteSelectedProduct();
            _viewModel.LoadProducts();

        }

        private void Button_Plus(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.ModifySelectedProductStock(1);
            }
            catch
            {

            }
        }
        private void Button_Minus(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.ModifySelectedProductStock(-1);
            }
            catch
            {

            }
        }
        private void Search(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            if (!e.Handled)
            {
                try
                {
                    _viewModel.SearchProducts(int.Parse(e.Text));

                }
                catch
                {

                }


            } else
            {
                try
                {
                    _viewModel.SearchProducts(0);

                }
                catch
                {

                }
            }

        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            string theText = textBox.Text.TrimEnd('\r', '\n');


            if (theText != null && theText != "")
            {

                _viewModel.SearchProducts(int.Parse(theText));

            } else
            {
                _viewModel.SearchProducts(0);
            }
        }
    }
}
