using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce
{
    public class ProductDetails
    {
        /// <summary>
        /// Private field Auto incremented that Uniquely identify <see cref="ProductID" /> Class Instance
        /// </summary> 
        private static int s_productID=2000;
        
        /// <summary>
        /// Public field uses _productID field that Uniquely identify <see cref="ProductID" /> Class Instance 
        /// </summary>
        public string ProductID { get;  }
        
        /// <summary>
        /// public field used to store Name of the Product that uniquely identify <see cref="ProductName" /> Class Instance
        /// </summary>
        public string ProductName { get; set; }
        
        /// <summary>
        /// public field used to store Stock of the product that uniquely identify <see cref="Stock" /> Class Instance
        /// </summary>
        public int Stock { get; set; }
        
        /// <summary>
        /// public field used to store Price of the Product that uniquely identify <see cref="Price" /> Class Instance
        /// </summary>
        public double Price { get; set; }
        
        /// <summary>
        /// public field used to store Delivery duration of the product that uniquely identify <see cref="Duration" /> Class Instance
        /// </summary>
        public int Duration { get; set; }

        public ProductDetails(string productname,int stock,double price,int duration)
        {
            s_productID++;
            ProductID="PID"+s_productID;
            ProductName=productname;
            Stock=stock;
            Price=price;
            Duration=duration;
        }
    }
}