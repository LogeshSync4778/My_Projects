using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination
{
    public class VaccinationClass
    {
        /// <summary>
        /// Private field Auto incremented that Uniquely identify <see cref="VaccinationID" /> Class Instance
        /// </summary>
        private static int s_vaccinationID=3000;

        /// <summary>
        /// Public field uses s_vaccinationID field that Uniquely identify <see cref="VaccinationID" /> Class Instance 
        /// </summary>
        public string VaccinationID { get; }

        /// <summary>
        /// public field used to store Beneficiary's Register number that uniquely identify <see cref="RegistrationNumber" /> Class Instance
        /// </summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// public field used to store VaccineID that uniquely identify <see cref="VaccineID" /> Class Instance
        /// </summary>
        public string VaccineID { get; set; }

        /// <summary>
        /// public field used to store Count of the Dose received that uniquely identify <see cref="DoseCount" /> Class Instance
        /// </summary>
        public DoseDetails DoseCount { get; set; }

        /// <summary>
        /// public field used to store Vaccinated Date that uniquely identify <see cref="VaccinatedDate" /> Class Instance
        /// </summary>
        public DateTime VaccinatedDate { get; set; }

        /// <summary>
        /// public field used to store Name of the Beneficiary that uniquely identify <see cref="CustomerName" /> Class Instance
        /// </summary>

        public VaccinationClass(string registrationnumber,string vaccineID,DoseDetails doseCount,DateTime vaccinatedDate)
        {
            s_vaccinationID++;
            VaccinationID="VID"+s_vaccinationID;
            RegistrationNumber=registrationnumber;
            VaccineID=vaccineID;
            DoseCount=doseCount;
            VaccinatedDate=vaccinatedDate;
        }

        public VaccinationClass(string vaccination)
        {
            string[] values=vaccination.Split(",");
            VaccinationID=values[0];
            s_vaccinationID=int.Parse(values[0].Remove(0,3));
            RegistrationNumber=values[1];
            VaccineID=values[2];
            DoseCount=Enum.Parse<DoseDetails>(values[3]);
            VaccinatedDate=DateTime.ParseExact(values[4],"dd/MM/yyyy",null);
        }
    }
}