using Newtonsoft.Json;
using Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Stock.DAL
{
    class ProductsAPIDAL
    {
        const string PRODUCT_API_URL = "http://127.0.0.1:5000/";
        public static async Task<List<Product>> LoadProductsAsync()
        {

            WebClient wc = new WebClient();
            byte[] data = await wc.DownloadDataTaskAsync(new Uri(PRODUCT_API_URL));
            string json = Encoding.UTF8.GetString(data);
            ProductData result = JsonConvert.DeserializeObject<ProductData>(json);

            return result.Results;
        }

        public static async Task<String> SaveProductAsync(Product product)
        {
            const string PRODUCT_API_URL = "http://127.0.0.1:5000/";

            WebClient wc = new WebClient();
            byte[] data = await wc.UploadDataTaskAsync(new Uri(PRODUCT_API_URL), "PUT", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(product)));
            string json = Encoding.UTF8.GetString(data);
            return json;
        }
        public static async Task<String> DeleteProductAsync(Product product)
        {
            const string PRODUCT_API_URL = "http://127.0.0.1:5000/";

            WebClient wc = new WebClient();
            byte[] data = await wc.UploadDataTaskAsync(new Uri(PRODUCT_API_URL), "DELETE", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(product)));
            string json = Encoding.UTF8.GetString(data);
            return json;
        }
        public static async Task<String> AddProductAsync(Product product)
        {
            const string PRODUCT_API_URL = "http://127.0.0.1:5000/";

            WebClient wc = new WebClient();
            byte[] data = await wc.UploadDataTaskAsync(new Uri(PRODUCT_API_URL), "POST", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(product)));
            string json = Encoding.UTF8.GetString(data);
            return json;
        }
    }
}
