using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWClothingCo.Models
{
    public class CartItem
    {
        public string Image_Name { get; set; }

        public string Product_Name { get; set; }

        public int Quantity { get; set; }

        public double Product_Price { get; set; }

        public CartItem(string Image_Name, string Product_Name, int Quantity, double Product_Price) 
        {
            this.Image_Name = Image_Name;
            this.Product_Name = Product_Name;
            this.Quantity = Quantity;
            this.Product_Price = Product_Price;
        }
    }
}
