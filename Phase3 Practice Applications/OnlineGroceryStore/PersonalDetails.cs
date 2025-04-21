using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore
{
    public class PersonalDetails
    {
        /// <summary>
        /// public property used to store Customer Name that uniquely identify as <see cref="Name"/> Class Instance
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// public property used to store Customer's Father name that uniquely identify as <see cref="FatherName"/> Class Instance
        /// </summary>
        public string FatherName { get; set; }

        /// <summary>
        /// public property used to store Gender type of customer that uniquely identify as <see cref="Gender"/> Class Instance
        /// </summary>
        public GenderStatus Gender { get; set; }

        /// <summary>
        /// public property used to store Customer's Mobile number that uniquely identify as <see cref="Mobile"/> Class Instance
        /// </summary>
        public long Mobile { get; set; }

        /// <summary>
        /// public property used to store Customer Date of Birth that uniquely identify as <see cref="DOB"/> Class Instance
        /// </summary>
        public DateTime DOB { get; set; }

        /// <summary>
        /// public property used to store Customer E-Mail ID that uniquely identify as <see cref="MailID"/> Class Instance
        /// </summary>
        public string MailID { get; set; }

        //Default Constructor
        public PersonalDetails() { }

        //Constructor with parameters
        public PersonalDetails(string name, string fatherName, GenderStatus gender, long mobile,DateTime dob, string mailID)
        {
            Name = name;
            FatherName = fatherName;
            Gender = gender;
            Mobile = mobile;
            DOB = dob;
            MailID = mailID;
        }
    }
}