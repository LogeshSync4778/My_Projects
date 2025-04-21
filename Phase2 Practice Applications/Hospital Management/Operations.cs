using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management
{
    public class Operations
    {
        //Create ObjectLists for the Classes
        public static List<PatientDetails> patientList = new List<PatientDetails>();
        public static List<DoctorDetails> doctorList = new List<DoctorDetails>();
        public static List<AppointmentDetails> appointmentList = new List<AppointmentDetails>();
        public static PatientDetails loginPatient;

        public static void MainMenu()
        {
            try
            {
                bool flag = true;
                do
                {
                    System.Console.WriteLine("************Main Menu************");
                    //Step 1 --> Show the List of available options
                    System.Console.WriteLine("Select Choice: \n\t1.Patient Registration\n\t2.Login\n\t3.Exit\n");
                    //Step 2 --> Get input from the user to select choice
                    int choice = int.Parse(Console.ReadLine());
                    //Step 3 --> Call Method which is selected by user
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
                System.Console.WriteLine("************Registration************");
                //Step 1 --> Get Details from the patient one by one
                System.Console.WriteLine("Enter Your Name: ");
                string name = Console.ReadLine();
                System.Console.WriteLine("Enter Age: ");
                int age = int.Parse(Console.ReadLine());
                System.Console.WriteLine("Enter Gender: (Male,Female,Transgender)");
                GenderDetails gender = Enum.Parse<GenderDetails>(Console.ReadLine(), true);
                //Step 2 --> Create object in PatientDetails with details of patient
                PatientDetails patient = new PatientDetails(name, age, gender, 0);
                //Step 3 --> Add object to the list
                patientList.Add(patient);
                //Step 4 --> Show the Successful message and generated patientID
                System.Console.WriteLine($"Registration Successful, your PatientID is {patient.PatientID}");
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
                System.Console.WriteLine("************Login Menu************");
                //Step 1 --> Ask to enter patientID
                System.Console.WriteLine("Enter Patient ID: ");
                string patientID = Console.ReadLine().ToUpper();
                bool flag = false;
                //Step 2 --> Traverse PatientList
                foreach (PatientDetails patient in patientList)
                {
                    //Step 3--> Check the entered patientID with patientID in patientList
                    //True
                    if (patient.PatientID == patientID)
                    {
                        flag = true;
                        //Step 4 --> Show the successfull message
                        System.Console.WriteLine("Login Successful");
                        //Step 5 --> set details of the patient to loginPatient
                        loginPatient = patient;
                        //Step 6 --> Call Submenu
                        SubMenu();
                        break;
                    }
                }
                if (!flag)
                {
                    System.Console.WriteLine("Invalid Patient ID");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void SubMenu()
        {
            try
            {
                bool flag = true;
                do
                {
                    System.Console.WriteLine("************SubMenu************");
                    //Step 1 --> Show the list of option having
                    System.Console.WriteLine("Select Choice\n\t1.Book Appointment\n\t2.Patient Appointment History\n\t3.Doctor Appointment History");
                    System.Console.WriteLine("\t4.Cancel Appointment\n\t5.Wallet Recharge\n\t6.Exit");
                    //Step 2 --> Ask user to choose any option
                    int choice = int.Parse(Console.ReadLine());
                    //Step 3 --> Call the methods which is user selected
                    switch (choice)
                    {
                        case 1:
                            {
                                BookAppointment();
                                break;
                            }
                        case 2:
                            {
                                PatientAppointmentHistory();
                                break;
                            }
                        case 3:
                            {
                                DoctorAppointmentHistory();
                                break;
                            }
                        case 4:
                            {
                                CancelAppointment();
                                break;
                            }
                        case 5:
                            {
                                WalletRecharge();
                                break;
                            }
                        case 6:
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
        public static void BookAppointment()
        {
            try
            {
                bool doctorflag = true, timeflag = true;
                System.Console.WriteLine("************Appointment Booking Menu************");
                //Step 1 --> Traverse DoctorList
                foreach (DoctorDetails doctor in doctorList)
                {
                    //Step 2 --> Show Doctor Details
                    System.Console.WriteLine($"Doctor ID: {doctor.DoctorID} | Doctor Name: {doctor.DoctorName} | Specialist: {doctor.Specialization} | Fees: {doctor.Fees}");
                }
                //Step 3 --> Ask patient to enter doctor ID
                System.Console.WriteLine("Enter Doctor ID: ");
                string doctorID = Console.ReadLine().ToUpper();
                //Step 4 --> Traverse DoctorList
                foreach (DoctorDetails doctor in doctorList)
                {
                    //Find the entered doctorID in doctor List
                    if (doctor.DoctorID == doctorID)
                    {
                        doctorflag = false;
                        //Step 5 --> Ask patient to enter Appointment Date
                        System.Console.WriteLine("Enter Appointment date: (dd/MM/yyyy)");
                        DateTime appointmentDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                        //Check the Appointment Date is today or a future day
                        if (appointmentDate >= DateTime.Now.Date)
                        {
                            System.Console.WriteLine("Available Time Slots: ");
                            //Step 6 --> Traverse DoctorList 
                            foreach (DoctorDetails doctor1 in doctorList)
                            {
                                //Traverse timings in slotList
                                foreach (string slot in doctor1.SlotList)
                                {
                                    //Find the Entered doctor ID
                                    if (doctor1.DoctorID == doctorID)
                                    {
                                        //Show doctor's available timings
                                        System.Console.WriteLine("\t" + slot);
                                    }
                                }
                            }
                            //Step 7 --> Ask user to pick an appointment
                            System.Console.WriteLine("Enter the Appointment Time: ");
                            string input = Console.ReadLine();
                            //Step 8 --> Traverse DoctorList 
                            foreach (DoctorDetails doctor1 in doctorList)
                            {
                                //Traverse timings in slotList 
                                foreach (string slot in doctor1.SlotList)
                                {
                                    if (slot == input)
                                    {
                                        timeflag = false;
                                        int count = 0;
                                        foreach (AppointmentDetails appointment in appointmentList)
                                        {
                                            //Step 9 --> Check the doctor is available for booking on that date
                                            if (appointment.DoctorID == doctorID && appointment.Status == AppointmentStatus.Booked && appointment.AppointmentDate == appointmentDate)
                                            {
                                                count++;
                                            }
                                        }
                                        //Step 10 --> Check the booking count is Less than 2
                                        //True
                                        if (count < 2)
                                        {
                                            //Step 11 --> Check walletbalance of the patient 
                                            //True
                                            if (loginPatient.WalletBalance >= doctor.Fees)
                                            {
                                                //Book an appointment 
                                                AppointmentDetails appointment = new AppointmentDetails(loginPatient.PatientID, doctor.DoctorID, appointmentDate, input, AppointmentStatus.Booked, doctor.Fees);
                                                appointmentList.Add(appointment);
                                                //Deduct fees of doctor in patient's wallet
                                                loginPatient.DeductBalance(doctor.Fees);
                                                //Show Successfull message and appointment ID
                                                System.Console.WriteLine("Your Appointment created successfully, your appointment ID is " + appointment.AppointmentID);
                                            }
                                            //False --> Ask them to recharge and proceed
                                            else
                                            {
                                                System.Console.WriteLine("Please recharge your wallet and try again");
                                            }
                                        }
                                        //False --> If slots are more than 1
                                        else
                                        {
                                            System.Console.WriteLine("Slot full. Select another date / slot");
                                        }
                                    }
                                }
                            }
                            if (timeflag)
                            {
                                System.Console.WriteLine("Please enter valid time to book appointment");
                            }
                        }
                        //False --> If user enter an Invalid date or past date to book an appointment
                        else
                        {
                            System.Console.WriteLine("Please enter a valid date");
                        }
                    }
                }
                if (doctorflag)
                {
                    System.Console.WriteLine("Incorrect DoctorID");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void PatientAppointmentHistory()
        {
            try
            {
                bool flag = false;
                System.Console.WriteLine("************Patient Appointment History************");
                foreach (AppointmentDetails appointment in appointmentList)
                {
                    if (appointment.PatientID == loginPatient.PatientID)
                    {
                        flag = true;
                        System.Console.WriteLine($"\nAppointment ID: {appointment.AppointmentID}\nDoctor ID: {appointment.DoctorID}\nAppointment Date: {appointment.AppointmentDate:dd/MM/yyyy}");
                        System.Console.WriteLine($"Appointment Time: {appointment.AppointmentSlot}\nAppointment Status: {appointment.Status}\nFees: {appointment.Fees}");
                    }
                }
                if (!flag)
                {
                    System.Console.WriteLine("You didn't book any appointment");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void DoctorAppointmentHistory()
        {
            try
            {
                System.Console.WriteLine("************Doctor Appointment History************");
                //Step 1 --> Traverse doctorList
                foreach (DoctorDetails doctor in doctorList)
                {
                    //Step 2 --> Show Doctor Details
                    System.Console.WriteLine($"Doctor ID: {doctor.DoctorID} | Doctor Name: {doctor.DoctorName} | Specialist: {doctor.Specialization} Fee: {doctor.Fees}");
                }
                //Step 3 --> Ask user to enter doctor ID
                System.Console.WriteLine("Enter doctor ID");
                string doctorID = Console.ReadLine().ToUpper();
                //Step 4 --> Ask user to enter date
                System.Console.WriteLine("Enter date to check: (dd/MM/yyyy) ");
                DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                bool checkflag = false;
                foreach (AppointmentDetails appointment in appointmentList)
                {
                    //Step 5 --> Find the entered doctorID in doctor List
                    //True
                    if (appointment.DoctorID == doctorID && appointment.AppointmentDate == date && appointment.Status == AppointmentStatus.Booked)
                    {
                        checkflag = true;
                        System.Console.WriteLine($"\nAppointment ID: {appointment.AppointmentID}\nPatient ID: {appointment.PatientID}\nTime Slot: {appointment.AppointmentSlot}");
                    }
                }
                //False
                if (!checkflag)
                {
                    System.Console.WriteLine("This doctor didn't get any appointment in this day");
                }

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void CancelAppointment()
        {
            try
            {
                bool flag = false;
                System.Console.WriteLine("************Appointment Cancellation Menu************");
                //Step 3 --> Ask user to enter Appointment ID
                foreach (AppointmentDetails appointment in appointmentList)
                {
                    //Step 2 --> Show appointment details of login patient 
                    if (appointment.PatientID == loginPatient.PatientID && appointment.AppointmentDate.Date >= DateTime.Now.Date && appointment.Status == AppointmentStatus.Booked)
                    {
                        flag = true;
                        System.Console.WriteLine($"\nAppointment ID: {appointment.AppointmentID}\nDoctor ID: {appointment.DoctorID}\nAppointment Date: {appointment.AppointmentDate}\nTimine: {appointment.AppointmentSlot}");
                    }
                }
                if (!flag)
                {
                    System.Console.WriteLine("There is no appointments");
                }
                else
                {
                    System.Console.WriteLine("Enter Appointment ID");
                    string appointmentID = Console.ReadLine().ToUpper();
                    bool checkflag = false;
                    //Step 1 --> Traverse appointment list
                    foreach (AppointmentDetails appointment in appointmentList)
                    {
                        //Step 4 --> Check the AppointmentID is a valid one
                        if (appointment.AppointmentID == appointmentID && appointment.PatientID == loginPatient.PatientID)
                        {
                            checkflag = true;
                            //Step 5 --> Change the appointment status to cancelled
                            appointment.Status = AppointmentStatus.Cancelled;
                            //Step 6 --> Return the fees amount to user's wallet
                            loginPatient.WalletBalance += appointment.Fees;
                            //Step 7 --> Show the successfull message
                            System.Console.WriteLine($"Appointment ID {appointment.AppointmentID} is Successfully cancelled");
                            //Step 8 --> Show submenu
                            SubMenu();
                        }
                    }
                    if (!checkflag)
                    {
                        System.Console.WriteLine("Invalid appointment ID");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void WalletRecharge()
        {
            try
            {
                System.Console.WriteLine("************Wallet Recharge************");
                //Step 1 --> ask user to enter the recharge amount
                System.Console.WriteLine("Enter Recharge amount: ");
                double amount = double.Parse(Console.ReadLine());
                //Step 2 --> check the amount is valid or not
                //True
                if (amount > 0)
                {
                    //Step 3 --> Recharge walletBalance
                    loginPatient.WalletRecharge(amount);
                    //Step 4 --> show successful message and updated balance
                    System.Console.WriteLine("Recharge Successfull\nYour updated balance is " + loginPatient.WalletBalance);
                }
                else
                {
                    System.Console.WriteLine("Please enter valid amount");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void DefaultDetails()
        {
            //Create Objects for DoctorDetails
            DoctorDetails doctor1 = new DoctorDetails("John", 20, Specialist.General, 200, new List<string> { "6.30-7.00", "7.00-7.30", "7.30-8.00", "8.00-8.30", "8.30-9.00" });
            DoctorDetails doctor2 = new DoctorDetails("Saravanan", 30, Specialist.Heart, 500, new List<string> { "6.30-7.00", "7.00-7.30", "7.30-8.00" });
            DoctorDetails doctor3 = new DoctorDetails("Kavi", 40, Specialist.Ortho, 100, new List<string> { "7.30-8.00" });
            //Add objects to the doctorList
            doctorList.Add(doctor1);
            doctorList.Add(doctor2);
            doctorList.Add(doctor3);

            //Create Objects for PatientDetails
            PatientDetails patient1 = new PatientDetails("Arun", 45, GenderDetails.Male, 1000);
            PatientDetails patient2 = new PatientDetails("Kumar", 50, GenderDetails.Male, 500);
            PatientDetails patient3 = new PatientDetails("Malar", 30, GenderDetails.Female, 100);
            PatientDetails patient4 = new PatientDetails("Selvi", 20, GenderDetails.Female, 50);
            //Add objects to the patientList
            patientList.Add(patient1);
            patientList.Add(patient2);
            patientList.Add(patient3);
            patientList.Add(patient4);

            //Create Objects for AppointmentDetals
            AppointmentDetails appointment1 = new AppointmentDetails("PID2001", "DID1001", DateTime.ParseExact("27/10/2024", "dd/MM/yyyy", null), "6.00-6.30", AppointmentStatus.Booked, 200);
            AppointmentDetails appointment2 = new AppointmentDetails("PID2002", "DID1002", DateTime.ParseExact("27/10/2024", "dd/MM/yyyy", null), "6.30-7.00", AppointmentStatus.Booked, 500);
            AppointmentDetails appointment3 = new AppointmentDetails("PID2003", "DID1003", DateTime.ParseExact("27/10/2024", "dd/MM/yyyy", null), "7.30-8.00", AppointmentStatus.Booked, 100);
            AppointmentDetails appointment4 = new AppointmentDetails("PID2001", "DID1003", DateTime.ParseExact("27/10/2024", "dd/MM/yyyy", null), "8.30-9.00", AppointmentStatus.Cancelled, 100);
            //Add Objects to the list
            appointmentList.Add(appointment1);
            appointmentList.Add(appointment2);
            appointmentList.Add(appointment3);
            appointmentList.Add(appointment4);
        }
    }
}