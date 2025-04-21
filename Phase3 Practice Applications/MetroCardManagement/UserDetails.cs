using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class UserDetails : PersonalDetails, IBalance
    {
        /// <summary>
        /// private field used to auto Increment Card number that uniquely Identify as <see cref="CardNumber"/> Class Instance
        /// </summary>
        private static int s_cardNumber = 1000;

        /// <summary>
        /// public property uses CardNumber that uniquely Identify as <see cref="CardNumber"/> Class Instance
        /// </summary>
        public string CardNumber { get; }

        /// <summary>
        /// public property used to store wallet Balance of user that uniquely identify as <see cref="Balance"/> Class Instance
        /// </summary>
        /// <value></value>
        public double Balance { get; set; }

        /// <summary>
        /// Methods used to add amount to user's wallet
        /// </summary>
        /// <param name="amount">amount to be add in wallet</param>
        public void WalletRecharge(double amount)
        {
            Balance += amount;
        }

        /// <summary>
        /// Method used to deduct amount from user's wallet
        /// </summary>
        /// <param name="amount">amount to be deduct in wallet</param>
        public void DeductBalance(double amount)
        {
            Balance -= amount;
        }

        // Default Constructor
        public UserDetails() { }
        //Constructor with parameters
        public UserDetails(string name, long phone, double balance) : base(name, phone)
        {
            s_cardNumber++;
            CardNumber = "CMRL" + s_cardNumber;
            Balance = balance;
        }
        //Constructor used to read values from CSV file
        public UserDetails(string values)
        {
            string[] value = values.Split(",");
            CardNumber = value[0];
            s_cardNumber = int.Parse(value[0].Remove(0, 4));
            Name = value[1];
            Phone = long.Parse(value[2]);
            Balance = double.Parse(value[3]);
        }
    }
}