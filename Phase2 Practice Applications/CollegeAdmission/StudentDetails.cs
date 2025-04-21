using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public class StudentDetails
    {
        /// <summary>
        /// Private field Auto incremented that Uniquely identify <see cref="StudentID" /> Class Instance
        /// </summary>
        private static int s_student_ID = 3000;

        /// <summary>
        /// Public property uses _studentID field that Uniquely identify <see cref="StudentID" /> Class Instance 
        /// </summary>
        public string StudentID { get; }
        
        /// <summary>
        /// public property used to store Name that uniquely identify <see cref="StudentName" /> Class Instance
        /// </summary>
        public string StudentName { get; set; }
        
        /// <summary>
        /// public property used to store Fathername of Student that uniquely identify <see cref="FatherName" /> Class Instance
        /// </summary>
        public string FatherName { get; set; }
        
        /// <summary>
        /// public property used to store Date of Birth of the Student that uniquely identify <see cref="DON" /> Class Instance
        /// </summary>
        public DateTime DOB { get; set; }
        
        /// <summary>
        /// public property used to store Gender of Student that uniquely identify <see cref="Gender" /> Class Instance
        /// </summary>
        public GenderDetails Gender { get; set; }
        
        /// <summary>
        /// public property used to store Physics Mark of Student that uniquely identify <see cref="Physicsmark" /> Class Instance
        /// </summary>
        /// <value>1 to 100</value>
        public int Physicsmark { get; set; }
        
        /// <summary>
        /// public property used to store Chemistry Mark of Student that uniquely identify <see cref="Chemistrymark" /> Class Instance
        /// </summary>
        /// <value>1 to 100</value>
        public int Chemistrymark { get; set; }
        
        /// <summary>
        /// public property used to store Maths Mark of Student that uniquely identify <see cref="Mathsmark" /> Class Instance
        /// </summary>
        /// <value>1 to 100</value>
        public int Mathsmark { get; set; }

        public StudentDetails(string name, string fathername, DateTime dob, GenderDetails gender, int physicsmark, int chemistrymark, int mathsmark)
        {
            s_student_ID++;
            StudentID = "SF" + s_student_ID;
            StudentName = name;
            FatherName = fathername;
            DOB = dob;
            Gender = gender;
            Physicsmark = physicsmark;
            Chemistrymark = chemistrymark;
            Mathsmark = mathsmark;
        }

        /// <summary>
        /// Calculate the Total marks of the students by adding Maths, Physics and Chemistry marks that uniquely identify <see cref="Total" /> Class Instance
        /// </summary>
        /// <returns>Total marks of the student (Int)</returns>
        public int Total()
        {
            return Physicsmark + Chemistrymark + Mathsmark;
        }

        /// <summary>
        /// Calculate Average value of the student by dividing Total marks of the student by total subjects that uniquely identify <see cref="Average" /> Class Instance
        /// </summary>
        /// <returns>Average marks of the student(Double)</returns>
        public double Average()
        {
            return Total() / 3;
        }

        /// <summary>
        /// Check the students average is greater than 75 or not
        /// </summary>
        /// <param name="average">Average Mark of Student</param>
        /// <returns>Returns a boolean value</returns>
        public bool IsEligible(double average)
        {
            if (average >= 75.0)
            {
                return true;
            }
            return false;
        }
    }
}