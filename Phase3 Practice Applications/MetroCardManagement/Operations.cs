using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class Operations
    {
        //Create userList
        public static CustomList<UserDetails> userList = new CustomList<UserDetails>();
        //Create travelList
        public static CustomList<TravelDetails> travelList = new CustomList<TravelDetails>();
        //Create ticketfairList
        public static CustomList<TicketFairDetails> ticketfairList = new CustomList<TicketFairDetails>();
        //Create object for userDetails
        public static UserDetails loginUser;

        public static void MainMenu()
        {
            try
            {
                bool flag = true;
                do
                {
                    //Show the list of available option in Mainmenu
                    System.Console.WriteLine("**************Main Menu***************");
                    System.Console.WriteLine("Select Choice:\n\t1.User Registration\n\t2.Login User\n\t3.Exit");
                    //get input from the user
                    int choice = int.Parse(Console.ReadLine());
                    //Call method that user selected
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
                System.Console.WriteLine("**************Registration Menu***************");
                //Get details from the user
                System.Console.WriteLine("Enter Name:");
                string name = Console.ReadLine();
                System.Console.WriteLine("Phone no:");
                long phone = long.Parse(Console.ReadLine());

                //Create objects in userdetails with entered details of user
                UserDetails user = new UserDetails(name, phone, 0);
                //Add object to the list
                userList.Add(user);
                //Show the generated card number to user
                System.Console.WriteLine("Registration Successful, your Card number is " + user.CardNumber);
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
                System.Console.WriteLine("**************Login Menu***************");
                System.Console.WriteLine("Enter Card Number: ");
                //Get card number from the user
                string cardNumber = Console.ReadLine().ToUpper();
                bool flag = false;
                //Traverse userlist
                foreach (UserDetails user in userList)
                {
                    //Check the entered cardnumber in userlist
                    if (user.CardNumber == cardNumber)
                    {
                        //True --> set values of user to loginuser
                        loginUser = user;
                        flag = true;
                        //Call SUbmenu
                        SubMenu();
                        break;
                    }
                }
                if (!flag)
                {
                    System.Console.WriteLine("Invalid Card Number");
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
                    //Show the list of available option in Submenu
                    System.Console.WriteLine("**************SubMenu***************");
                    System.Console.WriteLine("Select Choice:\n\t1.Balance Check\n\t2.Recharge\n\t3.View Travel History\n\t4.Travel\n\t5.Exit");
                    //Get input from the user to select choice
                    int choice = int.Parse(Console.ReadLine());
                    //Call method for selected choice
                    switch (choice)
                    {
                        case 1:
                            {
                                BalanceCheck();
                                break;
                            }
                        case 2:
                            {
                                Recharge();
                                break;
                            }
                        case 3:
                            {
                                ViewTravelHistory();
                                break;
                            }
                        case 4:
                            {
                                Travel();
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
        public static void BalanceCheck()
        {
            try
            {
                //Show the Wallet balance of login user
                System.Console.WriteLine("Balance: " + loginUser.Balance);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void Recharge()
        {
            try
            {
                System.Console.WriteLine("***********Recharge Menu************");
                System.Console.WriteLine("Enter amount to be recharge: ");
                //Get recharge amount from the user
                double amount = double.Parse(Console.ReadLine());
                //Add the amount to login customer's wallet
                loginUser.WalletRecharge(amount);
                //Show the updated balance to user
                System.Console.WriteLine("Recharge Successful, Updated Balance: " + loginUser.Balance);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void ViewTravelHistory()
        {
            try
            {
                bool travelflag = false;
                System.Console.WriteLine("**************Travel History***************");
                //Traverse travelList
                foreach (TravelDetails travel in travelList)
                {
                    //Find the login user's card number in travelList
                    if (travel.CardNumber == loginUser.CardNumber)
                    {
                        //Shown the details of login user
                        travelflag = true;
                        System.Console.WriteLine($"Travel ID: {travel.TravelID} | From Location: {travel.FromLocation} | To Location: {travel.ToLocation} | Travel Date: {travel.TravelDate:dd/MM/yyyy} | Travel Cost: {travel.TravelCost}");
                    }
                }
                //If login user's card number didn't found
                if (!travelflag)
                {
                    System.Console.WriteLine("You didn't book any Travel");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void Travel()
        {
            try
            {
                System.Console.WriteLine("**************Travel***************");
                //Traverse ticketfairList
                foreach (TicketFairDetails ticket in ticketfairList)
                {
                    System.Console.WriteLine($"Ticket ID: {ticket.TicketID} | From Location: {ticket.FromLocation}\t| To Location: {ticket.ToLocation} | Ticket Price: {ticket.TicketPrice}");
                }
                //Ask user to select ticket ID to book travel
                System.Console.WriteLine("Select Travel ID to get ticket:");
                string ticketID = Console.ReadLine().ToUpper();
                bool ticketflag = false;
                //Traverse ticketfairList
                foreach (TicketFairDetails ticket in ticketfairList)
                {
                    //Find the ticketId in ticketfairList
                    if (ticketID == ticket.TicketID)
                    {
                        ticketflag = true;
                        //Check login user's wallet
                        if (loginUser.Balance >= ticket.TicketPrice)
                        {
                            //Deduct the ticket price in user's wallet
                            loginUser.DeductBalance(ticket.TicketPrice);
                            //Create object for travelDetails
                            TravelDetails travel = new TravelDetails(loginUser.CardNumber, ticket.FromLocation, ticket.ToLocation, DateTime.Now, ticket.TicketPrice);
                            //Add object to the travelList
                            travelList.Add(travel);
                            //Show the successfull message and generated travelID to user
                            System.Console.WriteLine("Ticket booked successfully, Your Travel ID is " + travel.TravelID);
                        }
                        else
                        {
                            System.Console.WriteLine("Please recharge your wallet to proceed");
                        }
                    }
                }
                if (!ticketflag)
                {
                    System.Console.WriteLine("Invalid Ticket ID");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void DefaultDetails()
        {
            //Create and add objects for userDetails
            userList.Add(new UserDetails("Ravi", 9848812345, 100));
            userList.Add(new UserDetails("Baskaran", 9948854321, 50));

            //Create and add objects for travelDetails
            travelList.Add(new TravelDetails("CMRL1001", Location.Airport, Location.Egmore, DateTime.ParseExact("10/10/2023", "dd/MM/yyyy", null), 55));
            travelList.Add(new TravelDetails("CMRL1001", Location.Egmore, Location.Koyambedu, DateTime.ParseExact("10/10/2023", "dd/MM/yyyy", null), 32));
            travelList.Add(new TravelDetails("CMRL1002", Location.Alandur, Location.Koyambedu, DateTime.ParseExact("10/11/2023", "dd/MM/yyyy", null), 40));
            travelList.Add(new TravelDetails("CMRL1002", Location.Egmore, Location.Thirumangalam, DateTime.ParseExact("10/11/2023", "dd/MM/yyyy", null), 25));

            //Create and add objects for ticketFairDetails
            ticketfairList.Add(new TicketFairDetails(Location.Airport, Location.Egmore, 55));
            ticketfairList.Add(new TicketFairDetails(Location.Airport, Location.Koyambedu, 25));
            ticketfairList.Add(new TicketFairDetails(Location.Alandur, Location.Koyambedu, 40));
            ticketfairList.Add(new TicketFairDetails(Location.Egmore, Location.Koyambedu, 32));
            ticketfairList.Add(new TicketFairDetails(Location.Vadapalani, Location.Egmore, 45));
            ticketfairList.Add(new TicketFairDetails(Location.Arumbakkam, Location.Egmore, 30));
            ticketfairList.Add(new TicketFairDetails(Location.Vadapalani, Location.Koyambedu, 20));
            ticketfairList.Add(new TicketFairDetails(Location.Egmore, Location.Thirumangalam, 25));
        }
    }
}