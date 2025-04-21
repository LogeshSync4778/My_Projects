using System;
using System.IO;

namespace CovidVaccination
{
    public class FileHandling
    {
        public static void Create()
        {
            //Folder for Covid Vaccination
            if (!Directory.Exists("CovidVaccination"))
            {
                Directory.CreateDirectory("CovidVaccination");
                System.Console.WriteLine("Successfully created Covid Vaccination Folder");
            }

            //File for beneficiaryclass
            if (!File.Exists("CovidVaccination/BeneficiaryClass.csv"))
            {
                File.Create("CovidVaccination/BeneficiaryClass.csv").Close();
                System.Console.WriteLine("Successfully created BeneficiaryClass File");
            }

            //File for vaccineclass
            if (!File.Exists("CovidVaccination/VaccineClass.csv"))
            {
                File.Create("CovidVaccination/VaccineClass.csv").Close();
                System.Console.WriteLine("Successfully created VaccineClass File");
            }

            //File for vaccinationclass
            if (!File.Exists("CovidVaccination/VaccinationClass.csv"))
            {
                File.Create("CovidVaccination/VaccinationClass.csv").Close();
                System.Console.WriteLine("Successfully created VaccinationClass File");
            }

        }
        public static void WriteToCSV()
        {
            //Beneficiary Class
            string[] beneficiarys=new string[Operations.beneficiaryList.Count];
            for(int i=0;i<Operations.beneficiaryList.Count;i++)
            {
                beneficiarys[i]=$"{Operations.beneficiaryList[i].RegistrationNumber},{Operations.beneficiaryList[i].Name},{Operations.beneficiaryList[i].Age},{Operations.beneficiaryList[i].Gender},{Operations.beneficiaryList[i].Mobile},{Operations.beneficiaryList[i].City}";
            }
            File.WriteAllLines("CovidVaccination/BeneficiaryClass.csv",beneficiarys);

            //Vaccine class
            string[] vaccines=new string[Operations.vaccineList.Count];
            for(int i=0;i<Operations.vaccineList.Count;i++)
            {
                vaccines[i]=$"{Operations.vaccineList[i].VaccineID},{Operations.vaccineList[i].VaccineName},{Operations.vaccineList[i].DoseAvailable}";
            }
            File.WriteAllLines("CovidVaccination/VaccineClass.csv",vaccines);

            //Vaccination class
            string[] vaccinations=new string[Operations.vaccinationList.Count];
            for(int i=0;i<Operations.vaccinationList.Count;i++)
            {
                vaccinations[i]=$"{Operations.vaccinationList[i].VaccinationID},{Operations.vaccinationList[i].RegistrationNumber},{Operations.vaccinationList[i].VaccineID},{Operations.vaccinationList[i].DoseCount},{Operations.vaccinationList[i].VaccinatedDate.ToString("dd/MM/yyyy")}";
            }
            File.WriteAllLines("CovidVaccination/VaccinationClass.csv",vaccinations);
        }
        public static void ReadfromCSV()
        {
            //BeneficiaryClass
            string[] beneficiarys=File.ReadAllLines("CovidVaccination/BeneficiaryClass.csv");
            foreach(string beneficiary in beneficiarys)
            {
                BeneficiaryClass beneficiary1=new BeneficiaryClass(beneficiary);
                Operations.beneficiaryList.Add(beneficiary1);
            }
            
            //VaccineClass
            string[] vaccines=File.ReadAllLines("CovidVaccination/VaccineClass.csv");
            foreach(string vaccine in vaccines)
            {
                VaccineClass vaccine1=new VaccineClass(vaccine);
                Operations.vaccineList.Add(vaccine1);
            }

            string[] vaccinations=File.ReadAllLines("CovidVaccination/VaccinationClass.csv");
            foreach(string vaccination in vaccinations)
            {
                VaccinationClass vaccination1=new VaccinationClass(vaccination);
                Operations.vaccinationList.Add(vaccination1);
            }
        }
    }
}
