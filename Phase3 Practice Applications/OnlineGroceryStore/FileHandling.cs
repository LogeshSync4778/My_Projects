using System;
using System.IO;

namespace OnlineGroceryStore
{
    public class FileHandling
    {
        public static void Create()
        {
            //Checks the Data Folder exists
            if (!Directory.Exists("OnlineGroceryStoreData"))
            {
                //Create the Data Folder
                Directory.CreateDirectory("OnlineGroceryStoreData");
                //Show successful message after creation
                System.Console.WriteLine("Successfully created Online Grocery Store Data Folder");
            }

            //Customer Details File
            if (!File.Exists("OnlineGroceryStoreData/CustomerDetails.csv"))
            {
                //Create CSV file for CustomerDetails
                File.Create("OnlineGroceryStoreData/CustomerDetails.csv").Close();
                //Show successful message after creation
                System.Console.WriteLine("Successfully created CustomerDetails File");
            }

            //Product Details File
            if (!File.Exists("OnlineGroceryStoreData/ProductDetails.csv"))
            {
                //Create CSV file for ProductDetails
                File.Create("OnlineGroceryStoreData/ProductDetails.csv").Close();
                //Show successful message after creation
                System.Console.WriteLine("Successfully created ProductDetails File");
            }

            //Booking Details File
            if (!File.Exists("OnlineGroceryStoreData/BookingDetails.csv"))
            {
                //Create CSV file for BookingDetails
                File.Create("OnlineGroceryStoreData/BookingDetails.csv").Close();
                //Show successful message after creation
                System.Console.WriteLine("Successfully created BookingDetails File");
            }

            //Order Details File
            if (!File.Exists("OnlineGroceryStoreData/OrderDetails.csv"))
            {
                //Create CSV file for OrderDetails
                File.Create("OnlineGroceryStoreData/OrderDetails.csv").Close();
                //Show successful message after creation
                System.Console.WriteLine("Successfully created OrderDetails File");
            }
        }
        public static void WriteToCSV()
        {
            //Write Customer List to CSV
            string[] customers = new string[Operations.customerList.Count];
            for (int i = 0; i < Operations.customerList.Count; i++)
            {
                customers[i] = $"{Operations.customerList[i].CustomerID},{Operations.customerList[i].WalletBalance},{Operations.customerList[i].Name},{Operations.customerList[i].FatherName},{Operations.customerList[i].Gender},{Operations.customerList[i].Mobile},{Operations.customerList[i].DOB:dd/MM/yyyy},{Operations.customerList[i].MailID}";
            }
            File.WriteAllLines("OnlineGroceryStoreData/CustomerDetails.csv", customers);

            // Write Product List to CSV                                                                                                                                    
            string[] products = new string[Operations.productList.Count];
            for (int i = 0; i < Operations.productList.Count; i++)
            {
                products[i] = $"{Operations.productList[i].ProductID},{Operations.productList[i].ProductName},{Operations.productList[i].QuantityAvailable},{Operations.productList[i].PricePerQuantity}";
            }
            File.WriteAllLines("OnlineGroceryStoreData/ProductDetails.csv", products);

            //Write Booking List to CSV 
            string[] bookings = new string[Operations.bookingList.Count];
            for (int i = 0; i < Operations.bookingList.Count; i++)
            {
                bookings[i] = $"{Operations.bookingList[i].BookingID},{Operations.bookingList[i].CustomerID},{Operations.bookingList[i].TotalPrice},{Operations.bookingList[i].DateOfBooking.ToString("dd/MM/yyyy")},{Operations.bookingList[i].Status}";
            }
            File.WriteAllLines("OnlineGroceryStoreData/BookingDetails.csv", bookings);

            //Write Order List to CSV
            string[] orders = new string[Operations.orderList.Count];
            for (int i = 0; i < Operations.orderList.Count; i++)
            {
                orders[i] = $"{Operations.orderList[i].OrderID},{Operations.orderList[i].BookingID},{Operations.orderList[i].ProductID},{Operations.orderList[i].PurchaseCOunt},{Operations.orderList[i].PriceOfOrder}";
            }
            File.WriteAllLines("OnlineGroceryStoreData/OrderDetails.csv", orders);
        }

        public static void ReadFromCSV()
        {
            //Read from Customerlist csv file
            string[] customers = File.ReadAllLines("OnlineGroceryStoreData/CustomerDetails.csv");
            foreach (string customer in customers)
            {
                CustomerDetails newcustomer = new CustomerDetails(customer);
                Operations.customerList.Add(newcustomer);
            }

            // Read from Productlist csv file
            string[] products = File.ReadAllLines("OnlineGroceryStoreData/ProductDetails.csv");
            foreach (string product in products)
            {
                ProductDetails newproduct = new ProductDetails(product);
                Operations.productList.Add(newproduct);
            }

            //Read from Bookinglist csv file
            string[] bookings = File.ReadAllLines("OnlineGroceryStoreData/BookingDetails.csv");
            foreach (string booking in bookings)
            {
                BookingDetails newbooking = new BookingDetails(booking);
                Operations.bookingList.Add(newbooking);
            }

            //Read from Orderlist csv file
            string[] orders = File.ReadAllLines("OnlineGroceryStoreData/OrderDetails.csv");
            foreach (string order in orders)
            {
                OrderDetails neworder = new OrderDetails(order);
                Operations.orderList.Add(neworder);
            }
        }
    }
}