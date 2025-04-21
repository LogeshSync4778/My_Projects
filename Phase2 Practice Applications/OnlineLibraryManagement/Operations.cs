using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineLibraryManagement
{
    public class Operations
    {
        public static List<UserDetails> userList = new List<UserDetails>();
        public static List<BookDetails> bookList = new List<BookDetails>();
        public static List<BorrowDetails> borrowList = new List<BorrowDetails>();
        public static UserDetails loginUser;

        public static void MainMenu()
        {
            try
            {
                bool flag = true;
                do
                {
                    //Step1 --> Show the List of Options
                    System.Console.WriteLine("***********Main Menu************");
                    System.Console.WriteLine("Select Choice:\n\t1.User Registration\n\t2.User Login\n\t3.Exit");
                    //Step2 --> Ask input from the user to select choice
                    int choice = int.Parse(Console.ReadLine());
                    //Step3 --> Call the Method of the selected choice
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
                //Step1 --> Ask for the details from the user
                System.Console.WriteLine("***********Registration*************");
                System.Console.WriteLine("Enter Name: ");
                string name = Console.ReadLine();
                System.Console.WriteLine("Select Gender: (Male,Female,Transgender)");
                GenderDetails gender = Enum.Parse<GenderDetails>(Console.ReadLine(), true);
                System.Console.WriteLine("Select Department: (EEE,CSE,ECE)");
                DepartmentStatus department = Enum.Parse<DepartmentStatus>(Console.ReadLine(), true);
                System.Console.WriteLine("Enter Mobile number");
                long mobile = long.Parse(Console.ReadLine());
                System.Console.WriteLine("Enter Mail ID");
                string mailID = Console.ReadLine();

                //Step2 --> Create Object in Userdetails with the details of the user
                UserDetails user = new UserDetails(name, gender, department, mobile, mailID, 0);
                //Step3 --> Add object to the UserList
                userList.Add(user);
                //Step4 --> Show the successfull message and the generated user ID
                System.Console.WriteLine("Registration Successfull, your userID is " + user.UserID);
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
                bool flag = false;
                //Step1 --> Ask for the User ID from the user
                System.Console.WriteLine("Enter User ID: ");
                string userID = Console.ReadLine().ToUpper();
                //Step2 --> Traverse the userList
                foreach (UserDetails user in userList)
                {
                    //Step3 -->Check the entered userID in userList
                    //True
                    if (user.UserID == userID)
                    {
                        flag = true;
                        //Step4 --> set the details of user to loginUser
                        loginUser = user;
                        //Step5 --> Show successful message
                        System.Console.WriteLine("Login Successfull");
                        //Step6 --> Call Submenu method
                        SubMenu();
                        break;
                    }
                }
                //False
                if (!flag)
                {
                    System.Console.WriteLine("Invalid UserID");
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
                    //Step1 --> Show the available options list
                    System.Console.WriteLine("************Login Menu***********");
                    System.Console.WriteLine("Select Choice:\n\t1.Borrow Book\n\t2.Show Borrowed History\n\t3.Return Book\n\t4.Wallet Recharge\n\t5.Exit");
                    //Step2 --> Ask input from the user to select option
                    int choice = int.Parse(Console.ReadLine());
                    //Step 3 --> Call method for the selected option
                    switch (choice)
                    {
                        case 1:
                            {
                                BorrowBook();
                                break;
                            }
                        case 2:
                            {
                                ShowBorrowHistory();
                                break;
                            }
                        case 3:
                            {
                                ReturnBook();
                                break;
                            }
                        case 4:
                            {
                                Recharge();
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
        public static void BorrowBook()
        {
            try
            {
                //Step1 --> Traverse bookList
                foreach (BookDetails book in bookList)
                {
                    //Step2 --> Show the available book details
                    System.Console.WriteLine($"\nBook ID: {book.BookID} | Book Name: {book.BookName} | Author Name: {book.AuthorName} | Book Count: {book.BookCount}");
                }
                //Step3 --> Ask user to enter book ID of the book 
                System.Console.WriteLine("Enter Book ID to borrow: ");
                string bookID = Console.ReadLine().ToUpper();
                int count = 0;
                bool bookflag = false, countflag = false;
                DateTime borrowdate = DateTime.MaxValue;
                //Step4 --> Traverse bookList
                foreach (BookDetails book in bookList)
                {
                    //Step5 --> Check for the entered bookID in bookList
                    //True
                    if (book.BookID == bookID)
                    {
                        bookflag = true;
                        //Step6 --> Ask user for the count of the book
                        System.Console.WriteLine("Enter the count of the book:");
                        int bookcount = int.Parse(Console.ReadLine());
                        //Step7 --> Check the book count is available or not in Total count of the bookID
                        //True
                        if (book.BookCount >= bookcount)
                        {
                            //Step8 --> Traverse borrowList
                            foreach (BorrowDetails borrow in borrowList)
                            {
                                //Step9 --> Check the borrowList for user is already borrowed any book
                                if (borrow.UserID == loginUser.UserID)
                                {
                                    //Step 10 --> True -->Increment the count of the borrowed books in "count"
                                    if (borrow.Status == BookStatus.Borrowed)
                                    {
                                        count += borrow.BookCount;
                                    }
                                }
                            }
                            //Step 11 --> Check the borrowed count is lesser the 3
                            //True
                            if (count + bookcount <= 3)
                            {
                                //Step 12 --> Borrow book to the user 
                                BorrowDetails borrow1 = new BorrowDetails(book.BookID, loginUser.UserID, DateTime.Now, bookcount, BookStatus.Borrowed, 0);
                                borrowList.Add(borrow1);
                                //Step 13 --> Show the successful message and borrow ID generated
                                System.Console.WriteLine("Book Borrowed Successfully, Your Borrow ID is " + borrow1.BorrowID);
                                //Step 14 --> Decrease the book count in Total book count
                                book.BookCount -= bookcount;
                            }
                            //False
                            else
                            {
                                //Show warning message to the user that he has already borrowed 3 books
                                System.Console.WriteLine($"You can have maximum of 3 borrowed books. Your already borrowed books count is {count} and requested count is {bookcount}, which exceeds 3");
                            }

                        }
                        //False --> If bookcount > 3
                        else
                        {
                            foreach (BorrowDetails borrow in borrowList)
                            {
                                //Check for the book is borrowed by anyone in borrowList
                                //True
                                if (bookID == borrow.BookID && borrow.Status == BookStatus.Borrowed)
                                {
                                    if (borrowdate > borrow.BorrowDate)
                                    {
                                        borrowdate = borrow.BorrowDate;
                                    }
                                    countflag = true;
                                    //Show the message to inform Books are not availble and display the available date of the selected book

                                }
                            }
                            System.Console.WriteLine("Books are not available for the selected count");
                            System.Console.WriteLine($"The Book will be available on {borrowdate.AddDays(15):dd/MM/yyyy}");
                            //False --> If the selected book hasn't more than 2 books in total stock
                            if (!countflag)
                            {
                                //Show the message to inform Books are not availble
                                System.Console.WriteLine("Books are not available for the selected count");
                            }
                        }
                    }
                }
                //False --> If book ID didn't match
                if (!bookflag)
                {
                    //Show warning message
                    System.Console.WriteLine($"Invalid Book ID, Please enter valid ID");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void ShowBorrowHistory()
        {
            try
            {
                bool flag = false;
                //Step1 --> Traverse borrowList
                foreach (BorrowDetails borrow in borrowList)
                {
                    //Step2 --> Check for the loginuser ID in borrowList
                    if (borrow.UserID == loginUser.UserID)
                    {
                        flag = true;
                        //Step3 --> Show login user's borrow details
                        System.Console.WriteLine($"\nBorrow ID: {borrow.BorrowID}\nBook ID: {borrow.BookID}\nBorrow Date: {borrow.BorrowDate}\nBorrow Book Count: {borrow.BookCount}\nStatus: {borrow.Status}");
                    }
                }
                //False 
                if (!flag)
                {
                    System.Console.WriteLine("Borrow History is Empty");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void ReturnBook()
        {
            try
            {
                DateTime returnDate = DateTime.Now;
                //Step1 --> Traverse borrowList
                foreach (BorrowDetails borrow in borrowList)
                {
                    //Step2 --> Check the borrowList for the login user and the book status is borrowed
                    if (loginUser.UserID == borrow.UserID && borrow.Status == BookStatus.Borrowed)
                    {
                        //Step3 --> Find returnDate by adding 15 days with the Borrowdate
                        returnDate = borrow.BorrowDate.AddDays(15);
                        //Step4 --> Show Details of the borrowed books
                        System.Console.WriteLine($"\nBorrow ID: {borrow.BorrowID}\nBook ID: {borrow.BookID}\nBook Count: {borrow.BookCount}\nBorrow Date: {borrow.BorrowDate:dd/MM/yyyy}\nReturn Date: {returnDate:dd/MM/yyyy}");
                    }
                }
                //Step5 --> Ask user to select borrow Id of book to be returned
                System.Console.WriteLine("Select Borrow ID to return book: ");
                string borrowID = Console.ReadLine().ToUpper();
                bool bookflag = false;
                //Step6 --> Traverse borrowList
                foreach (BorrowDetails borrow in borrowList)
                {
                    //Step7 --> Check for the entered borrowId in borrowList
                    if (borrow.BorrowID == borrowID)
                    {
                        bookflag = true;
                        returnDate = borrow.BorrowDate.AddDays(15);
                        //Step8 --> Check the returndate is already ended or not.
                        TimeSpan span = returnDate - DateTime.Now;
                        //True
                        if (span.TotalDays < 0)
                        {
                            //Step9 --> FInd the Fine Amount by finding the days extended from the returndate
                            double paidfineamount = (int)(-1 * span.TotalDays);
                            //Step 10 -> Check the user's walletBalance to deduct Fine Amount
                            //True
                            if (loginUser.WalletBalance >= paidfineamount)
                            {
                                //Step 11 --> Traverse BookList
                                foreach (BookDetails book in bookList)
                                {
                                    //Step 12 --> check the borrowId in borrowList
                                    if (borrow.BorrowID == borrowID)
                                    {
                                        //Step 13 --> deduct the fine amount in user's wallet
                                        loginUser.Deduct(paidfineamount);
                                        //Step 14 --> show the successfull message and deducted fine amount from the wallet
                                        System.Console.WriteLine($"Book returned successfully, Paid Fine Amount: {paidfineamount}");
                                        //Step 15 --> Change the status of the book to returned
                                        borrow.Status = BookStatus.Returned;
                                        //Step 16 --> Increase the Total Bookcount with returned book count
                                        book.BookCount += borrow.BookCount;
                                        break;
                                    }
                                }
                            }
                            //False --> If user's wallet balance didn't have FineAmount
                            else
                            {
                                System.Console.WriteLine("Insufficient Balance. Please recharge and proceed");
                            }
                        }
                        //False --> If user return the book within the Return date
                        else
                        {
                            foreach (BookDetails book in bookList)
                            {
                                if (borrow.BookID == book.BookID)
                                {
                                    System.Console.WriteLine("Book returned successfully");
                                    borrow.Status = BookStatus.Returned;
                                    book.BookCount += borrow.BookCount;
                                }
                            }
                        }
                    }
                }
                //False --> If entered borrowID didn't match
                if (!bookflag)
                {
                    System.Console.WriteLine("Invalid Borrow ID");
                }
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
                //Step1 --> Ask user to confirm the recharge 
                System.Console.WriteLine("Do you want to recharge your wallet: (Yes/No)");
                string confirm = Console.ReadLine().ToLower();
                //Step2 --> Check the input is valid
                if (confirm == "yes")
                {
                    //Step3 --> Ask Recharge amount
                    System.Console.WriteLine("Enter the Recharge Amount: ");
                    double amount = double.Parse(Console.ReadLine());
                    //Step4 --> Check the amount is valid
                    //True
                    if (amount > 0)
                    {
                        //Step5 --> Add amount with the user's wallet
                        loginUser.Recharge(amount);
                        //Step6 --> Show the updated walletbalance
                        System.Console.WriteLine($"Updated Balance: {loginUser.WalletBalance}");
                    }
                    //False
                    else
                    {
                        System.Console.WriteLine("Please enter valid amount");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void DefaultData()
        {
            //Step1 --> Create the Objects of user1 and user2 in UserDetails
            UserDetails user1 = new UserDetails("Ravichandran", GenderDetails.Male, DepartmentStatus.EEE, 9938388333, "ravi@gmail.com", 100);
            UserDetails user2 = new UserDetails("Priyadharshini", GenderDetails.Female, DepartmentStatus.CSE, 9944444455, "priya@gmail.com", 150);
            //Step2 --> Add Objects to the userList
            userList.Add(user1);
            userList.Add(user2);

            //Step1 --> Create the Objects of book1, book2, book3, book4 and book5 in BookDetails
            BookDetails book1 = new BookDetails("C#", "Author1", 3);
            BookDetails book2 = new BookDetails("HTML", "Author2", 5);
            BookDetails book3 = new BookDetails("CSS", "Author1", 3);
            BookDetails book4 = new BookDetails("JS", "Author1", 3);
            BookDetails book5 = new BookDetails("TS", "Author2", 2);
            //Step2 --> Add Objects to the bookList
            bookList.Add(book1);
            bookList.Add(book2);
            bookList.Add(book3);
            bookList.Add(book4);
            bookList.Add(book5);

            //Step1 --> Create the Objects of borrow1, borrow2, borrow3, borrow4 and borrow5 in BookDetails
            BorrowDetails borrow1 = new BorrowDetails("BID1001", "SF3001", DateTime.ParseExact("10/09/2023", "dd/MM/yyyy", null), 2, BookStatus.Borrowed, 0);
            BorrowDetails borrow2 = new BorrowDetails("BID1003", "SF3001", DateTime.ParseExact("12/09/2023", "dd/MM/yyyy", null), 1, BookStatus.Borrowed, 0);
            BorrowDetails borrow3 = new BorrowDetails("BID1004", "SF3001", DateTime.ParseExact("14/09/2023", "dd/MM/yyyy", null), 1, BookStatus.Returned, 16);
            BorrowDetails borrow4 = new BorrowDetails("BID1002", "SF3002", DateTime.ParseExact("11/09/2023", "dd/MM/yyyy", null), 2, BookStatus.Borrowed, 0);
            BorrowDetails borrow5 = new BorrowDetails("BID1005", "SF3002", DateTime.ParseExact("09/09/2023", "dd/MM/yyyy", null), 1, BookStatus.Returned, 20);
            //Step2 --> Add Objects to the borrowList
            borrowList.Add(borrow1);
            borrowList.Add(borrow2);
            borrowList.Add(borrow3);
            borrowList.Add(borrow4);
            borrowList.Add(borrow5);
        }
    }
}