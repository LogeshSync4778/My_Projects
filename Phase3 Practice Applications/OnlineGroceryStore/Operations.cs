using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace OnlineGroceryStore
{
    public class Operations
    {
        //Create Customer List
        public static CustomList<CustomerDetails> customerList = new CustomList<CustomerDetails>();
        //Create Product List
        public static CustomList<ProductDetails> productList = new CustomList<ProductDetails>();
        //Create Booking List
        public static CustomList<BookingDetails> bookingList = new CustomList<BookingDetails>();
        //Create Order List
        public static CustomList<OrderDetails> orderList = new CustomList<OrderDetails>();
        //Create Login Customer object
        public static CustomerDetails loginCustomer;
        public static void MainMenu()
        {
            try
            {
                bool flag = true;
                do
                {
                    //Display the available option in Main menu
                    System.Console.WriteLine("\n    *****Online Grocery Store*****");
                    System.Console.WriteLine("***************Main Menu****************");
                    System.Console.WriteLine("Select Choice: \n\t1.Customer Registration\n\t2.Customer Login\n\t3.Exit");
                    //Ask input from the user to select choice
                    int choice = int.Parse(Console.ReadLine());
                    //Check user choice and call method matched with user's choice
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
                //Get user details one by one
                System.Console.WriteLine("**************Registration Menu*****************");
                System.Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                System.Console.WriteLine("Father Name: ");
                string fatherName = Console.ReadLine();
                System.Console.WriteLine("Gender: (Male,Female,Transgender)");
                GenderStatus gender = Enum.Parse<GenderStatus>(Console.ReadLine(), true);
                System.Console.WriteLine("Mobile No:");
                long mobile = long.Parse(Console.ReadLine());
                System.Console.WriteLine("Date Of Birth: (dd/MM/yyyy)");
                DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                System.Console.WriteLine("Email ID: ");
                string mailID = Console.ReadLine();

                //Create object in customerdetails with entered user details
                CustomerDetails customer = new CustomerDetails(0, name, fatherName, gender, mobile, dob, mailID);
                //Add object to the list
                customerList.Add(customer);
                //Show the successful message and show customer ID
                System.Console.WriteLine("Registration Successfull, Your Customer ID is " + customer.CustomerID);
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
                //Ask user to enter the customer ID
                System.Console.WriteLine("**************Login Menu*****************");
                System.Console.WriteLine("Enter Customer ID: ");
                string customerID = Console.ReadLine().ToUpper();
                //Traverse customer list
                foreach (CustomerDetails customer in customerList)
                {
                    //Check the entered input in customer list
                    if (customer.CustomerID == customerID)
                    {
                        //True --> Call Submenu
                        loginCustomer = customer;
                        flag = true;
                        System.Console.WriteLine("Login Successfull \n");
                        SubMenu();
                        break;
                    }
                }
                //If entered input didn't found a match in customer list
                if (!flag)
                {
                    System.Console.WriteLine("Invalid Customer ID");
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
                    //Show the available options of submenu
                    System.Console.WriteLine("**************SubMenu*****************");
                    System.Console.WriteLine("Select Choice: \n\t1.Show Customer Details\n\t2.Show Product Details\n\t3.Wallet Recharge\n\t4.Take Order");
                    System.Console.WriteLine("\t5.Modify Order Quantity\n\t6.Cancel Order\n\t7.Order History\n\t8.Show Balance\n\t9.Exit");
                    //Ask user to select any option
                    int choice = int.Parse(Console.ReadLine());
                    //Check the option and call method which was user selected
                    switch (choice)
                    {
                        case 1:
                            {
                                ShowCustomerDetails();
                                break;
                            }
                        case 2:
                            {
                                ShowProductDetails();
                                break;
                            }
                        case 3:
                            {
                                WalletRecharge();
                                break;
                            }
                        case 4:
                            {
                                TakeOrder();
                                break;
                            }
                        case 5:
                            {
                                ModifyOrderQuantity();
                                break;
                            }
                        case 6:
                            {
                                CancelOrder();
                                break;
                            }
                        case 7:
                            {
                                OrderHistory();
                                break;
                            }
                        case 8:
                            {
                                ShowBalance();
                                break;
                            }
                        case 9:
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
        public static void ShowCustomerDetails()
        {
            try
            {
                System.Console.WriteLine("**************Customer Details*****************");
                //Show the details of login Customer
                System.Console.WriteLine($"Name: {loginCustomer.Name}\nFather Name: {loginCustomer.FatherName}\nGender: {loginCustomer.Gender}\nMobile no: {loginCustomer.Mobile}\nDOB: {loginCustomer.DOB:dd/MM/yyyy}\nMail ID: {loginCustomer.MailID}\nWallet Balance: {loginCustomer.WalletBalance}");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void ShowProductDetails()
        {
            try
            {
                System.Console.WriteLine("**************Product Details*****************");
                //Traverse product list
                foreach (ProductDetails product in productList)
                {
                    //Show the product details available in product list
                    System.Console.WriteLine($"Product ID: {product.ProductID}  |  Product Name: {product.ProductName}  |  Quanity Available: {product.QuantityAvailable}  |  Price per Quantity: {product.PricePerQuantity}");
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
                System.Console.WriteLine("**************Wallet Recharge*****************");
                //Ask user to enter the recharge amount
                System.Console.WriteLine("Enter the amount to be Recharge: ");
                double amount = double.Parse(Console.ReadLine());
                //Add entered amount in login customer's wallet
                loginCustomer.WalletRecharge(amount);
                //Show the updated balance to the user
                System.Console.WriteLine($"Your updated Balance: {loginCustomer.WalletBalance}");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void TakeOrder()
        {
            try
            {
                //Create and declare default total amount 0
                double TotalAmount = 0;
                string option = "no", productID = string.Empty;
                int quantity = 0;
                bool productflag = false;
                System.Console.WriteLine("**************Take Order Menu*****************");
                //Ask user to start the purchase
                System.Console.WriteLine("Do you want to purchase  : (Yes/No)");
                string choice = Console.ReadLine().ToUpper();
                //True
                if (choice == "YES")
                {
                    //Create booking details object with Initiated status
                    BookingDetails booking = new BookingDetails(loginCustomer.CustomerID, 0, DateTime.Now, BookingStatus.Initiated);
                    //Create the temporderList to store the purchased products before final confirmation
                    CustomList<OrderDetails> temporderList = new CustomList<OrderDetails>();
                    do
                    {
                        //Traverse productList
                        foreach (ProductDetails product in productList)
                        {
                            //Show the product list that is having stock
                            if (product.QuantityAvailable > 0)
                            {
                                System.Console.WriteLine($"Product ID: {product.ProductID} | Product Name: {product.ProductName} | Price per Quantity: {product.PricePerQuantity} | Available Quanitity: {product.QuantityAvailable}");
                            }
                        }
                        //Ask user to select product using product ID
                        System.Console.WriteLine("Enter Product ID to Select: ");
                        productID = Console.ReadLine().ToUpper();
                        //Traverse product List
                        foreach (ProductDetails product in productList)
                        {
                            //Find the selected product in productList
                            if (product.ProductID == productID)
                            {
                                productflag = true;
                                //Ask user to select quantity of the product
                                System.Console.WriteLine("Enter Product Quantity: ");
                                quantity = int.Parse(Console.ReadLine());
                                //Check the entered quantity is available in total stock
                                if (product.QuantityAvailable >= quantity)
                                {
                                    //Find the total price for entered quantity
                                    double TotalPrice = product.PricePerQuantity * quantity;
                                    //Update the total price in TotalAmount
                                    TotalAmount += TotalPrice;
                                    //Create object for orderDetails
                                    OrderDetails order1 = new OrderDetails(booking.BookingID, product.ProductID, quantity, TotalPrice);
                                    //Add the tempOrderList in a list
                                    temporderList.Add(order1);
                                    //Decrease the selected quantity in total stock
                                    product.QuantityAvailable -= quantity;
                                    //Show the successfull message 
                                    System.Console.WriteLine("Product Successfully added to cart");
                                    //Ask user to enter that he had any wish to book any other product
                                    System.Console.WriteLine("Do you want to book another product: (Yes,No)");
                                    option = Console.ReadLine().ToLower();
                                }
                                else
                                {
                                    System.Console.WriteLine("Product out of stock for entered quantity");
                                }
                            }
                        }
                        //Repeat the process while user select no
                    } while (option != "no");
                    //Ask user to confirm the order
                    System.Console.WriteLine("Do you want to confirm the order: (Yes,No)");
                    string confirm = Console.ReadLine().ToLower();

                    //If user selected yes
                    if (confirm == "yes")
                    {
                        //Check user is having Total price of the purchase in his wallet
                        if (loginCustomer.WalletBalance >= TotalAmount)
                        {
                            //Show the successful message with bill amount
                            System.Console.WriteLine($"Order Placed Successfully, Bill amount ${TotalAmount} Deducted from your wallet");
                            //Deduct the total amount of the purchase in user's wallet
                            loginCustomer.DeductBalance(TotalAmount);
                            //Change the booking status to booked in booking object
                            booking.Status = BookingStatus.Booked;
                            //Change the total price in booking object
                            booking.TotalPrice = TotalAmount;
                            //Add the booking object to the list
                            bookingList.Add(booking);
                            //Traverse temporder List
                            foreach (OrderDetails order in temporderList)
                            {
                                //Add object to the orderList
                                orderList.Add(order);
                            }
                        }
                        //If user didn't have enough balance in his wallet 
                        else
                        {
                            //Show the notification message to recharge his wallet to proceed with bill amount
                            System.Console.WriteLine("Insufficient account balance recharge with " + TotalAmount);
                            //Traverse temporder List
                            foreach (OrderDetails order in temporderList)
                            {
                                //Traverse productList
                                foreach (ProductDetails product in productList)
                                {
                                    //Find the selected product of user
                                    if (order.ProductID == product.ProductID)
                                    {
                                        //Increase the quantity in total stock
                                        product.QuantityAvailable += order.PurchaseCOunt;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        //Traverse tempOrderList
                        foreach (OrderDetails order in temporderList)
                        {
                            //Traverse product List
                            foreach (ProductDetails product in productList)
                            {
                                //Find the selected product of user
                                if (order.ProductID == product.ProductID)
                                {
                                    //Increase the quantity in total stock
                                    product.QuantityAvailable += order.PurchaseCOunt;
                                }
                            }
                        }
                        //Show the notification message
                        System.Console.WriteLine("Cart removed successfully");
                    }

                    //If entered product ID didn't match with any product in productList
                    if (!productflag)
                    {
                        System.Console.WriteLine("Invalid ProductID");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void ModifyOrderQuantity()
        {
            try
            {
                System.Console.WriteLine("**************Order Quantity Modifying Menu*****************");
                //Traverse booking list
                bool bookingflag = false;
                foreach (BookingDetails booking in bookingList)
                {
                    //Find the booking having current user's customer id and booking having booked status
                    if (booking.CustomerID == loginCustomer.CustomerID && booking.Status == BookingStatus.Booked)
                    {
                        bookingflag = true;
                        System.Console.WriteLine($"Booking ID: {booking.BookingID} | Total Price: {booking.TotalPrice} | Date of Booking: {booking.DateOfBooking:dd/MM/yyyy}");
                    }
                }
                if (bookingflag)
                {
                    //Ask user to select Booking ID
                    System.Console.WriteLine("Select Booking ID: ");
                    //Get input from the user
                    string bookingID = Console.ReadLine().ToUpper();
                    //Traverse bookingList
                    foreach (BookingDetails booking in bookingList)
                    {
                        //Check and find the login user's booking ID and having booked status
                        if (booking.BookingID == bookingID && booking.CustomerID == loginCustomer.CustomerID && booking.Status == BookingStatus.Booked)
                        {
                            bool flag = false;
                            // Traverse order list 
                            foreach (OrderDetails order in orderList)
                            {
                                //Find the user's booking id in orderlist
                                if (order.BookingID == bookingID)
                                {
                                    flag = true;
                                    //Show the order details
                                    System.Console.WriteLine($"Order ID: {order.OrderID} | Booking ID: {order.BookingID} | Product ID: {order.ProductID} | Purchased Count: {order.PurchaseCOunt} | Price of Order: {order.PriceOfOrder}");
                                }
                            }
                            if (flag)
                            {
                                //Ask user to enter orderID
                                System.Console.WriteLine("Select Order ID to Modify: ");
                                //Get input from the user
                                string orderID = Console.ReadLine().ToUpper();
                                bool orderflag = false;
                                //Traverse orderList
                                foreach (OrderDetails order in orderList)
                                {
                                    //Find the entered order ID in orderList
                                    if (order.OrderID == orderID)
                                    {
                                        orderflag = true;
                                        //Ask user to enter new quantity to purchase
                                        System.Console.WriteLine("Enter the new Quantity of the product:");
                                        //Get input from the user
                                        int quantity = int.Parse(Console.ReadLine());
                                        //Compare the new quantity with old quantity
                                        if (quantity > order.PurchaseCOunt)
                                        {
                                            //Find the purchase quantity
                                            int purchaseQuantity = quantity - order.PurchaseCOunt;
                                            //Traverse productList
                                            foreach (ProductDetails product in productList)
                                            {
                                                //Find the productID in product list
                                                if (product.ProductID == order.ProductID)
                                                {
                                                    //Check the product quantity is enough to make new purchase
                                                    if (product.QuantityAvailable >= purchaseQuantity)
                                                    {
                                                        //Find the total amount for modified quantity
                                                        double TotalAmount = purchaseQuantity * product.PricePerQuantity;
                                                        //Check for the new purchase amount in user's wallet
                                                        if (loginCustomer.WalletBalance >= TotalAmount)
                                                        {
                                                            //Decrease the new purchase count in total stock of the product
                                                            product.QuantityAvailable -= purchaseQuantity;
                                                            //Deduct the new purchase amount in user's wallet
                                                            loginCustomer.DeductBalance(TotalAmount);
                                                            //Change the modified quantity in order list
                                                            order.PurchaseCOunt += purchaseQuantity;
                                                            //Update the new totalamount in orderList
                                                            order.PriceOfOrder += TotalAmount;
                                                            //Adding new price of order in booking list
                                                            booking.TotalPrice += TotalAmount;
                                                            //Show the successfull message
                                                            System.Console.WriteLine("Order modified successfully");
                                                        }
                                                        //If user didn't have enough amount to modify purchase
                                                        else
                                                        {
                                                            System.Console.WriteLine("Please recharge your wallet and proceed");
                                                        }
                                                    }
                                                    //If entered orderID didn't match
                                                    else
                                                    {
                                                        System.Console.WriteLine("Invalid Order ID");
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            //Find the return quantity
                                            int returnQuantity = order.PurchaseCOunt - quantity;
                                            //Traverse productList
                                            foreach (ProductDetails product in productList)
                                            {
                                                //Find the productID in orderList
                                                if (product.ProductID == order.ProductID)
                                                {
                                                    //Find the Total amount for modified quantity
                                                    double TotalAmount = returnQuantity * product.PricePerQuantity;
                                                    //Increase the new purchase count in total stock of the product
                                                    product.QuantityAvailable -= returnQuantity;
                                                    //Recharge the new purchase amount in user's wallet
                                                    loginCustomer.WalletRecharge(TotalAmount);
                                                    //Change the modified quantity in order list
                                                    order.PurchaseCOunt -= returnQuantity;
                                                    //Update the new totalamount in orderList
                                                    order.PriceOfOrder -= TotalAmount;
                                                    //Adding new price of order in booking list
                                                    booking.TotalPrice -= TotalAmount;
                                                    //Show the successfull message
                                                    System.Console.WriteLine("Order modified successfully");
                                                }
                                            }
                                        }
                                    }
                                }
                                if (!orderflag)
                                {
                                    System.Console.WriteLine("Invalid Order ID");
                                }
                            }
                            else
                            {
                                System.Console.WriteLine("You didn't order any order");
                            }
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("You didn't book any order");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void CancelOrder()
        {
            try
            {
                System.Console.WriteLine("**************Order Cancellation Menu*****************");
                //Traverse booking list
                foreach (BookingDetails booking in bookingList)
                {
                    //Show the login customers bookings
                    if (booking.CustomerID == loginCustomer.CustomerID && booking.Status == BookingStatus.Booked)
                    {
                        System.Console.WriteLine($"Booking ID: {booking.BookingID} | Total Price: {booking.TotalPrice} | Date of Booking: {booking.DateOfBooking:dd/MM/yyyy} | Total Price: {booking.TotalPrice}");
                    }
                }
                //Ask user to select booking ID to cancel
                System.Console.WriteLine("Select BookingID to cancel: ");
                string bookingID = Console.ReadLine().ToUpper();
                bool cancelflag = false;
                //Traverse booking list
                foreach (BookingDetails booking in bookingList)
                {
                    //Find the entered booking id in booking list
                    if (booking.BookingID == bookingID && loginCustomer.CustomerID == booking.CustomerID)
                    {
                        cancelflag = true;
                        //Change the status to cancelled
                        booking.Status = BookingStatus.Cancelled;
                        //Refund the total price to user's wallet
                        loginCustomer.WalletBalance += booking.TotalPrice;
                        //Traverse orderList
                        foreach (OrderDetails order in orderList)
                        {
                            //Find bookingID in orderList
                            if (order.BookingID == booking.BookingID)
                            {
                                //Traverse productList
                                foreach (ProductDetails product in productList)
                                {
                                    //Find the product ID in productList
                                    if (product.ProductID == order.ProductID)
                                    {
                                        //Add the purchase quantity in total stock
                                        product.QuantityAvailable += order.PurchaseCOunt;
                                    }
                                }
                            }
                        }
                    }
                }
                if (!cancelflag)
                {
                    System.Console.WriteLine("Please enter your Booking ID");
                }
                else
                {
                    System.Console.WriteLine("Booking Cancelled Successfully");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void OrderHistory()
        {
            try
            {
                bool orderflag = false;
                System.Console.WriteLine("**************Order History*****************");
                //Traverse Bookinglist
                foreach (BookingDetails booking in bookingList)
                {
                    //Find login users bookings in bookinglist
                    if (booking.CustomerID == loginCustomer.CustomerID)
                    {
                        //Traverse orderList
                        foreach (OrderDetails order in orderList)
                        {
                            //Find booking ID in orderList
                            if (order.BookingID == booking.BookingID)
                            {
                                orderflag = true;
                                //Display the order details
                                System.Console.WriteLine($"Order ID: {order.OrderID} | Booking ID: {order.BookingID} | Product ID: {order.ProductID} | Purchase Count: {order.PurchaseCOunt} | Price of Order: {order.PriceOfOrder}");
                            }
                        }
                    }
                }
                if (!orderflag)
                {
                    System.Console.WriteLine("Your didn't order any product !");
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
                //Show the Wallet balance of login customer
                System.Console.WriteLine($"Balance: {loginCustomer.WalletBalance}");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void DefaultDetails()
        {

            //Create and Add abjects to customerList
            customerList.Add(new CustomerDetails(10000, "Ravi", "Ettapparajan", GenderStatus.Male, 974774646, DateTime.ParseExact("11/11/1999", "dd/MM/yyyy", null), "ravi@gmail.com"));
            customerList.Add(new CustomerDetails(15000, "Baskaran", "Sethurajan", GenderStatus.Male, 847575775, DateTime.ParseExact("11/11/1999", "dd/MM/yyyy", null), "baskaran@gmail.com"));

            //Create and Add abjects to productList
            productList.Add(new ProductDetails("Sugar", 20, 40));
            productList.Add(new ProductDetails("Rice", 100, 50));
            productList.Add(new ProductDetails("Milk", 10, 40));
            productList.Add(new ProductDetails("Coffee", 10, 10));
            productList.Add(new ProductDetails("Tea", 10, 10));
            productList.Add(new ProductDetails("Masala Powder", 10, 20));
            productList.Add(new ProductDetails("Salt", 10, 10));
            productList.Add(new ProductDetails("Turmeric Powder", 10, 25));
            productList.Add(new ProductDetails("Chilli Powder", 10, 20));
            productList.Add(new ProductDetails("Groundnut Oil", 10, 140));

            //Create and Add abjects to bookingList
            bookingList.Add(new BookingDetails("CID1001", 220, DateTime.ParseExact("26/07/2022", "dd/MM/yyyy", null), BookingStatus.Booked));
            bookingList.Add(new BookingDetails("CID1002", 400, DateTime.ParseExact("26/07/2022", "dd/MM/yyyy", null), BookingStatus.Booked));
            bookingList.Add(new BookingDetails("CID1001", 280, DateTime.ParseExact("26/07/2022", "dd/MM/yyyy", null), BookingStatus.Cancelled));
            bookingList.Add(new BookingDetails("CID1002", 0, DateTime.ParseExact("26/07/2022", "dd/MM/yyyy", null), BookingStatus.Initiated));

            //Create and Add abjects to orderList
            orderList.Add(new OrderDetails("BID3001", "PID2001", 2, 80));
            orderList.Add(new OrderDetails("BID3001", "PID2002", 2, 100));
            orderList.Add(new OrderDetails("BID3001", "PID2003", 1, 40));
            orderList.Add(new OrderDetails("BID3002", "PID2001", 1, 40));
            orderList.Add(new OrderDetails("BID3002", "PID2002", 4, 200));
            orderList.Add(new OrderDetails("BID3002", "PID2010", 1, 140));
            orderList.Add(new OrderDetails("BID3002", "PID2009", 1, 20));
            orderList.Add(new OrderDetails("BID3003", "PID2002", 2, 100));
            orderList.Add(new OrderDetails("BID3003", "PID2008", 4, 100));
            orderList.Add(new OrderDetails("BID3003", "PID2001", 2, 80));
        }
    }
}