using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management
{

    //Create Objects for the Class
    public class PatientDetails
    {
        /// <summary>
        /// private field used to auto increment PatientID that uniquely identify as <see cref="PatientID"/> Class Instance
        /// </summary>
        private static int s_patientID = 2000;

        /// <summary>
        /// public property uses s_patientID that uniquely identify as <see cref="PatientID"/> Class Instance
        /// </summary>
        public string PatientID { get; }

        /// <summary>
        ///  public property used to store Name of the Patient that uniquely identify as <see cref="PatientName"/> Class Instance
        /// </summary>
        public string PatientName { get; set; }

        /// <summary>
        ///  public property used to store Age of Patient that uniquely identify as <see cref="Age"/> Class Instance
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        ///  public property used to store Gender of the Patient that uniquely identify as <see cref="Gender"/> Class Instance
        /// </summary>
        public GenderDetails Gender { get; set; }

        /// <summary>
        ///  public property used to store WalletBalance of patient that uniquely identify as <see cref="WalletBalance"/> Class Instance
        /// </summary>
        public double WalletBalance { get; set; }

        //Assign Values of called paramters to the datas in the class
        public PatientDetails(string patientName, int age, GenderDetails gender, double walletBalance)
        {
            s_patientID++;
            PatientID = "PID" + s_patientID;
            PatientName = patientName;
            Age = age;
            Gender = gender;
            WalletBalance = walletBalance;
        }

        //Create Method to recharge walletBalance
        public void WalletRecharge(double amount)
        {
            WalletBalance += amount;
        }

        //Create Method to deduct balance from walletBalance
        public void DeductBalance(double amount)
        {
            WalletBalance -= amount;
        }
    }
}