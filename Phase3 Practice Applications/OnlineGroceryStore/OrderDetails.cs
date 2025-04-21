using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore
{
    public class OrderDetails
    {
        /// <summary>
        /// private field used to auto increment OrderID that uniquely identify as <see cref="OrderID"/> Class Instance
        /// </summary>
        private static int s_orderID = 4000;

        /// <summary>
        /// public property uses s_orderID to store Order ID that uniquely identify as <see cref="OrderID"/> Class Instance
        /// </summary>
        /// <value>Starts from OID4001</value>
        public string OrderID { get; }

        /// <summary>
        /// public property used to store booking ID that uniquely identify as <see cref="BookingID"/> Class Instance
        /// </summary>
        /// <value></value>
        public string BookingID { get; set; }

        /// <summary>
        /// public property used to store product ID that uniquely identify as <see cref="ProductID"/> Class Instance
        /// </summary>
        public string ProductID { get; set; }

        /// <summary>
        /// public property used to store purchase count that uniquely identify as <see cref="PurchaseCount"/> Class Instance
        /// </summary>
        public int PurchaseCOunt { get; set; }

        /// <summary>
        /// public property used to store the price for the order that uniquely identify as <see cref="PriceOfOrder"/> Class Instance
        /// </summary>
        public double PriceOfOrder { get; set; }

        //Constructor with Parameters
        public OrderDetails(string bookingID, string productID, int purchaseCount, double priceOfOrder)
        {
            s_orderID++;
            OrderID = "OID" + s_orderID;
            BookingID = bookingID;
            ProductID = productID;
            PurchaseCOunt = purchaseCount;
            PriceOfOrder = priceOfOrder;
        }

        //Constructor used to read values from csv file
        public OrderDetails(string values)
        {
            string[] value = values.Split(",");
            OrderID = value[0];
            s_orderID = int.Parse(value[0].Remove(0, 3));
            BookingID = value[1];
            ProductID = value[2];
            PurchaseCOunt = int.Parse(value[3]);
            PriceOfOrder = double.Parse(value[4]);
        }
    }
}