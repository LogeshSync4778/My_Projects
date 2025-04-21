using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibraryManagement
{
    public class UserDetails
    {
        /// <summary>
        /// Private field Auto incremented that Uniquely identify <see cref="UserID" /> Class Instance
        /// </summary> 
        private static int s_userID = 3000;

        /// <summary>
        /// Public property uses _userID field that Uniquely identify <see cref="UserID" /> Class Instance 
        /// </summary>
        public string UserID { get; }

        /// <summary>
        /// public property used to store Username that uniquely identify <see cref="UserName" /> Class Instance
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// public property used to store User's gender that uniquely identify <see cref="Gender" /> Class Instance
        /// </summary>
        public GenderDetails Gender { get; set; }

        /// <summary>
        /// public property used to store Status of the department that uniquely identify <see cref="Department" /> Class Instance
        /// </summary>
        public DepartmentStatus Department { get; set; }

        /// <summary>
        /// public property used to store Mobile number of user that uniquely identify <see cref="Mobile" /> Class Instance
        /// </summary>
        public long Mobile { get; set; }

        /// <summary>
        /// public property used to store User's mailID that uniquely identify <see cref="MailID" /> Class Instance
        /// </summary>
        public string MailID { get; set; }

        /// <summary>
        /// public property used to store User's WalletBalance that uniquely identify <see cref="WalletBalance" /> Class Instance
        /// </summary>
        public double WalletBalance { get; set; }

        public UserDetails(string username, GenderDetails gender, DepartmentStatus department, long mobile, string mailid, double walletbalance)
        {
            s_userID++;
            UserID = "SF" + s_userID;
            UserName = username;
            Gender = gender;
            Department = department;
            Mobile = mobile;
            MailID = mailid;
            WalletBalance = walletbalance;
        }

        /// <summary>
        /// Add amount with User's WalletBalance
        /// </summary>
        /// <param name="amount">Amount to be recharge in user's wallet</param>
        public void Recharge(double amount)
        {
            WalletBalance += amount;
        }

        /// <summary>
        /// Deduct amount in the User's WalletBalance
        /// </summary>
        /// <param name="amount">Amount to be deducted in user's wallet</param>
        public void Deduct(double amount)
        {
            WalletBalance -= amount;
        }
    }
}