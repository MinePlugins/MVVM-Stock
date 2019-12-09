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
    class AddViewModel : INotifyPropertyChanged
    {
        public AddViewModel()
        {
        }
       
        private Product product  = new Product();

        public Product Product
        {
            get { return product; }
            set
            {
                product = value;
                OnPropertyChange("Product");
            }
        }
      
        public async void AddProduct()
        {

            var Res = await ProductsAPIDAL.AddProductAsync(product);

        }
        public void ModifyProductStock(int qty)
        {
            product.Stock = product.Stock + qty;
            OnPropertyChange("Product");
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
