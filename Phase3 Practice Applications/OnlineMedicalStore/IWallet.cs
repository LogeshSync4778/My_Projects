using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public interface IWallet
    {
        public double WalletBalance { get; set; }
        public void WalletRecharge(double amnount);
        public void DeductBalance(double amount);
    }
}