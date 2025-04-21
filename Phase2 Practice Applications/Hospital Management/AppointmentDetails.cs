using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management
{
    public class AppointmentDetails
    {
        /// <summary>
        /// private field used to auto increment AppointmentID that uniquely identify as <see cref="AppointmentID"/> Class Instance
        /// </summary>
        private static int s_appointmentID = 3000;

        /// <summary>
        /// public property uses _appointmentID that uniquely identify as <see cref="AppointmentID"/> Class Instance
        /// </summary>
        public string AppointmentID { get; }
        
        /// <summary>
        ///  public property used to store PatientID that uniquely identify as <see cref="PatientID"/> Class Instance
        /// </summary>
        public string PatientID { get; set; }
        
        /// <summary>
        ///  public property used to store doctorID that uniquely identify as <see cref="DoctorID"/> Class Instance
        /// </summary>
        public string DoctorID { get; set; }

        /// <summary>
        ///  public property used to store Appointment Date that uniquely identify as <see cref="AppointmentDate"/> Class Instance
        /// </summary>
        public DateTime AppointmentDate { get; set; }

        /// <summary>
        ///  public property used to store Appointment Time that uniquely identify as <see cref="AppointmentSlot"/> Class Instance
        /// </summary>
        public string AppointmentSlot { get; set; }

        /// <summary>
        ///  public property used to store Status of the appointment that uniquely identify as <see cref="Status"/> Class Instance
        /// </summary>
        public AppointmentStatus Status { get; set; }

        /// <summary>
        ///  public property used to store Fees of the doctor that uniquely identify as <see cref="Fees"/> Class Instance
        /// </summary>
        public double Fees { get; set; }

        //Assign Values of called parameters to the datas in the class
        public AppointmentDetails(string patientID, string doctorID, DateTime appointmentDate, string appointmentSlot, AppointmentStatus status, double fees)
        {
            s_appointmentID++;
            AppointmentID = "AID" + s_appointmentID;
            PatientID = patientID;
            DoctorID = doctorID;
            AppointmentDate = appointmentDate;
            AppointmentSlot = appointmentSlot;
            Status = status;
            Fees = fees;
        }
    }
}
