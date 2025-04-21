using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore
{
    public interface IBalance
    {
        /// <summary>
        /// public property used to store Wallet Balance of customer
        /// </summary>
        public double WalletBalance { get; set; }

        /// <summary>
        /// Method used to add amount to Customer's wallet
        /// </summary>
        /// <param name="amount">amount to be added</param>
        public void WalletRecharge(double amount);

        /// <summary>
        /// Method used to deduct amount from Customer's wallet
        /// </summary>
        /// <param name="amount">amount to be deduct</param>
        public void DeductBalance(double amount);
    }
}