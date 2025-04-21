using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieTicketBooking
{
    public class PersonalDetails
    {
        /// <summary>
        /// public property used to store Customer name that uniquely identify as <see cref="Name"/> Class Instance
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// public property used to store Customer's age that uniquely identify as <see cref="Age"/> Class Instance
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// public property used to store Customer's Phone number that uniquely identify as <see cref="Phone"/> Class Instance
        /// </summary>
        public long Phone { get; set; }

        /// <summary>
        /// public property used to store Customer's gender type that uniquely identify as <see cref="Gender"/> Class Instancee
        /// </summary>
        /// <value></value>
        public GenderStatus Gender { get; set; }

        //Default Constructer
        public PersonalDetails() { }

        //Constructor with parameters used to assign values to properties
        public PersonalDetails(string name, int age, long phone, GenderStatus gender)
        {
            Name = name;
            Age = age;
            Phone = phone;
            Gender = gender;
        }

    }
}