using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore
{
    public class ProductDetails
    {

        /// <summary>
        /// private field used to auto increment s_productID that uniquely identify as <see cref="ProductID"/> Class Instance
        /// </summary>
        private static int s_productID = 2000;

        /// <summary>
        /// public property uses s_productID to store Product ID that uniquely identify as <see cref="ProductID"/> Class Instance
        /// </summary>
        /// <value></value>
        public string ProductID { get; }

        /// <summary>
        /// public property used to store Product Name that uniquely identify as <see cref="ProductName"/> Class Instance
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// public property used to store Available Quantity of products that uniquely identify as <see cref="QuantityAvailable"/> Class Instance
        /// </summary>
        public int QuantityAvailable { get; set; }

        /// <summary>
        /// public property used to store Price amount of product that uniquely identify as <see cref="PricePerQuantity}"/> Class Instance
        /// </summary>
        public double PricePerQuantity { get; set; }

        //Constructor with parameters
        public ProductDetails(string productName, int quantityAvailable, double pricePerQuantity)
        {
            s_productID++;
            ProductID = "PID" + s_productID;
            ProductName = productName;
            QuantityAvailable = quantityAvailable;
            PricePerQuantity = pricePerQuantity;
        }

        //Constructor used to read values from CSV file
        public ProductDetails(string values)
        {
            string[] value = values.Split(",");
            ProductID = value[0];
            s_productID = int.Parse(value[0].Remove(0, 3));
            ProductName = value[1];
            QuantityAvailable = int.Parse(value[2]);
            PricePerQuantity = double.Parse(value[3]);
        }
    }
}