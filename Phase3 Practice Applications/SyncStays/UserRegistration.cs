using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncStays
{
    public class UserRegistration : PersonalDetails, IWalletManager
    {
        /// <summary>
        /// private field used to auto increment User ID that uniquely identify as <see cref="UserID"/> Class Instance
        /// </summary>
        private static int s_userID = 1000;

        /// <summary>
        /// public property uses s_userID to store User ID that uniquely identify as <see cref="UserID"/> Class Instance
        /// </summary>
        /// <value>Starts from SF1001</value>
        public string UserID { get; }

        /// <summary>
        /// public property used to store Wallet Balance of user that uniquely identify as  <see cref="WalletBalance"/> Class Instance
        /// </summary>
        public double WalletBalance { get; set; }

        //Default COnstructor
        public UserRegistration() { }


        //Constructor used to assign values to the properties
        public UserRegistration(string userName, long mobileNumber, string aadharNumber, string address, FoodDetails foodType, GenderStatus gender, double walletBalance) : base(userName, mobileNumber, aadharNumber, address, foodType, gender)
        {
            s_userID++;
            UserID = "SF" + s_userID;
            WalletBalance = walletBalance;
        }

        //Constructor used to get values from csv file
        public UserRegistration(string values)

        {
            string[] value = values.Split(",");
            UserID = value[0];
            s_userID = int.Parse(value[0].Remove(0, 2));
            UserName = value[1];
            MobileNumber = long.Parse(value[2]);
            AadharNumber = value[3];
            Address = value[4];
            FoodType = Enum.Parse<FoodDetails>(value[5]);
            Gender = Enum.Parse<GenderStatus>(value[6]);
            WalletBalance = double.Parse(value[7]);
        }

        /// <summary>
        /// Method used to add given amount into user's wallet
        /// </summary>
        public void WalletRecharge(double amount)
        {
            WalletBalance += amount;
        }

        /// <summary>
        /// Method used to deduct give amount in user's wallet
        /// </summary>
        public void DeductBalance(double amount)
        {
            WalletBalance -= amount;
        }
    }
}