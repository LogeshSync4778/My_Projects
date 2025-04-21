using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Create Objects for the Class

namespace Hospital_Management
{
    public class DoctorDetails
    {
        /// <summary>
        /// private field used to auto increment DoctorID that uniquely identify as <see cref="DoctorID"/> Class Instance
        /// </summary>
        private static int s_doctorID = 1000;

        /// <summary>
        /// public property uses s_doctorID that uniquely identify as <see cref="DoctorID"/> Class Instance
        /// </summary>
        public string DoctorID { get; }

        /// <summary>
        ///  public property used to store Name of the doctor that uniquely identify as <see cref="DoctorName"/> Class Instance
        /// </summary>
        public string DoctorName { get; set; }

        /// <summary>
        ///  public property used to store Experience of the doctor that uniquely identify as <see cref="Experience"/> Class Instance
        /// </summary>
        public int Experience { get; set; }

        /// <summary>
        ///  public property used to store Doctor's specialization that uniquely identify as <see cref="Specialization"/> Class Instance
        /// </summary>
        public Specialist Specialization { get; set; }

        /// <summary>
        ///  public property used to store Fees of the doctor that uniquely identify as <see cref="Fees"/> Class Instance
        /// </summary>
        public double Fees { get; set; }

        /// <summary>
        /// public property used to store appointment timings of doctors that uniquely identify as <see cref="SlotList"/> Class Instance
        /// </summary>
        public List<string> SlotList { get; set; }

        //Assign Values of called paramters to the datas in the class
        public DoctorDetails(string doctorName, int experience, Specialist specialization, double fees, List<string> slotList)
        {
            s_doctorID++;
            DoctorID = "DID" + s_doctorID;
            DoctorName = doctorName;
            Experience = experience;
            Specialization = specialization;
            Fees = fees;
            SlotList = slotList;
        }
    }
}

