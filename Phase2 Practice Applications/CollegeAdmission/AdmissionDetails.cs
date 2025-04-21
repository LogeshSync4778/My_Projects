using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public class AdmissionDetails
    {
        /// <summary>
        /// Private field Auto incremented that Uniquely identify <see cref="AdmissionID" /> Class Instance
        /// </summary>
        private static int s_admissionID = 1000;
        
        /// <summary>
        /// Public property uses _admissionID field that Uniquely identify <see cref="DepartmentID" /> Class Instance 
        /// </summary>
        public string AdmissionID { get; }
        
        /// <summary>
        /// public property used to store StudentID that uniquely identify <see cref="StudentID" /> Class Instance
        /// </summary>
        public string StudentID { get; set; }
        
        /// <summary>
        /// public property used to store DepartmentID that uniquely identify <see cref="DepartmentID" /> Class Instance
        /// </summary>
        public string DepartmentID { get; set; }
        
        /// <summary>
        /// public property used to store Admission Date of the student that uniquely identify <see cref="AdmissionDate" /> Class Instance
        /// </summary>
        public DateTime AdmissionDate { get; set; }
        
        /// <summary>
        /// public property used to store Status of the addmission that uniquely identify <see cref="Status" /> Class Instance
        /// </summary>
        /// <value>Booked, Cancelled</value>
        public AdmissionStatus Status { get; set; }

        public AdmissionDetails(string studentID, string departmentID, DateTime admissionDate, AdmissionStatus status)
        {
            s_admissionID++;
            AdmissionID = "AID" + s_admissionID;
            StudentID = studentID;
            DepartmentID = departmentID;
            AdmissionDate = admissionDate;
            Status = status;
        }
    }
}