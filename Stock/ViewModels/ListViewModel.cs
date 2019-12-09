using Stock.DAL;
using Stock.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.ViewModels
{
    class ListViewModel : INotifyPropertyChanged
    {
        public ListViewModel()
        {
            LoadProducts();
        }
        public async void LoadProducts()
        {
            Products = await ProductsAPIDAL.LoadProductsAsync();
        }

        private Product selectedProduct;

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChange("SelectedProduct");
            }
        }
        private List<Product> products;

        public List<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChange("Products");
            }
        }
        public void SearchProducts(int num)
        {
            if (num > 0)
            {
                Products = products.FindAll(
                    delegate (Product product)
                    {
                        if (product.Id == num)
                        {
                            return true;
                        }
                        if (product.Bar_Code.Contains(num.ToString()))
                        {
                            return true;
                        }
                        return false;
                    }
                    );
            } else
            {
                LoadProducts();
            }
        }
        public void ModifySelectedProductStock(int qty)
        {
            selectedProduct.Stock = selectedProduct.Stock + qty;
            OnPropertyChange("SelectedProduct");
        }
        public async void SaveSelectedProduct() {

            var Res = await ProductsAPIDAL.SaveProductAsync(selectedProduct);

        }

        public async void DeleteSelectedProduct()
        {

            var Res = await ProductsAPIDAL.DeleteProductAsync(selectedProduct);

        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
