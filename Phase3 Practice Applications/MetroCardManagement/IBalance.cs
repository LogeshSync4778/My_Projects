using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public interface IBalance
    {
        /// <summary>
        /// public property used to store user's wallet balance 
        /// </summary>
        public double Balance { get; set; }

        /// <summary>
        /// method used to add amount to user's wallet
        /// </summary>
        /// <param name="amount">amount to be add in wallet</param>
        public void WalletRecharge(double amount);

        /// <summary>
        /// method used to deduct amount in user's wallet
        /// </summary>
        /// <param name="amount">amount to be deduct in wallet</param>
        public void DeductBalance(double amount);
    }
}