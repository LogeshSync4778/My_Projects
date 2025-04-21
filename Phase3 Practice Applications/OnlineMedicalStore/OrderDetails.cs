using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class OrderDetails
    {
        /// <summary>
        /// private field used to auto Increment OrderID that uniquely Identify as <see cref="OrderID"/> Class Instance
        /// </summary>
        private static int s_orderID = 2000;

        /// <summary>
        /// public property uses s_orderID to store OrderID that uniquely Identify as <see cref="OrderID"/> Class Instance
        /// </summary>
        /// <value>Starts from OID2001</value>
        public string OrderID { get; }

        /// <summary>
        /// public property used to store UserID that uniquely Identify as <see cref="UserID"/> Class Instance
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// public property used to store MedicineID that uniquely Identify as <see cref="MedicineID"/> Class Instance
        /// </summary>
        public string MedicineID { get; set; }

        /// <summary>
        /// public property used to store Medicine stock that uniquely Identify as <see cref="MedicineCount"/> Class Instance
        /// </summary>
        public int MedicineCount { get; set; }

        /// <summary>
        /// public property used to store Total price of the order that uniquely Identify as <see cref="TotalPrice"/> Class Instance
        /// </summary>
        public double TotalPrice { get; set; }

        /// <summary>
        /// public property used to store Order Date that uniquely Identify as <see cref="OrderDate"/> Class Instance
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// public property used to store Order Status that uniquily Identify as <see cref="Status"/> Class Instance
        /// </summary>
        /// <value></value>
        public OrderStatus Status { get; set; }

        //Constructor with parameters
        public OrderDetails(string userID, string medicineID, int medicineCount, double totalPrice, DateTime orderDate, OrderStatus status)
        {
            s_orderID++;
            OrderID = "OID" + s_orderID;
            UserID = userID;
            MedicineID = medicineID;
            MedicineCount = medicineCount;
            TotalPrice = totalPrice;
            OrderDate = orderDate;
            Status = status;
        }

        //Constructor used to get values from CSV file
        public OrderDetails(string values)
        {
            string[] value = values.Split(",");
            OrderID = value[0];
            s_orderID = int.Parse(value[0].Remove(0, 3));
            UserID = value[1];
            MedicineID = value[2];
            MedicineCount = int.Parse(value[3]);
            TotalPrice = double.Parse(value[4]);
            OrderDate = DateTime.ParseExact(value[5], "dd/MM/yyyy", null);
            Status = Enum.Parse<OrderStatus>(value[6], true);
        }
    }
}
