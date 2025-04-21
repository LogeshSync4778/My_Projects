using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace CovidVaccination
{
    public class BeneficiaryClass
    {
        /// <summary>
        /// Private field Auto incremented that Uniquely identify <see cref="RegistrationNumber" /> Class Instance
        /// </summary>
        private static int s_registrationNumber=1000;

        /// <summary>
        /// Public field uses s_registrationNumber field that Uniquely identify <see cref="RegistrationNumber" /> Class Instance 
        /// </summary>
        public string RegistrationNumber { get;  }

        /// <summary>
        /// public field used to store Name of the Beneficiary that uniquely identify <see cref="CustomerName" /> Class Instance
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// public field used to store Beneficiary's age that uniquely identify <see cref="Age" /> Class Instance
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// public field used to store Beneficiary's gender that uniquely identify <see cref="Gender" /> Class Instance
        /// </summary>
        public GenderDetails Gender { get; set; }

        /// <summary>
        /// public field used to store Beneficiary's Mobile number that uniquely identify <see cref="Mobile" /> Class Instance
        /// </summary>
        public long Mobile { get; set; }

        /// <summary>
        /// public field used to store City of the Beneficiary that uniquely identify <see cref="City" /> Class Instance
        /// </summary>
        public string City { get; set; }

        public BeneficiaryClass(string name,int age,GenderDetails gender,long mobile,string city)
        {
            s_registrationNumber++;
            RegistrationNumber="BID"+s_registrationNumber;
            Name=name;
            Age=age;
            Gender=gender;
            Mobile=mobile;
            City=city;
        }

        public BeneficiaryClass(string beneficiary)
        {
            string[] values=beneficiary.Split(",");
            RegistrationNumber=values[0];
            s_registrationNumber=int.Parse(values[0].Remove(0,3));
            Name=values[1];
            Age=int.Parse(values[2]);
            Gender=Enum.Parse<GenderDetails>(values[3]);
            Mobile=long.Parse(values[4]);
            City=values[5];
        }
    }
}