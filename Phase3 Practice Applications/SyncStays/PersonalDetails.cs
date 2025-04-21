using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncStays
{
    public class PersonalDetails
    {
        /// <summary>
        /// public  property used to store Username that uniquely identify as <see cref="UserName"/> Class Instance
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// public  property used to store Mobile number of User that uniquely identify as <see cref="MobileNumber"/> Class Instance
        /// </summary>
        public long MobileNumber { get; set; }

        /// <summary>
        /// public  property used to store Aadhar number of user that uniquely identify as <see cref="AadharNumber"/> Class Instance
        /// </summary>
        public string AadharNumber { get; set; }

        /// <summary>
        /// public  property used to store User's address that uniquely identify as <see cref="Address"/> Class Instance
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// public  property used to store User's Food type that uniquely identify as <see cref="FoodType"/> Class Instance
        /// </summary>
        public FoodDetails FoodType { get; set; }

        /// <summary>
        /// public  property used to store User's gender type that uniquely identify as <see cref="Gender"/> Class Instance
        /// </summary>
        public GenderStatus Gender { get; set; }

        //Default COnstructor
        public PersonalDetails() { }

        //Constructor used to assign values to the properties
        public PersonalDetails(string userName, long mobileNumber, string aadharNumber, string address, FoodDetails foodType, GenderStatus gender)
        {
            UserName = userName;
            MobileNumber = mobileNumber;
            AadharNumber = aadharNumber;
            Address = address;
            FoodType = foodType;
            Gender = gender;
        }

    }
}

