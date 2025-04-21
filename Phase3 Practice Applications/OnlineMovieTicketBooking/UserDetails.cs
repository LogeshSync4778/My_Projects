using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieTicketBooking
{
    public class UserDetails : PersonalDetails, IWallet
    {
        /// <summary>
        /// private field used to auto increment UserID that uniquely identify as <see cref="UserID"/> Class Instance
        /// </summary>
        private static int s_userID = 1000;

        /// <summary>
        /// public property uses s_userID to store UserID that uniquely identify as <see cref="UserID"/> Class Instance
        /// </summary>
        /// <value>Starts from UID1001</value>
        public string UserID { get; }

        /// <summary>
        /// public property used to store Wallet Balance of customer that uniquely identify as <see cref="WalletBalance"/> Class Instance
        /// </summary>
        public double WalletBalance { get; set; }

        /// <summary>
        /// Method used to add amount to customer's wallet
        /// </summary>
        public void RechargeWallet(double amount)
        {
            WalletBalance += amount;
        }

        /// <summary>
        /// Method used to deduct amount from customer's wallet
        /// </summary>
        public void DeductBalance(double amount)
        {
            WalletBalance -= amount;
        }

        //Default Constructor
        public UserDetails() { }

        //Constructor with parameters used to assign values to properties
        public UserDetails(string name, int age, long phone, GenderStatus gender, double walletBalance) : base(name, age, phone, gender)
        {
            s_userID++;
            UserID = "UID" + s_userID;
            WalletBalance = walletBalance;
        }
    }
}