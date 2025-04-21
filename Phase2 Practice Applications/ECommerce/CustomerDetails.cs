using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce
{
    public class CustomerDetails
    {
        /// <summary>
        /// Private field Auto incremented that Uniquely identify <see cref="CustomerID" /> Class Instance
        /// </summary>        
        private static int s_customerID=3000;
        
        /// <summary>
        /// Public field uses _admissionID field that Uniquely identify <see cref="DepartmentID" /> Class Instance 
        /// </summary>
        public string CustomerID { get;  }
        
        /// <summary>
        /// public field used to store Name of the Customer that uniquely identify <see cref="CustomerName" /> Class Instance
        /// </summary>
        public string CustomerName { get; set; }
        
        /// <summary>
        /// public field used to store City of the Customer that uniquely identify <see cref="City" /> Class Instance
        /// </summary>
        public string City { get; set; }
        
        /// <summary>
        /// public field used to store Mobile Number of Customer that uniquely identify <see cref="Mobile" /> Class Instance
        /// </summary>
        public long Mobile { get; set; }
        
        /// <summary>
        /// public field used to store Wallet Balance of the Customer that uniquely identify <see cref="WalletBalance" /> Class Instance
        /// </summary>
        public double WalletBalance { get; set; }
        
        /// <summary>
        /// public field used to store Customer's Email ID that uniquely identify <see cref="EmailID" /> Class Instance
        /// </summary>
        public string EmailID { get; set; }

        public CustomerDetails(string customerName,string city,long mobile, double walletBalance,string emailID)
        {
            s_customerID++;
            CustomerID="CID"+s_customerID;
            CustomerName=customerName;
            City=city;
            Mobile=mobile;
            WalletBalance=walletBalance;
            EmailID=emailID;
        }

        public CustomerDetails(string customers)
        {
            string[] values=customers.Split(",");
            CustomerID=values[0];
            CustomerName=values[1];
            City=values[2];
            Mobile=long.Parse(values[3]);
            WalletBalance=double.Parse(values[4]);
            EmailID=values[5];
        }
        
        /// <summary>
        /// Add the amount with the Customer's WalletBalance amount
        /// </summary>
        /// <param name="amount">Recharge amount</param>
        public void Recharge(double amount)
        {
            WalletBalance+=amount;
        }
        
        /// <summary>
        /// Deduct the amount in Customer's Wallet Balance
        /// </summary>
        /// <param name="amount">Amount to be deduct</param>
        public void Deduct(double amount)
        {
            WalletBalance-=amount;
        }
    }
}