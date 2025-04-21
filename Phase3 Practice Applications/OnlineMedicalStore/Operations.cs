using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class Operations
    {
        // Create user List
        public static CustomList<UserDetails> userList = new CustomList<UserDetails>();
        //Create medicine List
        public static CustomList<MedicineDetails> medicineList = new CustomList<MedicineDetails>();
        //Create order List
        public static CustomList<OrderDetails> orderList = new CustomList<OrderDetails>();
        //Create loginUser object
        public static UserDetails loginUser;

        public static void MainMenu()
        {
            try
            {
                bool flag = true;
                do
                {
                    System.Console.WriteLine("***********Main Menu*************");
                    //Show the list of available options in Mainmenu
                    System.Console.WriteLine("Select choice:\n\t1.User Registration\n\t2.User Login\n\t3.Exit");
                    //Get input from the user to select choice
                    int choice = int.Parse(Console.ReadLine());
                    //Check the choice and Call method which is user selected
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
                System.Console.WriteLine("***********Registration Menu*************");
                //Get details from the user
                System.Console.WriteLine("Enter Name: ");
                string name = Console.ReadLine();
                System.Console.WriteLine("Age: ");
                int age = int.Parse(Console.ReadLine());
                System.Console.WriteLine("City: ");
                string city = Console.ReadLine();
                System.Console.WriteLine("Phone: ");
                long phone = long.Parse(Console.ReadLine());

                //Create object in userDetails with entered user details
                UserDetails user = new UserDetails(name, age, city, phone, 0);
                //Add object to the list
                userList.Add(user);
                //Show the successfull message and generated userID to user
                System.Console.WriteLine("Registration Successfull, you User ID is " + user.UserID);
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
                System.Console.WriteLine("***********Login Menu*************");
                //Get user to enter user ID
                System.Console.WriteLine("Enter user ID: ");
                //Get input from the user
                string userID = Console.ReadLine().ToUpper();
                //Traverse userList
                foreach (UserDetails user in userList)
                {
                    //Check entered userID in userList
                    if (user.UserID == userID)
                    {
                        flag = true;
                        //Show successful message
                        System.Console.WriteLine("Login Successfull");
                        //Assign user details to loginUser
                        loginUser = user;
                        //Call Submenu
                        SubMenu();
                        break;
                    }
                }
                //If entered userID didn't found in userList
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
                    //Show the list of available options in Submenu
                    System.Console.WriteLine("***********SubMenu*************");
                    System.Console.WriteLine("Select choice: \n\t1.Show Medicine List\n\t2.Purchase Medicine\n\t3.Modify Purchase\n\t4.Cancel Purchase\n\t5.Show Purchase History\n\t6.Recharge Wallet\n\t7.Show Wallet Balance\n\t8.Exit");
                    //Get input from the user
                    int choice = int.Parse(Console.ReadLine());
                    //Check input and call method user selected
                    switch (choice)
                    {
                        case 1:
                            {
                                ShowMedicineList();
                                break;
                            }
                        case 2:
                            {
                                PurchaseMedicine();
                                break;
                            }
                        case 3:
                            {
                                ModifyPurchase();
                                break;
                            }
                        case 4:
                            {
                                CancelPurchase();
                                break;
                            }
                        case 5:
                            {
                                ShowPurchaseHistory();
                                break;
                            }
                        case 6:
                            {
                                RechargeWallet();
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
        public static void ShowMedicineList()
        {
            try
            {
                System.Console.WriteLine("***********Medicine List*************");
                //Traverse medicineList
                foreach (MedicineDetails medicine in medicineList)
                {
                    //Show the available medicine list
                    System.Console.WriteLine($"Medicine ID: {medicine.MedicineID} | Medicine Name: {medicine.MedicineName}\t| Available Count: {medicine.AvailableCount} | Price: {medicine.Price} | Expiry Date: {medicine.DateOfExpiry:dd/MM/yyyy}");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void PurchaseMedicine()
        {
            try
            {
                System.Console.WriteLine("***********Purchase Menu*************");
                //Traverse Medicine List
                foreach (MedicineDetails medicine in medicineList)
                {
                    //Show list of medicines available
                    System.Console.WriteLine($"Medicine ID: {medicine.MedicineID} | Medicine Name: {medicine.MedicineName} | Available Count: {medicine.AvailableCount} | Price: {medicine.Price} | Expiry Date: {medicine.DateOfExpiry:dd/MM/yyyy}");
                }
                //Ask user to select medicine ID to start purchase
                System.Console.WriteLine("Select medicine ID to purchase:");
                bool IDflag = false;
                //Get input from the user
                string medicineID = Console.ReadLine().ToUpper();
                //Traverse medicine list
                foreach (MedicineDetails medicine in medicineList)
                {
                    //Find the entered medicine ID in medicineList
                    if (medicine.MedicineID == medicineID)
                    {
                        IDflag = true;
                        //Ask user to enter the purchase quantity
                        System.Console.WriteLine("Enter the quanity to purchase:");
                        //Get input from  the user
                        int quantity = int.Parse(Console.ReadLine());
                        //Check the total stock in medicine list with entered quanity
                        if (medicine.AvailableCount >= quantity)
                        {
                            //Check the expiry date of the medicine
                            if (medicine.DateOfExpiry >= DateTime.Now)
                            {
                                double TotalPrice = medicine.Price * quantity;
                                //Check user's wallet balance is enough to make purchase
                                if (loginUser.WalletBalance >= TotalPrice)
                                {
                                    //Reduce the purchase quantity in total stock
                                    medicine.AvailableCount -= quantity;
                                    //Deduct purchase amount in user's wallet
                                    loginUser.DeductBalance(TotalPrice);
                                    //Create order object and add into orderList
                                    OrderDetails order = new OrderDetails(loginUser.UserID, medicine.MedicineID, quantity, TotalPrice, DateTime.Now, OrderStatus.Purchased);
                                    orderList.Add(order);
                                    //Show Successful message
                                    System.Console.WriteLine("Order placed successfully, Your OrderID is " + order.OrderID);
                                }
                                // False --> Ask user to make recharge and proceed
                                else
                                {
                                    System.Console.WriteLine("Please recharge your wallet and try again");
                                }
                            }
                            //False
                            else
                            {
                                System.Console.WriteLine("Medicine is not available");
                            }
                        }
                        //False
                        else
                        {
                            System.Console.WriteLine("Medicine quantity out of stock");
                        }
                    }
                }
                if (!IDflag)
                {
                    System.Console.WriteLine("Invalid Medicine ID");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void ModifyPurchase()
        {
            try
            {
                System.Console.WriteLine("***********Modification Menu*************");
                bool modifyflag = false;
                //Traverse order List
                foreach (OrderDetails order in orderList)
                {
                    //Find the login user's CustomerID in orderList and having purchased status
                    if (order.UserID == loginUser.UserID && order.Status == OrderStatus.Purchased)
                    {
                        modifyflag = true;
                        //Show the order history
                        System.Console.WriteLine($"Order ID: {order.OrderID} | Medicine ID: {order.MedicineID} | Medicine Count: {order.MedicineCount} | Total Price: {order.TotalPrice}");
                    }
                }

                if (modifyflag)
                {
                    //Ask user to select order ID to modify
                    System.Console.WriteLine("Select OrderID to modify:");
                    //Get input from the user
                    string orderID = Console.ReadLine().ToUpper();
                    //Traverse orderList
                    foreach (OrderDetails order in orderList)
                    {
                        //Find the orderID in orderList
                        if (order.OrderID == orderID && order.UserID == loginUser.UserID && order.Status == OrderStatus.Purchased)
                        {
                            //Ask user to enter new quantity of medicine
                            System.Console.WriteLine("Enter quantity to purchase:");
                            //Get input from the user
                            int quantity = int.Parse(Console.ReadLine());
                            //Check the user is increasing or decreasing quantity
                            if (quantity > order.MedicineCount)
                            {
                                //Find the new purchase quantity
                                int purchaseQuantity = quantity - order.MedicineCount;
                                //Traverse Medicine List
                                foreach (MedicineDetails medicine in medicineList)
                                {
                                    //Find the medicine ID in orderList in medicineList
                                    if (order.MedicineID == medicine.MedicineID)
                                    {
                                        //Check the Stock availability
                                        if (medicine.AvailableCount >= purchaseQuantity)
                                        {
                                            //Calculate Total price
                                            double TotalPrice = medicine.Price * purchaseQuantity;
                                            //Check user's wallet
                                            if (loginUser.WalletBalance >= TotalPrice)
                                            {
                                                //Deduct Total price in user's wallet
                                                loginUser.DeductBalance(TotalPrice);
                                                //Reduce product count in total stock
                                                medicine.AvailableCount -= purchaseQuantity;

                                                //Update order details
                                                order.MedicineCount += purchaseQuantity;
                                                order.TotalPrice += TotalPrice;

                                                //Show successfull message
                                                System.Console.WriteLine("Order modified successfully");
                                            }
                                        }
                                        else
                                        {
                                            System.Console.WriteLine("Medicine quanity out of stock");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                int returnQuantity = order.MedicineCount - quantity;
                                foreach (MedicineDetails medicine in medicineList)
                                {
                                    //Find the medicine ID in orderList in medicineList
                                    if (order.MedicineID == medicine.MedicineID)
                                    {
                                        //Calculate Total price
                                        double TotalPrice = medicine.Price * returnQuantity;

                                        //Add Total price in user's wallet
                                        loginUser.WalletRecharge(TotalPrice);
                                        //Increase product count in total stock
                                        medicine.AvailableCount += returnQuantity;

                                        //Update order details
                                        order.MedicineCount -= returnQuantity;
                                        order.TotalPrice -= TotalPrice;

                                        //Show successfull message
                                        System.Console.WriteLine("Order modified successfully");

                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("You didn't purchase any medicine");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void CancelPurchase()
        {
            try
            {
                bool cancelflag = false;
                System.Console.WriteLine("***********Cancellation Menu*************");
                //Traverse order List
                foreach (OrderDetails order in orderList)
                {
                    //Find the login user's CustomerID in orderList and having purchased status
                    if (order.UserID == loginUser.UserID && order.Status == OrderStatus.Purchased)
                    {
                        cancelflag = true;
                        //Show the order history
                        System.Console.WriteLine($"Order ID: {order.OrderID} | Medicine ID: {order.MedicineID} | Medicine Count: {order.MedicineCount} | Total Price: {order.TotalPrice}");
                    }
                }
                if (cancelflag)
                {
                    //Ask user to select orderID to be cancel
                    System.Console.WriteLine("Select Order ID to cancel:");
                    //Get input from the user
                    string orderID = Console.ReadLine().ToUpper();
                    //Traverse Orderlist
                    foreach (OrderDetails order in orderList)
                    {
                        //Check the entered orderID is belongs to user and having purchased status --> Please enter your order ID
                        if (order.OrderID == orderID && order.UserID == loginUser.UserID && order.Status == OrderStatus.Purchased)
                        {
                            //Traverse medicine list
                            foreach (MedicineDetails medicine in medicineList)
                            {
                                //Find the medicine ID in orderList
                                if (medicine.MedicineID == order.MedicineID)
                                {
                                    //Increase medicine count
                                    medicine.AvailableCount += order.MedicineCount;
                                    //Return purchased amount to user's wallet
                                    loginUser.WalletRecharge(order.TotalPrice);
                                    //Change status to cancelled
                                    order.Status = OrderStatus.Cancelled;
                                    //Show the successfull message with order ID
                                    System.Console.WriteLine($"Order ID {order.OrderID} is successfully cancelled");
                                }
                            }
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("You didn't purchase any product");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void ShowPurchaseHistory()
        {
            try
            {
                bool historyflag = false;
                System.Console.WriteLine("***********Purchase History*************");
                //Traverse order List
                foreach (OrderDetails order in orderList)
                {
                    //Find the login user's CustomerID in orderList and having purchased status
                    if (order.UserID == loginUser.UserID)
                    {
                        historyflag = true;
                        //Show the purchase history
                        System.Console.WriteLine($"Order ID: {order.OrderID} | Medicine ID: {order.MedicineID} | Medicine Count: {order.MedicineCount} | Total Price: {order.TotalPrice} |Order Date: {order.OrderDate:dd/MM/yyyy} | Status: {order.Status}");
                    }
                }
                if (!historyflag)
                {
                    System.Console.WriteLine("Your purchase history is empty");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        public static void RechargeWallet()
        {
            try
            {
                //Ask user to enter the recharge amount
                System.Console.WriteLine("Enter the Recharge amount:");
                //get input from the user
                double amount = double.Parse(Console.ReadLine());
                //Check the amount is valid
                //True
                if (amount > 0)
                {
                    loginUser.WalletRecharge(amount);
                    //Show successfull message with updated balance
                    System.Console.WriteLine("Recharge Successfull, your updated balance is " + loginUser.WalletBalance);
                }
                //False
                else
                {
                    //Show warning message
                    System.Console.WriteLine("Please enter valid amount to recharge");
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
            //Create and add objects in userList
            userList.Add(new UserDetails("Ravi", 33, "Theni", 9877774440, 400));
            userList.Add(new UserDetails("Baskaran", 33, "Chennai", 8847757470, 500));

            //Create and add objects in MedicineList
            medicineList.Add(new MedicineDetails("Paracitamol", 40, 5, DateTime.ParseExact("30/06/2024", "dd/MM/yyyy", null)));
            medicineList.Add(new MedicineDetails("Calpol", 10, 5, DateTime.ParseExact("30/05/2024", "dd/MM/yyyy", null)));
            medicineList.Add(new MedicineDetails("Gelucil", 3, 40, DateTime.ParseExact("30/04/2023", "dd/MM/yyyy", null)));
            medicineList.Add(new MedicineDetails("Metrogel", 5, 50, DateTime.ParseExact("30/12/2024", "dd/MM/yyyy", null)));
            medicineList.Add(new MedicineDetails("Povidin Iodin", 10, 50, DateTime.ParseExact("30/10/2024", "dd/MM/yyyy", null)));

            //Create and add objects in OrderList
            orderList.Add(new OrderDetails("UID1001", "MD101", 3, 15, DateTime.ParseExact("13/11/2022", "dd/MM/yyyy", null), OrderStatus.Purchased));
            orderList.Add(new OrderDetails("UID1001", "MD102", 2, 10, DateTime.ParseExact("13/11/2022", "dd/MM/yyyy", null), OrderStatus.Cancelled));
            orderList.Add(new OrderDetails("UID1001", "MD104", 2, 100, DateTime.ParseExact("13/11/2022", "dd/MM/yyyy", null), OrderStatus.Purchased));
            orderList.Add(new OrderDetails("UID1002", "MD103", 3, 120, DateTime.ParseExact("15/11/2022", "dd/MM/yyyy", null), OrderStatus.Cancelled));
            orderList.Add(new OrderDetails("UID1002", "MD105", 5, 250, DateTime.ParseExact("15/11/2022", "dd/MM/yyyy", null), OrderStatus.Purchased));
            orderList.Add(new OrderDetails("UID1002", "MD102", 3, 15, DateTime.ParseExact("15/11/2022", "dd/MM/yyyy", null), OrderStatus.Purchased));
        }
    }
}
