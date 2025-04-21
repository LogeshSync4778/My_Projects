using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace SyncStays
{
    public class Operations
    {
        //Create user List
        public static CustomList<UserRegistration> userList = new CustomList<UserRegistration>();

        //Create Room List
        public static CustomList<RoomDetails> roomList = new CustomList<RoomDetails>();

        //Create RoomSelection List
        public static CustomList<RoomSelectionDetails> roomselectionList = new CustomList<RoomSelectionDetails>();

        //Create Booking List
        public static CustomList<BookingDetails> bookingList = new CustomList<BookingDetails>();

        //Create object for UserRegistration Class
        public static UserRegistration loginUser;

        public static void MainMenu()
        {
            try
            {
                bool flag = true;
                do
                {
                    System.Console.WriteLine("************Main Menu***********");

                    //Show the list of available options in Mainmenu
                    //Ask user to select any option
                    System.Console.WriteLine("Select Choice:\n\t1.User Registration\n\t2.User Login\n\t3.Exit");

                    //Get input from the user
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
                System.Console.WriteLine("************Registration Menu***********");

                //Get details of user one by one
                System.Console.WriteLine("Enter Name: ");
                string username = Console.ReadLine();

                System.Console.WriteLine("Enter Mobile Number: ");
                long mobile = long.Parse(Console.ReadLine());

                System.Console.WriteLine("Enter Aadhar number: ");
                string aadharnumber = Console.ReadLine();

                System.Console.WriteLine("Enter Address: ");
                string address = Console.ReadLine();

                System.Console.WriteLine("Enter Food-Type: (Veg,NonVeg)");
                FoodDetails foodtype = Enum.Parse<FoodDetails>(Console.ReadLine(), true);

                System.Console.WriteLine("Enter Gender: (Male,Female,Transgender)");
                GenderStatus gender = Enum.Parse<GenderStatus>(Console.ReadLine(), true);

                //Create object with the entered details of user
                UserRegistration user = new UserRegistration(username, mobile, aadharnumber, address, foodtype, gender, 0);

                //Add object to the user List
                userList.Add(user);

                //Show successfull message with generated userID
                System.Console.WriteLine("Registration successfull, Your UserID is " + user.UserID);

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
                System.Console.WriteLine("************Login Menu***********");
                //Ask user to enter userID
                System.Console.WriteLine("Enter UserID: ");

                //Get input from the user
                string userID = Console.ReadLine().ToUpper();
                bool flag = false;

                //Traverse userList
                foreach (UserRegistration user in userList)
                {
                    //Check for the entered userID in userList
                    if (user.UserID == userID)
                    {
                        flag = true;

                        //Show the Successfull message
                        System.Console.WriteLine("Login Successful ");

                        //Assign values of user to loginUser
                        loginUser = user;

                        //Call submenu
                        Submenu();
                        break;
                    }
                }
                //If entered userID didn't found in userrList
                if (!flag)
                {
                    System.Console.WriteLine("Invalid User ID. Please enter a valid one");
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
                    System.Console.WriteLine("************SubMenu***********");
                    //Show the list of available options in submenu
                    //Ask user to select a option
                    System.Console.WriteLine("Select Choice:\n\t1.View Customer Profile\n\t2.Book Room\n\t3.Modify Booking\n\t4.Cancel Booking\n\t5.Booking History\n\t6.Wallet Recharge\n\t7.Show Wallet Balance\n\t8.Exit");

                    //Get input from the user
                    int choice = int.Parse(Console.ReadLine());

                    //Check and Call method that choice user selected
                    switch (choice)
                    {
                        case 1:
                            {
                                ViewCustomerProfile();
                                break;
                            }
                        case 2:
                            {
                                BookRoom();
                                break;
                            }
                        case 3:
                            {
                                ModifyBooking();
                                break;
                            }
                        case 4:
                            {
                                CancelBooking();
                                break;
                            }
                        case 5:
                            {
                                BookingHistory();
                                break;
                            }
                        case 6:
                            {
                                WalletRecharge();
                                break;
                            }
                        case 7:
                            {
                                ShowWalletBalance();
                                break;
                            }
                        case 8:
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
        public static void ViewCustomerProfile()
        {
            try
            {
                System.Console.WriteLine("*******Customer Profile********");
                //Traverse userList
                foreach (UserRegistration user in userList)
                {
                    //Check for the login user's userID in userList
                    if (user.UserID == loginUser.UserID)
                    {
                        //Show Details
                        System.Console.WriteLine($"User Name: {user.UserName}\nMobile Number: {user.MobileNumber}\nAadhar Number: {user.AadharNumber}\nAddress: {user.Address}\nGender: {user.Gender}\nFood Type: {user.FoodType}\nWallet Balance: {user.WalletBalance}");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void BookRoom()
        {
            try
            {
                System.Console.WriteLine("************************Room Booking Menu******************************");
                //Create a temporary Bookingobject with initiated status
                BookingDetails booking = new BookingDetails(loginUser.UserID, 0, DateTime.Now, BookingStatus.Initiated);

                //Create a temporary local room
                CustomList<RoomSelectionDetails> tempRoomSelection = new CustomList<RoomSelectionDetails>();
                double TotalRent = 0;
                string option = String.Empty;
                do
                {
                    //Traverse room List
                    foreach (RoomDetails room in roomList)
                    {
                        //Show the list of available rooms
                        System.Console.WriteLine($"Room ID: {room.RoomID}  |  Room Type: {room.RoomType}\t|  No Of Beds: {room.NumberOfBeds}  |  Price per day: {room.PricePerDay}");
                    }
                    //Ask user to enter DateFrom, DateTo, Room ID and no of days booking
                    System.Console.WriteLine("Enter Room ID:");
                    string roomID = Console.ReadLine().ToUpper();
                    bool roomflag = false;

                    //Traverse roomList
                    foreach (RoomDetails room in roomList)
                    {
                        if (roomID == room.RoomID)
                        {
                            roomflag = true;

                            //Get no of days 
                            System.Console.WriteLine("Enter No Of days:");
                            double noofdays = double.Parse(Console.ReadLine());

                            //Get from date
                            System.Console.WriteLine("Enter Date From: (dd/MM/yyyy hh:mm tt)");
                            DateTime dateFrom = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy hh:mm tt", null);

                            //Get to date
                            System.Console.WriteLine("Enter Date To:  (dd/MM/yyyy hh:mm tt)");
                            DateTime dateTo = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy hh:mm tt", null);

                            bool checkflag = true;
                            //Traverse room selection list
                            foreach (RoomSelectionDetails selection in roomselectionList)
                            {
                                //Check the selected room is already booked --> false --> Show - The room is already booked, please select any other room
                                if (selection.RoomID == roomID && selection.Status == BookingStatus.Booked && selection.StayingDateFrom <= dateFrom && selection.StayingDateTo >= dateFrom)
                                {
                                    checkflag = false;
                                    //show the notification message
                                    System.Console.WriteLine("The room is already booked, could you please book any other room");
                                }
                            }
                            if (checkflag)
                            {
                                //Find Total rent
                                double RentPrice = room.PricePerDay * noofdays;
                                TotalRent += RentPrice;

                                //Create room selection object and add into the temporary local room  
                                tempRoomSelection.Add(new RoomSelectionDetails(booking.BookingID, roomID, dateFrom, dateTo, RentPrice, noofdays, BookingStatus.Booked));

                                //Ask user to he had any wish to book another room --> Repeat process while user entering no
                                System.Console.WriteLine("Do you have any wish to book another room:");
                                option = Console.ReadLine().ToLower();
                            }
                        }

                    }
                    if (!roomflag)
                    {
                        System.Console.WriteLine("Invalid Room ID");
                    }
                } while (option != "no");

                //Change booking status to Booked
                booking.Status = BookingStatus.Booked;

                //Change Total Rentprice in Booking list
                booking.TotalPrice = TotalRent;

                //Check user's wallet for the rent amount 
                if (loginUser.WalletBalance >= TotalRent)
                {
                    //Traverse roomList
                    foreach (RoomDetails room in roomList)
                    {
                        //Traverse temproomSelection
                        foreach (RoomSelectionDetails selection in tempRoomSelection)
                        {
                            //Check the selected room is already booked
                            if (room.RoomID == selection.RoomID)
                            {
                                //True --> Deduct rent from user's wallet
                                loginUser.DeductBalance(selection.Price);

                                //Reduce beds available in that room
                                room.NumberOfBeds--;

                                //add local room list to global list
                                roomselectionList.Add(selection);

                                //add booking object to bookinglist
                                bookingList.Add(booking);

                                //Show successfull message with booking ID
                                System.Console.WriteLine("Your rooms successfully booked, your Booking ID is " + booking.BookingID);
                            }
                        }
                    }
                }
                //If user's wallet is low price from rent amount
                else
                {
                    System.Console.WriteLine($"Please recharge with {TotalRent} and proceed.");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void ModifyBooking()
        {
            try
            {
                System.Console.WriteLine("*******Booking Modifying Menu********");
                bool modifyflag = false;
                //Traverse BookingList
                foreach (BookingDetails booking in bookingList)
                {
                    //find login users bookings
                    if (loginUser.UserID == booking.UserID && booking.Status == BookingStatus.Booked)
                    {
                        //Show bookings
                        modifyflag = true;
                        System.Console.WriteLine($"Booking ID: {booking.BookingID}  |  Total Price: {booking.TotalPrice}  |  Booking Date: {booking.DateOfBooking:dd/MM/yyyy hh:mm tt}  |  Booking Status: {booking.Status}");
                    }
                }
                if (!modifyflag)
                {
                    System.Console.WriteLine("Your Booking List is empty !");
                }
                else
                {
                    //Ask user to pick one bookingID
                    System.Console.WriteLine("Select Booking ID to modify: ");

                    //get input from the user
                    string bookingID = Console.ReadLine().ToUpper();
                    bool bookingflag = false;

                    //Traverse BookingList
                    foreach (BookingDetails booking in bookingList)
                    {
                        //Check entered bookingID in list and status in booked state
                        if (booking.BookingID == bookingID && booking.Status == BookingStatus.Booked)
                        {
                            bookingflag = true;
                            //Traverse Selection list
                            foreach (RoomSelectionDetails selection in roomselectionList)
                            {
                                //Find entered bookingID in selection list
                                if (selection.BookingID == bookingID && selection.Status == BookingStatus.Booked)
                                {
                                    //Show selections
                                    System.Console.WriteLine($"Selection ID: {selection.SelectionID} | Room ID: {selection.RoomID} | StayingFrom Date: {selection.StayingDateFrom:dd/MM/yyyy hh:mm tt} | StatingTo Date: {selection.StayingDateTo:dd/MM/yyyy hh:mm tt} | Price: {selection.Price} | No of days: {selection.NumberOfDays} | Status: {selection.Status}");
                                }
                            }
                            //Ask user to enter selection ID to modify
                            System.Console.WriteLine("Enter SelectionID to modify:");

                            //get input from the user
                            string selectionID = Console.ReadLine().ToUpper();

                            //Traverse Selection list
                            foreach (RoomSelectionDetails selection in roomselectionList)
                            {
                                //Find entered bookingID in selection list
                                if (selection.BookingID == bookingID && selection.SelectionID == selectionID && selection.Status == BookingStatus.Booked)
                                {
                                    //Ask user to select option
                                    System.Console.WriteLine("Select option:\n\t1.Cancel Selected room\n\t2.Add new room");

                                    //get input from the user
                                    int choice = int.Parse(Console.ReadLine());

                                    //check the input
                                    switch (choice)
                                    {
                                        case 1:
                                            {
                                                //Traverse RoomList
                                                foreach (RoomDetails room in roomList)
                                                {
                                                    //Check the selected room is already booked 
                                                    if (room.RoomID == selection.RoomID)
                                                    {
                                                        //refund amount to user
                                                        loginUser.WalletRecharge(selection.Price);

                                                        //deduct that amount in bookings
                                                        booking.TotalPrice -= selection.Price;

                                                        //Change the status to cancelled
                                                        selection.Status = BookingStatus.Cancelled;

                                                        //Add Bed cound in Room
                                                        room.NumberOfBeds++;

                                                        //Show the room is cancelled successfully
                                                        System.Console.WriteLine("Selected room Cancelled from your booking");
                                                    }
                                                }
                                                break;
                                            }

                                        case 2:
                                            {
                                                foreach (RoomDetails room in roomList)
                                                {
                                                    //Show the list of available rooms
                                                    System.Console.WriteLine($"Room ID: {room.RoomID}  |  Room Type: {room.RoomType}\t|  No Of Beds: {room.NumberOfBeds}  |  Price per day: {room.PricePerDay}");
                                                }

                                                //Ask user to enter DateFrom, DateTo, Room ID and no of days booking
                                                System.Console.WriteLine("Enter Room ID:");
                                                string roomID = Console.ReadLine().ToUpper();
                                                bool roomflag = false;

                                                //Traverse RoomList
                                                foreach (RoomDetails rooms in roomList)
                                                {
                                                    //Check and find the entered roomID
                                                    if (rooms.RoomID == roomID)
                                                    {
                                                        roomflag = true;
                                                        System.Console.WriteLine("Enter No Of days:");
                                                        double noofdays = double.Parse(Console.ReadLine());
                                                        System.Console.WriteLine("Enter Date From: (dd/MM/yyyy hh:mm tt)");
                                                        DateTime dateFrom = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy hh:mm tt", null);
                                                        System.Console.WriteLine("Enter Date To:  (dd/MM/yyyy hh:mm tt)");
                                                        DateTime dateTo = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy hh:mm tt", null);
                                                        bool flag = true;


                                                        //Traverse room selection list
                                                        foreach (RoomSelectionDetails selection1 in roomselectionList)
                                                        {
                                                            //Check the selected room is already booked --> false --> Show - The room is already booked, please select any other room
                                                            if (selection.RoomID == roomID && selection.Status == BookingStatus.Booked && selection.StayingDateFrom < dateFrom && selection.StayingDateTo > dateFrom)
                                                            {
                                                                flag = false;

                                                                //show the notification message
                                                                System.Console.WriteLine("The room is already booked, could you please book any other room");
                                                            }
                                                        }

                                                        if (flag)
                                                        {
                                                            //Traverse RoomList
                                                            foreach (RoomDetails room in roomList)
                                                            {
                                                                //Check the selected room is already booked
                                                                if (room.RoomID == roomID)
                                                                {
                                                                    //Calculate Rent amount
                                                                    double RentAmount = room.PricePerDay * noofdays;

                                                                    //Check amount in user's wallet
                                                                    if (loginUser.WalletBalance >= RentAmount)
                                                                    {
                                                                        //Deduct the rent amount in user's wallet
                                                                        loginUser.DeductBalance(RentAmount);

                                                                        //add amount to booking details
                                                                        booking.TotalPrice += RentAmount;

                                                                        //Create a selection object and add into list
                                                                        roomselectionList.Add(new RoomSelectionDetails(booking.BookingID, roomID, dateFrom, dateTo, RentAmount, noofdays, BookingStatus.Booked));

                                                                        //Show successfull message
                                                                        System.Console.WriteLine("Booking modified Successfully");
                                                                    }
                                                                    else
                                                                    {
                                                                        System.Console.WriteLine($"Please recharge Rs.{RentAmount} in your wallet before adding new room");
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }

                                                //If entered room was not found in roomList
                                                if (!roomflag)
                                                {
                                                    System.Console.WriteLine("Invalid Room ID");
                                                }
                                                break;
                                            }
                                    }
                                }
                            }
                        }
                    }
                    if (!bookingflag)
                    {
                        System.Console.WriteLine("Invalid Booking ID");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void CancelBooking()
        {
            try
            {
                System.Console.WriteLine("***********Booking Cancellation Menu***********");
                bool cancelflag = false;
                //Traverse booking list
                foreach (BookingDetails booking in bookingList)
                {
                    //Find current user's bookings in booked state
                    if (booking.UserID == loginUser.UserID && booking.Status == BookingStatus.Booked)
                    {
                        cancelflag = true;
                        //Show the bookings
                        System.Console.WriteLine($"Booking ID: {booking.BookingID}  |  Total Price: {booking.TotalPrice}  |  Booking Date: {booking.DateOfBooking:dd/MM/yyyy hh:mm tt}");
                    }
                }
                if (cancelflag)
                {
                    //Ask user to select the bookingId to be cancel
                    System.Console.WriteLine("Select Booking ID to cancel: ");

                    //get input from the user
                    string bookingID = Console.ReadLine().ToUpper();

                    //Traverse booking list
                    foreach (BookingDetails booking in bookingList)
                    {
                        //Check and find the entered booking ID in list
                        if (booking.UserID == loginUser.UserID && booking.Status == BookingStatus.Booked && booking.BookingID == bookingID)
                        {
                            //Change the status to cancelled
                            booking.Status = BookingStatus.Cancelled;

                            //Return the booking amount to user's wallet
                            loginUser.WalletRecharge(booking.TotalPrice);

                            //Traverse Selection list
                            foreach (RoomSelectionDetails selection in roomselectionList)
                            {
                                //Find the entered booking id in selection list
                                if (selection.BookingID == bookingID)
                                {
                                    //Change the booking status to cancelled
                                    selection.Status = BookingStatus.Cancelled;
                                }
                            }
                            //Show successfull message
                            System.Console.WriteLine($"BookingID {bookingID} is cancelled successfully");
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("You didn't book any room");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void BookingHistory()
        {
            try
            {
                System.Console.WriteLine("*******Booking History********");
                bool bookingflag = false;
                //Traverse Booking List
                foreach (BookingDetails booking in bookingList)
                {
                    bookingflag = true;
                    //Find the login users UserID in Booking List
                    if (booking.UserID == loginUser.UserID)
                    {
                        bookingflag = true;
                        //Show the booking details 
                        System.Console.WriteLine($"Booking ID: {booking.BookingID}  |  Total Price: {booking.TotalPrice}  |  Booking Date: {booking.DateOfBooking:dd/MM/yyyy hh:mm tt}  |  Booking Status: {booking.Status}");
                    }
                }
                //If user  didn't make any bookings
                if (!bookingflag)
                {
                    System.Console.WriteLine("Your booking History is empty !");
                }
                else
                {
                    //Ask user to select BookingID
                    System.Console.WriteLine("Select Booking iD: ");

                    //Get input from the user
                    string bookingID = Console.ReadLine().ToUpper();
                    bool flag = false;

                    //Traverse Room selection list
                    foreach (RoomSelectionDetails selection in roomselectionList)
                    {
                        //Find the selected bookingID in selection List
                        if (selection.BookingID == bookingID)
                        {
                            flag = true;
                            //Show the selection Details   
                            System.Console.WriteLine($"Selection ID: {selection.SelectionID} | Room ID: {selection.RoomID} | StayingFrom Date: {selection.StayingDateFrom:dd/MM/yyyy hh:mm tt} | StayingTo Date: {selection.StayingDateTo:dd/MM/yyyy hh:mm tt} | Price: {selection.Price} | No of days: {selection.NumberOfDays} | Status: {selection.Status}");
                        }
                    }
                    //If entered booking ID didn't found in bookinglist
                    if (!flag)
                    {
                        System.Console.WriteLine("Please enter a valid booking ID");
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
                System.Console.WriteLine("*******Recharge Menu********");
                //Ask user to enter the recharge amount
                System.Console.WriteLine("Enter the recharge amount: ");

                //Get input from the user
                double amount = double.Parse(Console.ReadLine());

                //Check the amount is valid
                if (amount > 0)
                {
                    //Add amount to user's wallet
                    loginUser.WalletRecharge(amount);

                    //Show Successfull message with updated balance
                    System.Console.WriteLine("Recharge successful, your current balance is " + loginUser.WalletBalance);
                }

                //If amount is invalid
                else
                {
                    //Show warning message
                    System.Console.WriteLine("Please recharge with valid amount");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void ShowWalletBalance()
        {
            try
            {
                System.Console.WriteLine("Current Balance: " + loginUser.WalletBalance);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void DefaultDetails()
        {
            //Create and add objects to userList
            userList.Add(new UserRegistration("Ravichandran", 995875777, "347777378383", "Chennai", FoodDetails.Veg, GenderStatus.Male, 5000));
            userList.Add(new UserRegistration("Baskaran", 448844848, "474777477477", "Chennai", FoodDetails.NonVeg, GenderStatus.Male, 6000));

            //Create and add objects to RoomList
            roomList.Add(new RoomDetails(RoomStatus.Standard, 2, 500));
            roomList.Add(new RoomDetails(RoomStatus.Standard, 4, 700));
            roomList.Add(new RoomDetails(RoomStatus.Standard, 2, 500));
            roomList.Add(new RoomDetails(RoomStatus.Standard, 2, 500));
            roomList.Add(new RoomDetails(RoomStatus.Standard, 2, 500));
            roomList.Add(new RoomDetails(RoomStatus.Deluxe, 2, 1000));
            roomList.Add(new RoomDetails(RoomStatus.Deluxe, 2, 1000));
            roomList.Add(new RoomDetails(RoomStatus.Deluxe, 4, 1400));
            roomList.Add(new RoomDetails(RoomStatus.Deluxe, 4, 1400));
            roomList.Add(new RoomDetails(RoomStatus.Suit, 2, 2000));
            roomList.Add(new RoomDetails(RoomStatus.Suit, 2, 2000));
            roomList.Add(new RoomDetails(RoomStatus.Suit, 2, 2000));
            roomList.Add(new RoomDetails(RoomStatus.Suit, 4, 2500));

            //Create and add objects to SelectionList
            roomselectionList.Add(new RoomSelectionDetails("BID4001", "RID2001", DateTime.ParseExact("11/11/2024 06:00 AM", "dd/MM/yyyy hh:mm tt", null), DateTime.ParseExact("12/11/2024 02:00 PM", "dd/MM/yyyy hh:mm tt", null), 750, 1.5, BookingStatus.Booked));
            roomselectionList.Add(new RoomSelectionDetails("BID4001", "RID2002", DateTime.ParseExact("11/11/2024 10:00 AM", "dd/MM/yyyy hh:mm tt", null), DateTime.ParseExact("12/11/2024 09:00 AM", "dd/MM/yyyy hh:mm tt", null), 700, 1, BookingStatus.Booked));
            roomselectionList.Add(new RoomSelectionDetails("BID4002", "RID2003", DateTime.ParseExact("12/11/2024 09:00 AM", "dd/MM/yyyy hh:mm tt", null), DateTime.ParseExact("13/11/2024 09:00 AM", "dd/MM/yyyy hh:mm tt", null), 500, 1, BookingStatus.Cancelled));
            roomselectionList.Add(new RoomSelectionDetails("BID4002", "RID2006", DateTime.ParseExact("12/11/2024 06:00 AM", "dd/MM/yyyy hh:mm tt", null), DateTime.ParseExact("13/11/2024 12:30 PM", "dd/MM/yyyy hh:mm tt", null), 1500, 1.5, BookingStatus.Cancelled));

            //Create and add objects for BookingList
            bookingList.Add(new BookingDetails("SF1001", 1450, DateTime.ParseExact("10/11/2024", "dd/MM/yyyy", null), BookingStatus.Booked));
            bookingList.Add(new BookingDetails("SF1002", 2000, DateTime.ParseExact("10/11/2024", "dd/MM/yyyy", null), BookingStatus.Cancelled));

        }
    }
}



