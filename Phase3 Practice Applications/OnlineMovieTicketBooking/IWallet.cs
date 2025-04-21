using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieTicketBooking
{
    public interface IWallet
    {
        /// <summary>
        /// public property used to store Wallet balance of user that Uniquely Identify as <see cref="WalletBalance"/> Class Instance
        /// </summary>
        public double WalletBalance { get; set; }

        /// <summary>
        /// Method used to add amount to user's wallet
        /// </summary>
        public void RechargeWallet(double amount);

        /// <summary>
        /// Method used to deduct amount from user's wallet
        /// </summary>
        public void DeductBalance(double amount);
    }
}