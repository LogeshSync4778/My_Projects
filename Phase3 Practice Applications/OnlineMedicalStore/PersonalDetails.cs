using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class PersonalDetails
    {
        /// <summary>
        /// public property used to store User name that uniquely identify as <see cref="Name"/> Class Instance
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// public property used to store user's age that uniquely identify as <see cref="Age"/> Class Instance
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// public property used to store City name that uniquely identify as <see cref="City"/> Class Instance
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// public property used to store user's mobile number that uniquely identify as <see cref="Phone"/> Class Instance
        /// </summary>
        public long Phone { get; set; }

        //Default constructor
        public PersonalDetails() { }

        //Construct with parameters
        public PersonalDetails(string name, int age, string city, long phone)
        {
            Name = name;
            Age = age;
            City = city;
            Phone = phone;
        }
    }
}