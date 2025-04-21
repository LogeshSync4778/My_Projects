using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.AccessControl;
using System.Threading.Tasks;
using MyList;

namespace CovidVaccination
{
    public class Operations
    {
        public static CustomBeneficiaryList<BeneficiaryClass> beneficiaryList = new CustomBeneficiaryList<BeneficiaryClass>();
        public static CustomVaccinationList<VaccinationClass> vaccinationList = new CustomVaccinationList<VaccinationClass>();
        public static CustomVaccineList<VaccineClass> vaccineList = new CustomVaccineList<VaccineClass>();
        public static BeneficiaryClass loginUser;

        public static void MainMenu()
        {
            try
            {
                bool flag = true;
                do
                {
                    //Step1 --> Show the list of options
                    System.Console.WriteLine("*************Main Menu**************");
                    System.Console.WriteLine("Select Choice:\n\t1.Beneficiary Registration\n\t2.Login\n\t3.Get Vaccine Information\n\t4.Exit");
                    //Step2 --> Ask input from the user to select option
                    int choice = int.Parse(Console.ReadLine());
                    //Step3 --> Call method which is equals to selected choice
                    switch (choice)
                    {
                        case 1:
                            {
                                Registration();
                                break;
                            }
                        case 2:
                            {
                                Login();
                                break;
                            }
                        case 3:
                            {
                                GetVaccineInformation();
                                break;
                            }
                        case 4:
                            {
                                flag = false;
                                break;
                            }
                    }
                } while (flag);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void Registration()
        {
            try
            {
                //Step1 --> Get details from the user one by one
                System.Console.WriteLine("*************Registration**************");
                System.Console.WriteLine("Enter Name: ");
                string name = Console.ReadLine();
                System.Console.WriteLine("Enter Age: ");
                int age = int.Parse(Console.ReadLine());
                System.Console.WriteLine("Enter Gender: (Male,Female,Transgender)");
                GenderDetails gender = Enum.Parse<GenderDetails>(Console.ReadLine(), true);
                System.Console.WriteLine("Enter Mobile Number: ");
                long mobile = long.Parse(Console.ReadLine());
                System.Console.WriteLine("Enter City: ");
                string city = Console.ReadLine();

                //Step2 --> Create object in Beneficiary class with entered details of the user
                BeneficiaryClass beneficiary = new BeneficiaryClass(name, age, gender, mobile, city);
                //Step3 --> Add object to the list
                beneficiaryList.Add(beneficiary);
                //Step4 --> Show successfull message and display the generated registrationID
                System.Console.WriteLine("Registration Successfull, your Beneficiary number is " + beneficiary.RegistrationNumber);

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void Login()
        {
            try
            {
                System.Console.WriteLine("*************Login**************");
                //Step1 --> Ask input of registrationID from the user
                System.Console.WriteLine("Enter Registration Number: ");
                string registrationnumber = Console.ReadLine().ToUpper();
                bool flag = false;
                //Step2 --> Traverse Beneficiary list
                foreach (BeneficiaryClass beneficiary in beneficiaryList)
                {
                    //Step3 --> Check the beneficiary list contains the entered registration number
                    //True
                    if (beneficiary.RegistrationNumber == registrationnumber)
                    {
                        //Step4 --> Set values of the current user to loginUser
                        loginUser = beneficiary;
                        //Step5 --> Show Successful message
                        System.Console.WriteLine("Login Successful");
                        flag = true;
                        //Step6 --> Call Submenu
                        Submenu();
                        break;
                    }
                }
                //False --> Entered input didn't match with any register number in beneficiary class
                if (!flag)
                {
                    System.Console.WriteLine("Invalid Register Number");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void Submenu()
        {
            try
            {
                bool flag = true;
                do
                {
                    //Step1 --> Show list of options
                    System.Console.WriteLine("*************Sub Menu**************");
                    System.Console.WriteLine("Select Choice:\n\t1.Show My Details\n\t2.Take Vaccination\n\t3.My Vaccination History\n\t4.Next Due Date\n\t5.Exit");
                    //Step2 --> Ask input from the user to select choice
                    int choice = int.Parse(Console.ReadLine());
                    //Step3 --> Call method that which case user was selected
                    switch (choice)
                    {
                        case 1:
                            {
                                ShowmyDetails();
                                break;
                            }
                        case 2:
                            {
                                TakeVaccination();
                                break;
                            }
                        case 3:
                            {
                                MyVaccinationHistory();
                                break;
                            }
                        case 4:
                            {
                                NextDueDate();
                                break;
                            }
                        case 5:
                            {
                                flag = false;
                                break;
                            }
                    }

                } while (flag);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void ShowmyDetails()
        {
            try
            {
                System.Console.WriteLine("*************My Details**************");
                //Step1 --> Traverse Beneficiary Class
                foreach (BeneficiaryClass beneficiary in beneficiaryList)
                {
                    //Step2 --> Check for the user registraion number of the login user in benecifiary list
                    if (beneficiary.RegistrationNumber == loginUser.RegistrationNumber)
                    {
                        //Step3 --> Show the details of the current user
                        System.Console.WriteLine($"Name: {beneficiary.Name}\nAge: {beneficiary.Age}\nGender : {beneficiary.Gender}");
                        System.Console.WriteLine($"Mobile: {beneficiary.Mobile}\nCity: {beneficiary.City}");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void TakeVaccination()
        {
            try
            {
                bool vaccineflag = false, flag = false;
                int count = 0;
                System.Console.WriteLine("*************Take Vaccination**************");
                //Step1 --> Traverse vaccineList
                foreach (VaccineClass vaccine in vaccineList)
                {
                    //Step2 --> Show list of available vaccines
                    System.Console.WriteLine($"VaccineID : {vaccine.VaccineID} Vaccine Name: {vaccine.VaccineName}");
                }
                //Step3 --> Ask user to select vaccine ID
                string vaccineID = Console.ReadLine().ToUpper();
                //Step4 --> Traverse vaccineList
                foreach (VaccineClass vaccine in vaccineList)
                {
                    //Step5 --> Search for the enter vaccineId in vaccineList
                    //True
                    if (vaccine.VaccineID == vaccineID)
                    {
                        vaccineflag = true;
                        //Step6 --> Traverse vaccinationList
                        foreach (VaccinationClass vaccination in vaccinationList)
                        {
                            //Step7 --> Check for user's registration number in vaccinationList
                            if (vaccination.RegistrationNumber == loginUser.RegistrationNumber)
                            {
                                //Step8 --> Increment the count when the condition is true
                                count++;
                            }
                        }
                        //Step9 --> If it was an new beneficiary
                        if (count == 0)
                        {
                            //Step 10 --> Check the user's age is above 14
                            //True
                            if (loginUser.Age > 14)
                            {
                                //Step 11 --> Add beneficiary details to vaccinationList
                                VaccinationClass newVaccination = new VaccinationClass(loginUser.RegistrationNumber, vaccine.VaccineID, DoseDetails.one, DateTime.Now);
                                vaccinationList.Add(newVaccination);
                                //Step 12 --> Decrease the count of the vaccine in total stock
                                vaccine.DoseAvailable--;
                                //Step 13 --> Show the successfull message
                                System.Console.WriteLine($"Vaccination Successfull");
                            }
                            //False
                            else
                            {
                                System.Console.WriteLine("Beneficiary is not eligible for vaccination");
                            }
                        }
                        //Step 14 --> Traverse vaccinationList
                        foreach (VaccinationClass vaccination in vaccinationList)
                        {
                            //Step 15 --> Check for the login beneficiaryID and entered vaccineId entered with user already vaccinated
                            //True
                            if (loginUser.RegistrationNumber == vaccination.RegistrationNumber && vaccination.VaccineID == vaccineID)
                            {
                                flag = true;
                                //Step 16 --> Check the count is 3
                                if (count == 3)
                                {
                                    System.Console.WriteLine("All the three vaccinations are completed, you cannot be vaccinated now.");
                                }
                                //Step 17 --> Check the count is 2
                                if (count == 2)
                                {
                                    //Check for the vaccinated date is more than 30 day past
                                    //True
                                    if (vaccination.VaccinatedDate.AddDays(30) <= DateTime.Now)
                                    {
                                        VaccinationClass newVaccination = new VaccinationClass(loginUser.RegistrationNumber, vaccine.VaccineID, DoseDetails.three, DateTime.Now);
                                        vaccinationList.Add(newVaccination);
                                        vaccine.DoseAvailable--;
                                        System.Console.WriteLine($"Vaccination Successful");
                                    }
                                    //False
                                    else
                                    {
                                        TimeSpan span = vaccination.VaccinatedDate.AddDays(30) - DateTime.Now;
                                        System.Console.WriteLine($"Please wait for {((int)span.TotalDays)} days for next vaccination");
                                    }
                                }
                                //Step 18 --> Check the count is 1
                                if (count == 1)
                                {
                                    //Check for the vaccinated date is more than 30 day past
                                    //True
                                    if (vaccination.VaccinatedDate.AddDays(30) <= DateTime.Now)
                                    {
                                        VaccinationClass newVaccination = new VaccinationClass(loginUser.RegistrationNumber, vaccine.VaccineID, DoseDetails.two, DateTime.Now);
                                        vaccinationList.Add(newVaccination);
                                        vaccine.DoseAvailable--;
                                        System.Console.WriteLine($"Vaccination Successful");
                                    }
                                    //False
                                    else
                                    {
                                        TimeSpan span = vaccination.VaccinatedDate.AddDays(30) - DateTime.Now;
                                        System.Console.WriteLine($"Please wait for {((int)span.TotalDays)} days for next vaccination");
                                    }
                                }
                                break;
                            }
                        }
                        //False --> If beneficiary selected different vaccinated ID
                        if (!flag)
                        {
                            //Step1 --> Traverse vaccinationList
                            foreach (VaccinationClass vaccination in vaccinationList)
                            {
                                //Step2 --> Check for the login beneficiary's registration number in vaccinationList
                                if (vaccination.RegistrationNumber == loginUser.RegistrationNumber)
                                {
                                    //Step3 --> Traverse vaccine list
                                    foreach (VaccineClass vaccine1 in vaccineList)
                                    {
                                        //Step4 --> Check the vaccine name used by beneficiary
                                        if (vaccine1.VaccineID == vaccination.VaccineID)
                                        {
                                            //Step5 --> show the notification message of beneficiary's vaccine name and user selected different vaccine 
                                            System.Console.WriteLine($"You have selected a different vaccine. You can vaccine with {vaccine1.VaccineName}");
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                //False --> If entered vaccinationID didn't match
                if (!vaccineflag)
                {
                    System.Console.WriteLine("Invalid Vaccination ID");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void MyVaccinationHistory()
        {
            try
            {
                bool flag = false;
                System.Console.WriteLine("*************Vaccination History**************");
                //Step1 --> Traverse vaccinationList
                foreach (VaccinationClass vaccination in vaccinationList)
                {
                    //Step2 --> Check for the user's registration number in vaccinationList
                    if (vaccination.RegistrationNumber == loginUser.RegistrationNumber)
                    {
                        flag = true;
                        //Show the Vaccination Count and vaccination Date of the beneficiary
                        System.Console.WriteLine($"Dose {vaccination.DoseCount} : {vaccination.VaccinatedDate:dd/MM/yyyy}");
                    }
                }
                //False --> If user didn't take any dose
                if (!flag)
                {
                    System.Console.WriteLine("This Beneficiary didn't take any dose");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void NextDueDate()
        {
            try
            {
                DateTime nextduedate = DateTime.Now;
                int count = 0;
                System.Console.WriteLine("*************Next Due Date**************");
                //Step1 --> Traverse vaccinationList
                foreach (VaccinationClass vaccination in vaccinationList)
                {
                    //Step2 --> Check the Registernumber or user in vaccinationList
                    if (vaccination.RegistrationNumber == loginUser.RegistrationNumber)
                    {
                        //Step3 --> Increase count for every vaccination of user
                        count++;
                        //Step3 --> Check the VaccinationDate is 30 days past from today
                        //True
                        if(vaccination.VaccinatedDate.AddDays(30)>DateTime.Now)
                        {
                            //Step4 --> Assign the date to nextduedate
                            nextduedate=vaccination.VaccinatedDate.AddDays(30);
                        }
                    }
                }
                //Step5 --> Check user didn't take a vaccine
                if (count == 0)
                {
                    //Show  the notification message to take vaccine now
                    System.Console.WriteLine("You can take the vaccine now");
                }
                //Step6 --> Check user can take 3 vaccines
                if (count == 3)
                {
                    //Show  the notification message for completion of all doses of vaccinaion
                    System.Console.WriteLine("You have completed all vaccination. Thanks for your participation in the vaccination drive");
                }
                //Step7 --> Check for dose count is either 1 or 2
                if (count == 1 || count == 2)
                {
                    //Show the beneficiary's eligible date for next vaccination
                    System.Console.WriteLine($"Your next due date for vaccination is {nextduedate:dd/MM/yyyy}");
                }


            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void GetVaccineInformation()
        {
            try
            {
                System.Console.WriteLine("*************Vaccine  Information**************");
                //Step1 --> Traverse vaccineList
                foreach(VaccineClass vaccine in vaccineList)
                {
                    //Step2 --> Show the list of available vaccine names and stock of the vaccines
                    System.Console.WriteLine($"Vaccine Name: {vaccine.VaccineName}  |  Total Stock: {vaccine.DoseAvailable}");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void DefaultData()
        {
            //Create Objects for BeneficiaryClass
            BeneficiaryClass beneficiary1 = new BeneficiaryClass("Ravichandran", 21, GenderDetails.Male, 8484484123, "Chennai");
            BeneficiaryClass beneficiary2 = new BeneficiaryClass("Baskaran", 22, GenderDetails.Male, 8484747321, "Chennai");
            //Add the objects to the beneficiaryList
            beneficiaryList.Add(beneficiary1);
            beneficiaryList.Add(beneficiary2);

            //Create objects for VaccineClass
            VaccineClass vaccine1 = new VaccineClass(VaccineDetails.Covishield, 50);
            VaccineClass vaccine2 = new VaccineClass(VaccineDetails.Covaccine, 50);
            //Add the objects to the vaccineList
            vaccineList.Add(vaccine1);
            vaccineList.Add(vaccine2);

            //Create objects for VaccinationClass
            VaccinationClass vaccination1 = new VaccinationClass("BID1001", "CID2001", DoseDetails.one, DateTime.ParseExact("31/03/2024", "dd/MM/yyyy", null));
            VaccinationClass vaccination2 = new VaccinationClass("BID1001", "CID2001", DoseDetails.two, DateTime.ParseExact("30/04/2024", "dd/MM/yyyy", null));
            VaccinationClass vaccination3 = new VaccinationClass("BID1002", "CID2002", DoseDetails.one, DateTime.ParseExact("04/03/2024", "dd/MM/yyyy", null));
            //Add the objects to the vaccinationClass
            vaccinationList.Add(vaccination1);
            vaccinationList.Add(vaccination2);
            vaccinationList.Add(vaccination3);
        }
    }
}