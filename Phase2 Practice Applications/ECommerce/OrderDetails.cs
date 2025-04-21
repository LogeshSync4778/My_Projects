using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce
{
    public class OrderDetails
    {
        /// <summary>
        /// Private field Auto incremented that Uniquely identify <see cref="OrderID" /> Class Instance
        /// </summary> 
        private static int s_orderID = 1000;
        
        /// <summary>
        /// Public field uses _orderID field that Uniquely identify <see cref="OrderID" /> Class Instance 
        /// </summary>
        public string OrderID { get; }
        
        /// <summary>
        /// public field used to store CustomerID that uniquely identify <see cref="CustomerID" /> Class Instance
        /// </summary>
        public string CustomerID { get; set; }
        
        /// <summary>
        /// public field used to store ProductID that uniquely identify <see cref="ProductID" /> Class Instance
        /// </summary>
        public string ProductID { get; set; }
        
        /// <summary>
        /// public field used to store Total Price of the product that uniquely identify <see cref="TotalPrice" /> Class Instance
        /// </summary>
        public double TotalPrice { get; set; }
        
        /// <summary>
        /// public field used to store Purchase date of the product that uniquely identify <see cref="PurchaseDate" /> Class Instance
        /// </summary>
        public DateTime PurchaseDate { get; set; }
        
        /// <summary>
        /// public field used to store Quantity of the Product that uniquely identify <see cref="Quantity" /> Class Instance
        /// </summary>
        public int Quantity { get; set; }
        
        /// <summary>
        /// public field used to store Order Status of the product that uniquely identify <see cref="Status" /> Class Instance
        /// </summary>
        public OrderStatus Status { get; set; }

        public OrderDetails(string customerID, string productID, double totalprice, DateTime purchasedate, int quantity, OrderStatus status)
        {
            s_orderID++;
            OrderID = "OID" + s_orderID;
            CustomerID = customerID;
            ProductID = productID;
            TotalPrice = totalprice;
            PurchaseDate = purchasedate;
            Quantity = quantity;
            Status = status;
        }
    }
}