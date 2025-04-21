using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieTicketBooking
{
    public class Operations
    {
        //Creating userList
        public static CustomList<UserDetails> userList = new CustomList<UserDetails>();

        //Creating bookingList
        public static CustomList<BookingDetails> bookingList = new CustomList<BookingDetails>();

        //Creating theatreList
        public static CustomList<TheatreDetails> theatreList = new CustomList<TheatreDetails>();

        //Creating movieList
        public static CustomList<MovieDetails> movieList = new CustomList<MovieDetails>();

        //Creating screeningList
        public static CustomList<ScreeningDetails> screeningList = new CustomList<ScreeningDetails>();

        //Creating object for UserDetails
        public static UserDetails loginUser;

        public static void MainMenu()
        {
            try
            {
                bool flag = true;
                do
                {
                    //Show the list of option available in Mainmenu
                    System.Console.WriteLine("*************Main Menu*************");
                    System.Console.WriteLine("Select choice:\n\t1.User Registration\n\t2.Login\n\t3.Exit");

                    //Ask user to enter select choice
                    int choice = int.Parse(Console.ReadLine());

                    //Call method which is user selected
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
                System.Console.WriteLine("*************Registration Menu*************");

                //Get details from the user one by one
                System.Console.WriteLine("Enter Name:");
                string name = Console.ReadLine();

                System.Console.WriteLine("Enter Age:");
                int age = int.Parse(Console.ReadLine());

                System.Console.WriteLine("Enter Phone no:");
                long phone = long.Parse(Console.ReadLine());

                System.Console.WriteLine("Gender: (Male,Female,Others)");
                GenderStatus gender = Enum.Parse<GenderStatus>(Console.ReadLine(), true);

                //Create object in userdetails with entered user details
                UserDetails user = new UserDetails(name, age, phone, gender, 0);

                //Add object to the userList
                userList.Add(user);

                //Show the successful message with generated userID
                System.Console.WriteLine("Registration successful, your UserID is " + user.UserID);
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
                System.Console.WriteLine("*************Login Menu*************");

                //Ask user to enter userID
                System.Console.WriteLine("Enter User ID: ");

                //Get input from the user
                string userID = Console.ReadLine().ToUpper();
                bool flag = false;

                //Traverse userList
                foreach (UserDetails user in userList)
                {
                    //Check the entered userID in userList
                    if (user.UserID == userID)
                    {
                        flag = true;
                        //Show the successful message
                        System.Console.WriteLine("Login Successful");

                        //Assign values of user to loginUser
                        loginUser = user;

                        //Call Submenu
                        SubMenu();
                        break;
                    }
                }
                //If Id wan not found a match
                if (!flag)
                {
                    System.Console.WriteLine("Invalid User ID");
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
                    //Show the list of available options
                    System.Console.WriteLine("*************SubMenu*************");
                    System.Console.WriteLine("Select Choice:\n\t1.Ticket Booking\n\t2.Ticket Cancellation\n\t3.Booking History\n\t4.Wallet Recharge\n\t5.Show Wallet Balance\n\t6.Exit");

                    //Get input from the user
                    int choice = int.Parse(Console.ReadLine());

                    //Call method that matches user selected
                    switch (choice)
                    {
                        case 1:
                            {
                                TicketBooking();
                                break;
                            }
                        case 2:
                            {
                                TicketCancellation();
                                break;
                            }
                        case 3:
                            {
                                BookingHistory();
                                break;
                            }
                        case 4:
                            {
                                WalletRecharge();
                                break;
                            }
                        case 5:
                            {
                                ShowBalance();
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
        public static void TicketBooking()
        {
            try
            {
                System.Console.WriteLine("******************Ticket Booking Menu**********************");

                //Traverse Theatre List
                foreach (TheatreDetails theatre in theatreList)
                {
                    //Show the details
                    System.Console.WriteLine($"Theatre ID: {theatre.TheatreID}  |  Theatre Name: {theatre.TheatreName}  |  Location: {theatre.TheatreLocation}");
                }

                //Ask user to select TheaterID
                System.Console.WriteLine("Select Theatre ID: ");

                //Get input from the user
                string theatreID = Console.ReadLine().ToUpper();
                bool theatreflag = false;

                //Traverse TheatreList
                foreach (TheatreDetails theatre in theatreList)
                {
                    //Find the theatreID in theatreList
                    if (theatre.TheatreID == theatreID)
                    {
                        theatreflag = true;
                        //Traverse Screening List
                        foreach (ScreeningDetails screening in screeningList)
                        {
                            //Find the entered theatreID in movieList
                            if (screening.TheatreID == theatreID)
                            {
                                //Traverse movieList
                                foreach (MovieDetails movie in movieList)
                                {
                                    if (movie.MovieID == screening.MovieID)
                                    {
                                        //show the movies screening in selected theatre
                                        System.Console.WriteLine($"Movie ID: {screening.MovieID}  |  Movie Name: {movie.MovieName}  \t|  Language: {movie.Language}  \t|  Ticket Price: {screening.TicketPrice}  |  Available seats: {screening.NoOfSeatsAvailable}");
                                    }
                                }
                            }
                        }
                        //Ask user to select movieID
                        System.Console.WriteLine("Select movie ID to book ticket:");
                        bool movieflag = false;

                        //Get input from the user
                        string movieID = Console.ReadLine().ToUpper();

                        //Traverse screening list
                        foreach (ScreeningDetails screening in screeningList)
                        {
                            //Find movie ID in screening 
                            if (screening.MovieID == movieID && screening.TheatreID == theatreID)
                            {
                                movieflag = true;
                                //Ask user to enter the seat count
                                System.Console.WriteLine("Enter Seat count to book:");

                                //Get input from the user
                                int seatCount = int.Parse(Console.ReadLine());

                                //Check seat availability
                                if (screening.NoOfSeatsAvailable >= seatCount)
                                {
                                    //Calculate Total Amount
                                    double TotalPrice = (screening.TicketPrice * seatCount);

                                    //Add Gst amount with Total price
                                    double FinalPrice = TotalPrice + (TotalPrice * 0.18);

                                    //Check login user's wallet balance
                                    if (loginUser.WalletBalance >= FinalPrice)
                                    {
                                        //Create and add object in bookingList
                                        bookingList.Add(new BookingDetails(loginUser.UserID, movieID, theatreID, seatCount, FinalPrice, BookingStatus.Booked));

                                        //Deduct total amount in user's wallet
                                        loginUser.DeductBalance(FinalPrice);

                                        //Deduct the seat count
                                        screening.NoOfSeatsAvailable -= seatCount;

                                        //Show successful message
                                        System.Console.WriteLine($"Ticket Booked Successfully, Ticket price {FinalPrice} deducted from your wallet for {seatCount} Tickets");
                                    }

                                    //If user didn't have enough balance in wallet
                                    else
                                    {
                                        System.Console.WriteLine("Insuffient wallet balance, please recharge your wallet");
                                    }
                                }

                                //If entered seat count is not available
                                else
                                {
                                    System.Console.WriteLine($"Required Count not available, current availability is {screening.NoOfSeatsAvailable}");
                                }
                            }
                        }

                        //If movieID was not found in movieList
                        if (!movieflag)
                        {
                            System.Console.WriteLine("Invalid Movie ID");
                        }
                    }
                }

                //If theatre Id was not found in theatreList
                if (!theatreflag)
                {
                    System.Console.WriteLine("Invalid Theatre ID");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void TicketCancellation()
        {
            try
            {
                System.Console.WriteLine("*************Ticket Cancellation Menu*************");
                bool ticketflag = false;

                //Travaerse bookingList
                foreach (BookingDetails booking in bookingList)
                {
                    //Find login user's userID in bookingList
                    if (loginUser.UserID == booking.UserID && booking.Status == BookingStatus.Booked)
                    {
                        ticketflag = true;
                        //Show details
                        System.Console.WriteLine($"Booking ID: {booking.BookingID} | Movie ID: {booking.MovieID} | Theatre ID: {booking.TheatreID} | Seat Count: {booking.SeatCount} | Total Amount: {booking.TotalAmount} | Status:  {booking.Status}");
                    }
                }
                if (ticketflag)
                {
                    //Ask user to select booking ID
                    System.Console.WriteLine("Select BookingID to cancel:");

                    //Get input from the user
                    string bookingID = Console.ReadLine().ToUpper();

                    //Traverse BookingList
                    foreach (BookingDetails booking in bookingList)
                    {
                        //Check for the booking ID in booking list
                        if (booking.BookingID == bookingID && booking.Status == BookingStatus.Booked && loginUser.UserID == booking.UserID)
                        {
                            //Traverse Screening List
                            foreach (ScreeningDetails screening in screeningList)
                            {
                                //Find the MovieID in screeningList
                                if (screening.MovieID == booking.MovieID)
                                {
                                    //Get the seat count and increase count in Total seats
                                    screening.NoOfSeatsAvailable += booking.SeatCount;

                                    //Reduce 20 in Total price and refund to user's wallet
                                    loginUser.RechargeWallet(booking.TotalAmount - 20);

                                    //Change booking status to cancelled   
                                    booking.Status = BookingStatus.Cancelled;

                                    //Show Successfull message
                                    System.Console.WriteLine("Booking cancelled successfully"+booking.BookingID);
                                }
                            }
                        }
                    }
                }

                //If userID was not found in booking history
                else
                {
                    System.Console.WriteLine("You didn't book any movie recently");
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
                bool flag = false;
                System.Console.WriteLine("*************Booking History*************");

                //Traverse Booking List
                foreach (BookingDetails booking in bookingList)
                {
                    //Find login user's userID in bookingList
                    if (loginUser.UserID == booking.UserID)
                    {
                        flag = true;
                        //Show details
                        System.Console.WriteLine($"Booking ID: {booking.BookingID} | Movie ID: {booking.MovieID} | Theatre ID: {booking.TheatreID} | Seat Count: {booking.SeatCount} | Total Amount: {booking.TotalAmount} | Status:  {booking.Status}");
                    }
                }
                if (!flag)
                {
                    System.Console.WriteLine("Booking History is Empty !");
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
                //Ask user to enter recharge amount
                System.Console.WriteLine("Enter the amount to be recharge:");

                //get amount from the user
                double amount = double.Parse(Console.ReadLine());

                //Check the amount is valid
                if (amount > 0)
                {
                    //Add amount to user's wallet
                    loginUser.RechargeWallet(amount);

                    //Show the updated balance
                    System.Console.WriteLine("Recharge Successful\nUpdated Balance: " + loginUser.WalletBalance);
                }

                //False --> Show Warning message
                else
                {
                    System.Console.WriteLine("Please enter valid amount to recharge");
                }

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void ShowBalance()
        {
            try
            {
                //Show the login user's Wallet Balance
                System.Console.WriteLine("Balance: " + loginUser.WalletBalance);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void DefaultDetails()
        {
            //Create and add objects to userList
            userList.Add(new UserDetails("Ravichandran", 30, 8599488003, GenderStatus.Male, 1000));
            userList.Add(new UserDetails("Baskaran", 30, 9857747327, GenderStatus.Male, 2000));

            //Create and add objects to bookingList
            bookingList.Add(new BookingDetails("UID1001", "MID501", "TID301", 1, 236, BookingStatus.Booked));
            bookingList.Add(new BookingDetails("UID1001", "MID504", "TID302", 1, 472, BookingStatus.Booked));
            bookingList.Add(new BookingDetails("UID1002", "MID505", "TID302", 1, 354, BookingStatus.Booked));

            //Create and add objects to theatreList
            theatreList.Add(new TheatreDetails("Inox", "Anna Nagar"));
            theatreList.Add(new TheatreDetails("Ega Theatre", "Chetpet"));
            theatreList.Add(new TheatreDetails("Kamala", "Vadapalani"));

            //Create and add objects to movieList
            movieList.Add(new MovieDetails("Bahubali 2", "Telugu"));
            movieList.Add(new MovieDetails("Ponniyin Selvan ", "Tamil"));
            movieList.Add(new MovieDetails("Cobra", "Tamil"));
            movieList.Add(new MovieDetails("Vikram", "Hindi (Dubbed)"));
            movieList.Add(new MovieDetails("Vikram", "Tamil"));
            movieList.Add(new MovieDetails("Beast", "English"));

            //Create and add objects to screeningList
            screeningList.Add(new ScreeningDetails("MID501", "TID301", 200, 5));
            screeningList.Add(new ScreeningDetails("MID502", "TID301", 300, 2));
            screeningList.Add(new ScreeningDetails("MID506", "TID301", 50, 1));
            screeningList.Add(new ScreeningDetails("MID501", "TID302", 400, 11));
            screeningList.Add(new ScreeningDetails("MID505", "TID302", 300, 20));
            screeningList.Add(new ScreeningDetails("MID504", "TID302", 500, 2));
            screeningList.Add(new ScreeningDetails("MID505", "TID303", 100, 11));
            screeningList.Add(new ScreeningDetails("MID502", "TID303", 200, 20));
            screeningList.Add(new ScreeningDetails("MID504", "TID303", 350, 2));
        }
    }
}