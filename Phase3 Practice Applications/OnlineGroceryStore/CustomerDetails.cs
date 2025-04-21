using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore
{
    public class CustomerDetails : PersonalDetails, IBalance
    {
        /// <summary>
        /// private field used to auto increment CustomerID that uniquely identify as <see cref="CustomerID"/> Class Instance
        /// </summary>
        private static int s_customerID = 1000;

        /// <summary>
        /// Public property uses s_customerID to store CustomerID that uniquely identify as <see cref="CustomerID"/> Class Instance
        /// </summary>
        /// <value>Starts from CID1001</value>
        public string CustomerID { get; }

        /// <summary>
        /// Public property used to store wallet balance of login customer that uniquely identify as <see cref="WalletBalance"/> Class Instance
        /// </summary>
        public double WalletBalance { get; set; }

        /// <summary>
        /// Used to Add amount to customer's wallet
        /// </summary>
        /// <param name="amount">amount should be recharge in wallet</param>
        public void WalletRecharge(double amount)
        {
            WalletBalance += amount;
        }

        /// <summary>
        /// Used to Deduct amount in customer's wallet
        /// </summary>
        /// <param name="amount">amount should be deduct in wallet</param>
        public void DeductBalance(double amount)
        {
            WalletBalance -= amount;
        }

        //Default Constructor
        public CustomerDetails() { }

        //Constructor with parameters
        public CustomerDetails(double walletBalance, string name, string fatherName, GenderStatus gender, long mobile, DateTime dob, string mailID) : base(name, fatherName, gender, mobile, dob, mailID)
        {
            s_customerID++;
            CustomerID = "CID" + s_customerID;
            WalletBalance = walletBalance;
        }

        //Constructor used to read values from CSV file
        public CustomerDetails(string values)
        {
            string[] value = values.Split(",");
            CustomerID = value[0];
            s_customerID = int.Parse(value[0].Remove(0, 3));
            WalletBalance = double.Parse(value[1]);
            Name = value[2];
            FatherName = value[3];
            Gender = Enum.Parse<GenderStatus>(value[4]);
            Mobile = long.Parse(value[5]);
            DOB = DateTime.ParseExact(value[6], "dd/MM/yyyy", null);
            MailID = value[7];
        }
    }
}