using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public class Operations
    {
        public static List<StudentDetails> studentList = new List<StudentDetails>();
        public static List<AdmissionDetails> admissionList = new List<AdmissionDetails>();
        public static List<DepartmentDetails> departmentList = new List<DepartmentDetails>();
        public static StudentDetails loggedInStudent;

        public static void MainMenu()
        {
            try
            {
                bool choice = true;
                do
                {
                    System.Console.WriteLine("*****************Main Menu****************");
                    //Step1 --> Show the list of options having
                    System.Console.WriteLine("Select Option: \n\t1.Student Registration \n\t2.Student Login \n\t3.Department wise Seat Availability\n\t4.Exit");
                    //Step2 --> Ask for the user input by asking(Select Choice)
                    string option = Console.ReadLine();
                    //Step3 --> Match the option with the correct case
                    switch (option)
                    {
                        case "1":
                            {
                                Registration();
                                break;
                            }
                        case "2":
                            {
                                Login();
                                break;
                            }
                        case "3":
                            {
                                SeatAvailability();
                                break;
                            }
                        case "4":
                            {
                                choice = false;
                                break;
                            }
                    }
                } while (choice);
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
                //Step1 --> Get details from the user 
                Console.Write("Enter Name: ");
                string studentname = Console.ReadLine();
                Console.Write("Enter Father Name: ");
                string fathername = Console.ReadLine();
                Console.Write("Enter Date of Birth (dd/MM/yyyy): ");
                DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                Console.Write("Enter Gender (Male,Female,Transgender): ");
                GenderDetails gender = Enum.Parse<GenderDetails>(Console.ReadLine(), true);
                Console.Write("Enter Physics Marks: ");
                int physics = int.Parse(Console.ReadLine());
                Console.Write("Enter Chemistry Marks: ");
                int chemistry = int.Parse(Console.ReadLine());
                Console.Write("Enter Maths Marks: ");
                int maths = int.Parse(Console.ReadLine());

                //Step2 --> Create object in StudentDetails with the details of the user
                StudentDetails student = new StudentDetails(studentname, fathername, dob, gender, physics, chemistry, maths);
                //Step3 --> Add object to the StudentList
                studentList.Add(student);
                //Step4 --> Display the successfull message and student Id generated
                Console.WriteLine("Student Registered Successfully " + student.StudentID);

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
                System.Console.WriteLine("**************Login*************");
                Console.Write("\nEnter Student ID: ");
                //Step1 --> Ask for the student ID from the user
                string studentID = Console.ReadLine().ToUpper();
                bool flag = true;
                //Step2 --> Traverse Student List
                foreach (StudentDetails student in studentList)
                {
                    //Step3 -->Checks the input with the studentList
                    if (student.StudentID == studentID)
                    {
                        //True --> Show successfull message and show Submenu
                        System.Console.WriteLine("Login Successful");
                        loggedInStudent = student;
                        flag = false;
                        SubMenu();
                        break;
                    }
                }
                if (flag)
                {
                    System.Console.WriteLine("Invalid Id");
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
                bool choice = true;
                do
                {
                    System.Console.WriteLine("********************Sub Menu*******************");
                    //Step1 --> Show list of Options
                    System.Console.WriteLine("Select Option:  \n\t 1.Check Eligibility \n\t 2.Show Details \n\t 3.Take Admission \n\t 4.Cancel Admission \n\t 5.Show Admission Details \n\t 6.Exit");
                    //Step2 --> Get input from the user to choose option
                    int option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            {
                                CheckEligibility();
                                break;
                            }
                        case 2:
                            {
                                ShowDetails();
                                break;
                            }
                        case 3:
                            {
                                TakeAdmission();
                                break;
                            }
                        case 4:
                            {
                                CancelAdmission();
                                break;
                            }
                        case 5:
                            {
                                ShowAdmissionDetails();
                                break;
                            }
                        case 6:
                            {
                                choice = false;
                                break;
                            }
                    }
                } while (choice);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void ShowDetails()
        {
            try
            {
                System.Console.WriteLine("*****Student Details*****");
                //Step1 --> Traverse Student list 
                foreach (StudentDetails student in studentList)
                {

                    //Step2 --> Check the login studentId in student list
                    if (loggedInStudent.StudentID == student.StudentID)
                    {
                        //Display the details of the login user
                        Console.WriteLine($"Name: {student.StudentName}\nFather's name: {student.FatherName}\nDOB: {student.DOB.ToString("dd/MM/yyyy")}");
                        Console.WriteLine($"Gender: {student.Gender}\nPhysics Mark: {student.Physicsmark}\nChemistry Mark: {student.Chemistrymark}\nMaths: {student.Mathsmark}");
                        Console.WriteLine($"Total: {student.Total()}\nAverage: {student.Average()}\n");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void CheckEligibility()
        {
            try
            {
                //Step1 --> Traverse Student List
                foreach (StudentDetails student in studentList)
                {
                    //Step2 --> Check the login studentId in studentList
                    if (student.StudentID == loggedInStudent.StudentID)
                    {
                        //Step3 --> Call Average() method in StudentDetails and store the value into average variable to Find the average marks
                        double average = loggedInStudent.Average();
                        //Step4 --> Check the average marks is eligible or not by calling IsEligible() method in studentList
                        //True
                        if (student.IsEligible(average))
                        {
                            Console.WriteLine("Student is eligible ");
                        }
                        //False
                        else
                        {
                            Console.WriteLine("Student is not eligible ");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void ShowAdmissionDetails()
        {
            try
            {
                System.Console.WriteLine("******Admission Details******");
                bool flag = true;
                //Step1 --> Traverse admissionList
                foreach (AdmissionDetails admission in admissionList)
                {
                    //Step2 --> Traverse departmentList
                    foreach (DepartmentDetails department in departmentList)
                    {
                        //Step3 --> Check the student is booked any admission
                        //True
                        if (loggedInStudent.StudentID == admission.StudentID && department.DepartmentID == admission.DepartmentID)
                        {
                            flag = false;

                            //Show Admission details of the loggedin student
                            Console.WriteLine("\n Admission ID: " + admission.AdmissionID + "\n Department: " + department.DepartmentName + "\n Admission Date: " + admission.AdmissionDate + "\n Admission Status: " + admission.Status);
                        }
                    }
                }

                //False
                if (flag)
                {
                    System.Console.WriteLine("This user didn't book any admission");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void TakeAdmission()
        {
            try
            {
                int count = 0;
                //Step1 --> Check tbe Student's average is greater than 75
                //True
                if (loggedInStudent.IsEligible(loggedInStudent.Average()))
                {
                    foreach (AdmissionDetails admission in admissionList)
                    {
                        if (admission.StudentID == loggedInStudent.StudentID)
                        {
                            count++;
                        }
                    }
                    if (count < 1)
                    {
                        System.Console.WriteLine("******Admission Process******");
                        //Step2 --> Show the list of available departments                                                      
                        foreach (DepartmentDetails department in departmentList)
                        {
                            System.Console.WriteLine($"Department ID : {department.DepartmentID} | Department Name : {department.DepartmentName} | Seats available : {department.NumberOfSeats}");
                        }
                        //Step3 --> Ask input from the user to choose department
                        string departmentID = Console.ReadLine().ToUpper();
                        bool flag = true;
                        //Step4 --> Traverse Department list
                        foreach (DepartmentDetails department in departmentList)
                        {
                            //Step5 --> Check the given department name is a valid or not
                            //True
                            if (department.DepartmentID == departmentID)
                            {
                                flag = false;
                                //Step6 --> Check the seat availability
                                //True 
                                if (department.NumberOfSeats > 0)
                                {
                                    //Step7 --> Create object for the AdmissionDetails
                                    AdmissionDetails admission = new AdmissionDetails(loggedInStudent.StudentID, department.DepartmentID, DateTime.Now, AdmissionStatus.Booked);
                                    //Step8 --> Add Object to the list
                                    admissionList.Add(admission);
                                    //Step 9 --> Decrease seat count
                                    department.NumberOfSeats--;
                                    //Step 10 --> Show the successful message with the AdmissionId generated
                                    System.Console.WriteLine($"Admission took successfully. Your admission ID  {admission.AdmissionID}");
                                    break;
                                }
                                //False
                                else
                                {
                                    System.Console.WriteLine("No NumberOfSeats available in the Selected Department");
                                }
                            }
                        }
                        //False
                        if (flag)
                        {
                            System.Console.WriteLine("Invalid Input");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Admission Booked already");
                    }
                }
                //False
                else
                {
                    System.Console.WriteLine("Your Percentage is below 75, We didn't move foward with your application");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void CancelAdmission()
        {
            try
            {
                System.Console.WriteLine("*******Cancel Admission*******");
                foreach (AdmissionDetails admission in admissionList)
                {
                    if (admission.StudentID == loggedInStudent.StudentID && admission.Status == AdmissionStatus.Booked)
                    {
                        System.Console.WriteLine($"Admission ID: {admission.AdmissionID}\nAdmission Date: {admission.AdmissionDate}\nStatus: {admission.Status}");
                    }
                }
                //Step1 --> Ask input for the admission ID
                System.Console.WriteLine("Enter Admission ID: ");
                string admissionID = Console.ReadLine().ToUpper();
                bool flag1 = true, flag2 = true;
                //Step2 --> Traverse admissionList
                foreach (AdmissionDetails admission in admissionList)
                {
                    //Step3 --> Check for the LoginStudentId in admissionList
                    //True
                    if (admission.StudentID == loggedInStudent.StudentID)
                    {
                        flag1 = false;
                        //Step4 --> Check for the admissionID is valid or not
                        //True
                        if (admission.AdmissionID == admissionID)
                        {
                            flag2 = false;
                            //Step5 --> Change the admission status to Cancelled
                            admission.Status = AdmissionStatus.Cancelled;
                            //Step6 --> Show the successfull message
                            System.Console.WriteLine("Your Admission cancelled SUccessfully");
                            //Step7 --> Traverse departmentList
                            foreach (DepartmentDetails department in departmentList)
                            {
                                //Step8 --> Check the department Id in admissionList with departmentId in departmentList
                                if (admission.DepartmentID == department.DepartmentID)
                                {
                                    //Step9 --> Increase the count of the Seats
                                    department.NumberOfSeats++;
                                }
                            }
                        }
                    }
                }
                //False
                if (flag2)
                {
                    System.Console.WriteLine("This user didn't apply any course");
                    flag1 = false;
                }
                //False
                if (flag1)
                {
                    System.Console.WriteLine("There is no Admission found with this ID !");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void SeatAvailability()
        {
            try
            {
                System.Console.WriteLine("**********Departmentwise Seat Availability*********");
                //Step1 --> Traverse departmentList
                foreach (DepartmentDetails department in departmentList)
                {
                    //Step2 --> Show Department name with Seats available
                    System.Console.WriteLine($"{department.DepartmentName} {department.NumberOfSeats}");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void DefaultData()
        {
            try
            {
                //Create objects for the student1 and student2 in StudentDetails
                StudentDetails student1 = new StudentDetails("Ravichandran E", "Ettapparajan", DateTime.Parse("11/11/1999"), GenderDetails.Male, 95, 95, 95);
                StudentDetails student2 = new StudentDetails("Baskaran S", "Sethurajan", DateTime.Parse("11/11/1999"), GenderDetails.Male, 95, 95, 95);
                //Add objects to the studentList
                studentList.Add(student1);
                studentList.Add(student2);

                //Create object for the admission1 and admission2 in admissionDetails
                AdmissionDetails admission1 = new AdmissionDetails("SF3001", "DID101", DateTime.Parse("12/05/2022"), AdmissionStatus.Booked);
                AdmissionDetails admission2 = new AdmissionDetails("SF3002", "DID102", DateTime.Parse("12/05/2022"), AdmissionStatus.Booked);
                //Add objects to the admissionList
                admissionList.Add(admission1);
                admissionList.Add(admission2);

                //Create objects for the department1,department2,department3 and department4 in departmentDetails
                DepartmentDetails department1 = new DepartmentDetails("EEE", 29);
                DepartmentDetails department2 = new DepartmentDetails("CSE", 29);
                DepartmentDetails department3 = new DepartmentDetails("MECH", 30);
                DepartmentDetails department4 = new DepartmentDetails("ECE", 30);
                //Add objects to the departmentList
                departmentList.Add(department1);
                departmentList.Add(department2);
                departmentList.Add(department3);
                departmentList.Add(department4);

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
    }
}