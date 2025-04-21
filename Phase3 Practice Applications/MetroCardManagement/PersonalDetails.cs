using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class PersonalDetails
    {
        /// <summary>
        /// public property used to store Name of the user that uniquely identify as <see cref="Name"/> Class Instance
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// public property used to store Phone number of the user that uniquely identify as <see cref="Phone"/> Class Instance
        /// </summary>
        public long Phone { get; set; }

        //Default Constructor
        public PersonalDetails() { }

        //Constructor with parameters
        public PersonalDetails(string name, long phone)
        {
            Name = name;
            Phone = phone;
        }
    }
}