using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourse
{
    public class Operations
    {
        public static List<UserDetails> userList = new List<UserDetails>();
        public static List<CourseDetails> courseList = new List<CourseDetails>();
        public static List<EnrollmentDetails> enrollmentList = new List<EnrollmentDetails>();
        public static UserDetails logInUser;
        public static string courseId = string.Empty;

        public static void MainMenu()
        {
            try
            {
                bool flag = false;
                do
                {
                    System.Console.WriteLine("************Main Menu************");
                    //Step1 --> Show the list of options having
                    System.Console.WriteLine("Select Choice:\n\t1.User Registration\n\t2.User Login\n\t3.Exit");
                    //Step2 --> Asks for the input from the user to select the option
                    int choice = int.Parse(Console.ReadLine());

                    //Step3 --> Call methods of which case should match with users choice
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
                                flag = true;
                                break;
                            }
                    }
                } while (!flag);
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
                //This method is used to craete a new user
                //Get inputs from the user one by one and store the values to the equivalent variables
                System.Console.WriteLine("**********Registration Menu***********");
                System.Console.WriteLine("Enter Name: ");
                string name = Console.ReadLine();
                System.Console.WriteLine("Enter Age: ");
                int age = int.Parse(Console.ReadLine());
                System.Console.WriteLine("Enter Gender: (Male,Female,Transgender)");
                GenderDetails gender = Enum.Parse<GenderDetails>(Console.ReadLine(), true);
                System.Console.WriteLine("Enter Qualificaton: ");
                string qualification = Console.ReadLine();
                System.Console.WriteLine("Enter Mobile Number: ");
                long mobile = long.Parse(Console.ReadLine());
                System.Console.WriteLine("Enter E-Mail ID: ");
                string mailid = Console.ReadLine();

                //Create objects with the values in userlist
                UserDetails user = new UserDetails(name, age, gender, qualification, mobile, mailid);
                //Collects the data from the user and stores in the UserList
                userList.Add(user);
                //Display User ID to the user
                System.Console.WriteLine("Registration Successful, Your userID is " + user.RegistrationID);
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
                System.Console.WriteLine("**********Login Menu***********");
                System.Console.WriteLine("Enter User ID: ");
                //Step1 --> Ask user to enter input ID
                string userid = Console.ReadLine().ToUpper();
                bool flag = false;
                // Step2 --> Traverse userList
                foreach (UserDetails user in userList)
                {
                    // Step3 --> Check for the entered userID in userList
                    // True
                    if (user.RegistrationID == userid)
                    {
                        //Step4 --> Show Successfull message
                        System.Console.WriteLine("Login Successful");
                        flag = true;
                        //Step5 --> Set details of user to loginuser
                        logInUser = user;
                        //Step6 --> Call Submenu 
                        Submenu();
                        break;
                    }
                }
                //False
                if (!flag)
                {
                    //If ID didn't match, shows the message of Invalid User ID
                    System.Console.WriteLine("Invalid User ID, please enter valid one.");
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
                bool flag = false;
                do
                {
                    System.Console.WriteLine("***********SubMenu**************");
                    //Step1 --> Show the list of options
                    System.Console.WriteLine("Select Choice:\n\t1.Enroll Course\n\t2.View Enroll History\n\t3.Next Enrollment\n\t4.Exit");
                    //Step2 --> Ask input from the user to select choice
                    int choice = int.Parse(Console.ReadLine());
                    //Step3 --> Call the method for the matching case user selected
                    switch (choice)
                    {
                        case 1:
                            {
                                EnrollCourse();
                                break;
                            }
                        case 2:
                            {
                                EnrollHistory();
                                break;
                            }
                        case 3:
                            {
                                NextEnrollment();
                                break;
                            }
                        case 4:
                            {
                                //Step5 --> If the User selected exit option, user will returned to the MainMenu
                                flag = true;
                                break;
                            }
                    }

                } while (!flag);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void EnrollCourse()
        {
            try
            {
                System.Console.WriteLine("***********************Enroll COurse**************************");
                
                //Step1 --> Traverse courseList
                foreach (CourseDetails course in courseList)
                {
                    //Step2 --> Display the list of available courses
                    System.Console.WriteLine($"{course.CourseID} {course.CourseName} {course.TrainerName} {course.Duration} {course.Seats}");
                }

                //Step3 --> Asks for the input from the user to choose the course 
                System.Console.Write("Enter course ID to choose: ");
                courseId = Console.ReadLine().ToUpper();
                bool flag = false;
                int count = 0;
                DateTime nextdate = DateTime.MaxValue;

                //Step5 --> Traverse CourseList
                foreach (CourseDetails course in courseList)
                {
                    //Step6 --> Check the courseId have any match with the entered courseID
                    //True
                    if (course.CourseID == courseId)
                    {
                        flag = true;
                        //Step7 --> Checks for the seat availability in the selected course List
                        if (course.Seats > 0)
                        {
                            //Step8 --> Traverse EnrollList
                            foreach (EnrollmentDetails enroll in enrollmentList)
                            {
                                if (enroll.RegistrationID == logInUser.RegistrationID)
                                {
                                    foreach (CourseDetails course2 in courseList)
                                    {
                                        if (course2.CourseID == enroll.CourseID)
                                        {
                                            //Step9 --> Find the enddate 
                                            DateTime enddate = enroll.EnrollmentDate.AddDays(course2.Duration);
                                            //Step 10 --> Check the enddate is greater from today
                                            if (enddate > DateTime.Now)
                                            {
                                                //Step 11 -->Check the enddate is lesser than nextdate
                                                //True
                                                if (nextdate > enddate)
                                                {
                                                    //Step 12 --> Assign enddate value to nextdate
                                                    nextdate = enddate;
                                                }
                                                //Step 13 --> Increment count
                                                count++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //Step 14 --> Check the Count value is lesser than 2
                        //True
                        if (count < 2)
                        {
                            //Step 15 --> Enrolls a new user to the List and show Course name and Enrollment ID
                            EnrollmentDetails enroll = new EnrollmentDetails(course.CourseID, logInUser.RegistrationID, DateTime.Now);
                            course.Seats--;
                            enrollmentList.Add(enroll);
                            System.Console.WriteLine($"Successfully Enrolled for {course.CourseName}, your Enrollment ID is {enroll.EnrollmentID}");
                        }
                        //False
                        else
                        {
                            //Step 16 --> Show the next enrollment date that is stored in nextenroll with the notification message
                            System.Console.WriteLine($"You have already enrolled two courses, your next enrollment date is {nextdate.AddDays(1):dd/MM/yyyy}");
                        }
                    }
                }
                //False --> If the user entered invalid id
                if (!flag)
                {
                    //Step 16 --> Show the warning message
                    System.Console.WriteLine("Invalid Course Id entered");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void EnrollHistory()
        {
            System.Console.WriteLine("*************Enroll History**************");
            bool flag = false;
            //Step1 --> Traverse enrollmentList
            foreach (EnrollmentDetails enroll in enrollmentList)
            {
                //Step2 --> Check login user's registration number in enrollmentList
                //True
                if (enroll.RegistrationID == logInUser.RegistrationID)
                {
                    flag = true;
                    //Step3 --> Show the details of the login user
                    System.Console.WriteLine($"{enroll.EnrollmentID} {enroll.CourseID} {enroll.EnrollmentDate:dd/MM/yyyy}");
                }
            }

            //False --> If the user didn't enroll any course, Displays a notification message
            if (!flag)
            {
                System.Console.WriteLine("The user didn't enrolled any course");
            }
        }
        public static void NextEnrollment()
        {
            DateTime nextdate = DateTime.MaxValue;
            int count = 0;
            //Step1 --> Traverse courseList
            foreach (CourseDetails course in courseList)
            {
                //Step2 --> Check the courseList have any match with the entered courseID
                //True
                if (course.CourseID == courseId)
                {
                    //Step3 --> Traverse EnrollList
                    foreach (EnrollmentDetails enroll in enrollmentList)
                    {
                        //Step4 --> Check for the loginuser in enrollList
                        if (enroll.RegistrationID == logInUser.RegistrationID)
                        {
                            //Step5 --> Traverse courseList
                            foreach (CourseDetails course2 in courseList)
                            {
                                //Step6 --> Check the CourseId in enrollList is any match with CourseId in courseList
                                if (course2.CourseID == enroll.CourseID)
                                {
                                    DateTime enddate = enroll.EnrollmentDate.AddDays(course2.Duration);
                                    //Step7 --> Check the enddate is greater from today
                                    if (enddate > DateTime.Now)
                                    {
                                        //Step8 --> Check the enddate is lesser than nextdate
                                        //True
                                        if (nextdate > enddate)
                                        {
                                            //Step9 --> Assign enddate value to nextdate
                                            nextdate = enddate;
                                        }
                                        //Step 10 -->Increase count
                                        count++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //Step 11 --> Check the Count value is lesser than 2
            //True
            if (count < 2)
            {
                System.Console.WriteLine($"Your next enrollment date is {DateTime.Now:dd/MM/yyyy}");
            }
            //False
            else
            {
                System.Console.WriteLine($"Your next enrollment date is {nextdate.AddDays(1):dd/MM/yyyy}");
            }
        }
        public static void DefaultDetails()
        {
            //Step1 --> Create objects of user1 and user2 in UserDetails
            UserDetails user1 = new UserDetails("Ravichandran", 30, GenderDetails.Male, "ME", 9938388333, "ravi@gmail.com");
            UserDetails user2 = new UserDetails("Priyadharshini", 25, GenderDetails.Female, "BE", 9944444455, "priya@gmail.com");
            //Step2 --> Add objects to userList
            userList.Add(user1);
            userList.Add(user2);

            //Step3 --> Create objects of course1, course2, course3, course4 and course5 in courseList
            CourseDetails course1 = new CourseDetails("C#", "Baskaran", 5, 0);
            CourseDetails course2 = new CourseDetails("HTML", "Ravi", 2, 5);
            CourseDetails course3 = new CourseDetails("CSS", "Priyadharshini", 2, 3);
            CourseDetails course4 = new CourseDetails("JS", "Baskaran", 3, 1);
            CourseDetails course5 = new CourseDetails("TS", "Ravi", 1, 2);
            //Step4 --> Add objects to userList
            courseList.Add(course1);
            courseList.Add(course2);
            courseList.Add(course3);
            courseList.Add(course4);
            courseList.Add(course5);

            //Step5 --> Create objects of enroll1, enroll2, enroll3 and enroll4 in enrollmentList
            EnrollmentDetails enroll1 = new EnrollmentDetails("CS2001", "SYNC1001", DateTime.ParseExact("28/01/2024", "dd/MM/yyyy", null));
            EnrollmentDetails enroll2 = new EnrollmentDetails("CS2003", "SYNC1001", DateTime.ParseExact("15/02/2024", "dd/MM/yyyy", null));
            EnrollmentDetails enroll3 = new EnrollmentDetails("CS2004", "SYNC1002", DateTime.ParseExact("18/02/2024", "dd/MM/yyyy", null));
            EnrollmentDetails enroll4 = new EnrollmentDetails("CS2002", "SYNC1002", DateTime.ParseExact("20/02/2024", "dd/MM/yyyy", null));
            //Step6 --> Add objects to userList
            enrollmentList.Add(enroll1);
            enrollmentList.Add(enroll2);
            enrollmentList.Add(enroll3);
            enrollmentList.Add(enroll4);
        }
    }
}