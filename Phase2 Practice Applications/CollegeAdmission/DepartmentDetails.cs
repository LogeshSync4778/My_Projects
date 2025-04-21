using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public class DepartmentDetails
    {
        /// <summary>
        /// Private field Auto incremented that Uniquely identify <see cref="DepartmentID" /> Class Instance
        /// </summary>
        private static int s_departmentID=100;
        
        /// <summary>
        /// Public property uses _departmentID field that Uniquely identify <see cref="DepartmentID" /> Class Instance 
        /// </summary>
        public string DepartmentID { get; }
        
        /// <summary>
        /// public property used to store Name of the department that uniquely identify <see cref="DepartmentName" /> Class Instance
        /// </summary>
        public string DepartmentName { get; set; }
        
        /// <summary>
        /// public property used to store the Seat count that uniquely identify <see cref="NumberOfSeats" /> Class Instance
        /// </summary>
        public int NumberOfSeats { get; set; }

        public DepartmentDetails(string departmentName, int noOfSeats)
        {
            s_departmentID++;
            DepartmentID = "DID"+s_departmentID;
            DepartmentName = departmentName;
            NumberOfSeats = noOfSeats;
        }
    }
}