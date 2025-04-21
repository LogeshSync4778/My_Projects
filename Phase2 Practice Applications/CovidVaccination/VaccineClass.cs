using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination
{
    public class VaccineClass
    {

        /// <summary>
        /// Private field Auto incremented that Uniquely identify <see cref="VaccineID" /> Class Instance
        /// </summary>
        private static int s_vaccineID = 2000;

        /// <summary>
        /// Public field uses s_vaccineID field that Uniquely identify <see cref="VaccineID" /> Class Instance 
        /// </summary>
        public string VaccineID { get; }

        /// <summary>
        /// public field used to store Name of the vaccine that uniquely identify <see cref="VaccineName" /> Class Instance
        /// </summary>
        public VaccineDetails VaccineName { get; set; }

        /// <summary>
        /// public field used to store Stock of available doses that uniquely identify <see cref="DoseAvailable" /> Class Instance
        /// </summary>
        public int DoseAvailable { get; set; }

        public VaccineClass(VaccineDetails vaccineName, int doseavailable)
        {
            s_vaccineID++;
            VaccineID = "CID" + s_vaccineID;
            VaccineName = vaccineName;
            DoseAvailable = doseavailable;
        }

        public VaccineClass(string vaccination)
        {
            string[] values=vaccination.Split(",");
            VaccineID = values[0];
            s_vaccineID=int.Parse(values[0].Remove(0,3));
            VaccineName = Enum.Parse<VaccineDetails>(values[1]);
            DoseAvailable = int.Parse(values[2]);
        }
    }
}