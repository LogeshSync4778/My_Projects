using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class UserDetails : PersonalDetails, IWallet
    {
        /// <summary>
        /// private field used to auto Increment UserID that uniquely Identify as <see cref="UserID"/> Class Instance
        /// </summary>
        private static int s_userID = 1000;

        /// <summary>
        /// public property uses s_userID to store user ID that uniquely Identify as <see cref="UserID"/> Class Instance
        /// </summary>
        /// <value>Starts from UID1001</value>
        public string UserID { get; }

        /// <summary>
        /// public property used to store Wallet balance of user that uniquely Identify as <see cref="WalletBalance"/> Class Instance
        /// </summary>
        public double WalletBalance { get; set; }

        /// <summary>
        /// Method used to make recharge user's wallet with entered amount
        /// </summary>
        /// <param name="amount">amount to be add in wallet</param>
        public void WalletRecharge(double amount)
        {
            WalletBalance += amount;
        }

        /// <summary>
        /// Method used to make deduct an amount from user's wallet
        /// </summary>
        /// <param name="amount">amount to be deduct</param>
        public void DeductBalance(double amount)
        {
            WalletBalance -= amount;
        }

        //Default Constructor
        public UserDetails() { }

        //Constructor with parameters
        public UserDetails(string name, int age, string city, long phone, double walletBalance) : base(name, age, city, phone)
        {
            s_userID++;
            UserID = "UID" + s_userID;
            WalletBalance = walletBalance;
        }

        //Constructor used to read values from CSV file
        public UserDetails(string values)
        {
            string[] value = values.Split(",");
            UserID = value[0];
            s_userID = int.Parse(value[0].Remove(0, 3));
            Name = value[1];
            Age = int.Parse(value[2]);
            City = value[3];
            Phone = long.Parse(value[4]);
            WalletBalance = double.Parse(value[5]);
        }
    }
}