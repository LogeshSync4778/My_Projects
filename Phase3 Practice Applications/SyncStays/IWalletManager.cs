using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncStays
{
    public interface IWalletManager
    {
        /// <summary>
        /// public property used to store wallet balance of user
        /// </summary>

        public double WalletBalance { get; set; }

        /// <summary>
        /// Method used to add given amount to user's wallet
        /// </summary>
        public void WalletRecharge(double amount);

        /// <summary>
        /// Method used to deduct given amount from user's wallet
        /// </summary>
        /// <param name="amount"></param>
        public void DeductBalance(double amount);
    }
}