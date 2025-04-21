using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ECommerce
{
    public class Operations
    {
        public static List<CustomerDetails> customerList = new List<CustomerDetails>();
        public static List<ProductDetails> productList = new List<ProductDetails>();
        public static List<OrderDetails> orderList = new List<OrderDetails>();
        public static CustomerDetails loggedInCustomer;

        public static void MainMenu()
        {
            try
            {
                bool flag = true;
                do
                {
                    System.Console.WriteLine("************Main Menu*************");
                    //Step1 --> Show the List of option
                    System.Console.WriteLine("Select Choice: ");
                    System.Console.WriteLine("\t1.Cutomer Registration\n\t2.Login\n\t3.Exit");
                    //Step2 --> Ask input to choose option from the user
                    int option = int.Parse(Console.ReadLine());
                    //Step3 --> Call the method that matches with the input
                    switch (option)
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
                System.Console.WriteLine("**********Registration Menu***********");
                //Step1 --> get details from the user
                System.Console.WriteLine("Enter Name: ");
                string name = Console.ReadLine();
                System.Console.WriteLine("Enter City: ");
                string city = Console.ReadLine();
                System.Console.WriteLine("Enter Mobile number: ");
                long mobile = long.Parse(Console.ReadLine());
                System.Console.WriteLine("Enter Email ID: ");
                string emailID = Console.ReadLine();

                //Step2 --> Create object for customerDetails with the details
                CustomerDetails customer = new CustomerDetails(name, city, mobile, 0, emailID);
                //Step3 --> Add object to the CustomerList
                customerList.Add(customer);
                //Step4 --> Display the Successful message and generated Customer Id
                System.Console.WriteLine("Registration Successfull,Your CustomerID is " + customer.CustomerID);
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
                //Step1 --> Ask CustumerID from the user
                System.Console.WriteLine("Enter CustomerID: ");
                string customerID = Console.ReadLine().ToUpper();
                //Step2 --> Traverse CustomerList
                foreach (CustomerDetails customer in customerList)
                {
                    //Step3 --> Check the customerList that have any match with the entered ID
                    if (customer.CustomerID == customerID)
                    {
                        //True
                        flag = true;
                        System.Console.WriteLine("Login Successful ");
                        loggedInCustomer = customer;
                        SubMenu();
                        break;
                    }
                }
                //False
                if (!flag)
                {
                    System.Console.WriteLine("Invalid ID");
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
                    System.Console.WriteLine("***********Login Menu**************");
                    //Step1 --> Show list of options
                    System.Console.WriteLine("\t1.Purchase\n\t2.Order History\n\t3.Cancel Order\n\t4.Wallet Balance\n\t5.Wallet Recharge\n\t6.Exit");
                    //Step2 --> Ask input from the user to select choice
                    int choice = int.Parse(Console.ReadLine());
                    //Step3 --> Call the method that matches with the choice
                    switch (choice)
                    {
                        case 1:
                            {
                                Purchase();
                                break;
                            }
                        case 2:
                            {
                                OrderHistory();
                                break;
                            }
                        case 3:
                            {
                                CancelOrder();
                                break;
                            }
                        case 4:
                            {
                                Balance();
                                break;
                            }
                        case 5:
                            {
                                Recharge();
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
        public static void Purchase()
        {
            try
            {
                //Step1 --> Traverse productList
                foreach (ProductDetails product in productList)
                {
                    //Step2 --> Show details of the products
                    System.Console.WriteLine($"{product.ProductID} {product.ProductName} {product.Price} {product.Duration}days");
                }
                //Step3 --> Asks productID from the user to start the purchase
                System.Console.WriteLine("Enter Product ID to purchase: ");
                string productID = Console.ReadLine().ToUpper();

                //Step4 --> Asks user to enter quantity of the product needed 
                System.Console.WriteLine("Enter the Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                bool flag = false;
                //Step5 --> Traverse productList
                foreach (ProductDetails product in productList)
                {
                    //Step6 --> Check the entered product have any match with the productList
                    //True
                    if (product.ProductID == productID)
                    {
                        flag = true;
                        //Step7 --> Check the quantity of the product is above the needed quantity
                        //True
                        if (product.Stock >= quantity)
                        {
                            //Step8 --> Find Total price for the entered quantity and add delivery charge of 50 rupees
                            double Total = (quantity * product.Price) + 50;
                            //Step9 --> Show the Total Price and ask for a confirmation
                            System.Console.WriteLine($"Total Amount: {Total}\nPress 1 to Place order");
                            int confirm = int.Parse(Console.ReadLine());
                            if (confirm == 1)
                            {
                                //Step 10 -->  Check the Customer's Walletbalance is enough for the purchase
                                //True
                                if (loggedInCustomer.WalletBalance >= Total)
                                {
                                    OrderDetails order = new OrderDetails(loggedInCustomer.CustomerID, product.ProductID, Total, DateTime.Now, quantity, OrderStatus.Ordered);
                                    orderList.Add(order);
                                    System.Console.WriteLine("Order Placed Successfully, Order ID: " + order.OrderID);
                                    System.Console.WriteLine("Your order will be delivered on " + order.PurchaseDate.AddDays(product.Duration).ToString("dd/MM/yyyy"));
                                    loggedInCustomer.Deduct(Total);
                                    product.Stock -= quantity;
                                }
                                //False
                                else
                                {
                                    System.Console.WriteLine("Insufficient Balance. Please recharge your wallet and do the purchase again");
                                }
                            }
                        }
                        //False --> Product out of stock
                        else
                        {
                            System.Console.WriteLine($"Required count not available. Current availability is {product.Stock}");
                        }
                    }
                }
                //False --> If the productID didn't match
                if (!flag)
                {
                    System.Console.WriteLine("Invalid ProductID");
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
                bool flag = true;
                //Step1 --> Traverse orderList
                foreach (OrderDetails order in orderList)
                {
                    //Step2 --> Check the orderlist to find the login Customer's order
                    if (order.CustomerID == loggedInCustomer.CustomerID)
                    {
                        flag = false;
                        //Step3 --> Show the order details of the customer
                        System.Console.WriteLine($"\nOrder ID: {order.OrderID}\nProduct ID: {order.ProductID}\nTotal Price: {order.TotalPrice}");
                        System.Console.WriteLine($"Purchase Date: {order.PurchaseDate:dd/MM/yyyy}\nQuantity: {order.Quantity}\nStatus: {order.Status}");
                    }
                }
                //False
                if (flag)
                {
                    System.Console.WriteLine("The Order List is Empty");
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
                //Step1 --> Traverse orderList
                foreach (OrderDetails order in orderList)
                {
                    //Step2 --> Check for the login customerID and ordered products in orderList
                    if (loggedInCustomer.CustomerID == order.CustomerID && order.Status == OrderStatus.Ordered)
                    {
                        //Step3 --> Show the list of ordered products of login customer
                        System.Console.WriteLine($"Order ID: {order.OrderID} \nTotal Price: {order.TotalPrice} \nQuantity: {order.Quantity} \nPurchase Date: {order.PurchaseDate}\n");
                    }
                }

                //Step4 --> Ask user to enter OrderID to be cancel
                System.Console.WriteLine("Enter Order ID: ");
                string orderID = Console.ReadLine().ToUpper();
                bool cancelflag = false;
                //Step5 --> Traverse orderList
                foreach (OrderDetails order in orderList)
                {
                    //Step6 --> entered orderID in orderList and also check orderstatus is Ordered
                    //True
                    if (order.OrderID == orderID && order.Status == OrderStatus.Ordered)
                    {
                        //Step7 --> Check for login customerID in orderList
                        if (loggedInCustomer.CustomerID == order.CustomerID)
                        {
                            cancelflag = true;
                            //Step8 --> Traverse productList
                            foreach (ProductDetails product in productList)
                            {
                                //Step9 --> Check for the cancelled productID in productList
                                //True
                                if (product.ProductID == order.ProductID)
                                {
                                    //Step 10 --> Increase the product count with ordered quantity
                                    product.Stock += order.Quantity;
                                    //Step 11 --> Return Ordered amount to Customer's Wallet
                                    loggedInCustomer.WalletBalance += order.TotalPrice;
                                    //Step 12 --> Change OrderStatus to Cancelled
                                    order.Status = OrderStatus.Cancelled;
                                    //Step 13 --> Show the successful message with orderID
                                    System.Console.WriteLine($"Order ID {order.OrderID} is cancelled successfully");
                                }
                            }
                        }
                    }
                }
                //False --> If OrderID didn't match with orderList
                if (!cancelflag)
                {
                    System.Console.WriteLine("Invalid Order ID");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void Balance()
        {
            try
            {
                //Show the Customer's balance
                System.Console.WriteLine("Balance: " + loggedInCustomer.WalletBalance);
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
                //Step1 --> Ask for a confirmation to make recharge
                System.Console.WriteLine("Do you want to recharge your account:  (Yes/No) ");
                string option = Console.ReadLine().ToUpper();
                //True
                if (option == "YES")
                {
                    //Step2 --> Asks for the recharge amount
                    System.Console.WriteLine("Enter Recharge amount: ");
                    double amount = double.Parse(Console.ReadLine());
                    //Step3 --> Checks the amount is valid
                    //True
                    if (amount > 0)
                    {
                        //Step4 --> Add amount to Walletbalance
                        loggedInCustomer.Recharge(amount);
                        //Step5 --> Show updated balance
                        System.Console.WriteLine("Updated Balance: " + loggedInCustomer.WalletBalance);
                    }
                    //False --> Invalid amount
                    else
                    {
                        System.Console.WriteLine("Please enter valid recharge amount");
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
            //Create Objects of customer1 and customer2 for CustomerDetails
            CustomerDetails customer1 = new CustomerDetails("Ravi", "Chennai", 9885858588, 50000, "ravi@mail.com");
            CustomerDetails customer2 = new CustomerDetails("Baskaran", "Chennai", 9888475757, 60000, "baskaran@mail.com");
            //Add objects to the Customerlist
            customerList.Add(customer1);
            customerList.Add(customer2);

            //Create product1,product2,product3,product3,product5,product6 and product7 for ProductDetails
            ProductDetails product1 = new ProductDetails("Mobile(Samsung)", 10, 10000, 3);
            ProductDetails product2 = new ProductDetails("Tablet(Lenova)", 5, 15000, 2);
            ProductDetails product3 = new ProductDetails("Camera(Sony)", 3, 20000, 4);
            ProductDetails product4 = new ProductDetails("iPhone", 5, 50000, 6);
            ProductDetails product5 = new ProductDetails("Laptop(Lenova 13)", 3, 40000, 3);
            ProductDetails product6 = new ProductDetails("Headphone(Boat)", 5, 1000, 2);
            ProductDetails product7 = new ProductDetails("Speakers(Boat)", 4, 500, 2);
            //Add objects to the productList
            productList.Add(product1);
            productList.Add(product2);
            productList.Add(product3);
            productList.Add(product4);
            productList.Add(product5);
            productList.Add(product6);
            productList.Add(product7);

            //Create order1 and order2 for OrderDetails
            OrderDetails order1 = new OrderDetails("CID3001", "PID2001", 20000, DateTime.Now, 2, OrderStatus.Ordered);
            OrderDetails order2 = new OrderDetails("CID3002", "PID2003", 40000, DateTime.Now, 2, OrderStatus.Ordered);
            //Add objects to orderList
            orderList.Add(order1);
            orderList.Add(order2);
        }
    }
}