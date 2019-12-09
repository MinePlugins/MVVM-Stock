using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Stock.Models
{
    public class ProductData
    {
        public List<Product> Results { get; set; }
    }
    public class Product
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Bar_Code { get; set; }
        public BitmapImage Bar_Code_Img {
            get
            {
                try
                {
                    BarcodeLib.Barcode b = new BarcodeLib.Barcode();
                    Image img = b.Encode(BarcodeLib.TYPE.ISBN, Bar_Code, Color.Black, Color.White, 290, 120);
                    MemoryStream ms = new MemoryStream();
                    img.Save(ms, ImageFormat.Bmp);
                    byte[] buffer = ms.GetBuffer();
                    MemoryStream bufferPasser = new MemoryStream(buffer);
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = bufferPasser;
                    bitmap.EndInit();
                    return bitmap;
                }
                catch
                {
                    return null; 
                }
            }
        }
        public String Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
