using System;
using System.Collections.Generic;
using System.IO;


namespace ECommerce
{
    public class FileHandling
    {
        public static void Create()
        {
            //Create Folder
            if (!Directory.Exists("Data"))
            {
                Directory.CreateDirectory("Data");
                System.Console.WriteLine("Data Folder successfully created");
            }
            if (!File.Exists("Data/CustomerDetails.csv"))
            {
                File.Create("Data/CustomerDetails.csv");
                System.Console.WriteLine("CustomerDetails file successfully created");
            }
            if (!File.Exists("Data/ProductDetails.csv"))
            {
                File.Create("Data/ProductDetails.csv");
                System.Console.WriteLine("ProductList file successfully created");
            }
            if (!File.Exists("Data/OrderDetails.csv"))
            {
                File.Create("Data/OrderDetails.csv");
                System.Console.WriteLine("Orderdetails file successfully created");
            }
        }

        public static void WriteToCSV()
        {
            //CustomerDetails
            string[] customer=new string[Operations.customerList.Count];
            for(int i=0;i<Operations.customerList.Count;i++)
            {
                customer[i]=$"{Operations.customerList[i].CustomerID},{Operations.customerList[i].CustomerName},{Operations.customerList[i].City},{Operations.customerList[i].Mobile},{Operations.customerList[i].WalletBalance},{Operations.customerList[i].EmailID}";
            }
            File.WriteAllLines("Data/CustomerDetails.csv",customer);

            //ProductDetails
            string[] product=new string[Operations.productList.Count];
            for(int i=0;i<Operations.productList.Count;i++)
            {
                product[i]=$"{Operations.productList[i].ProductID},{Operations.productList[i].ProductName},{Operations.productList[i].Stock},{Operations.productList[i].Price},{Operations.productList[i].Duration}";
            }
            File.WriteAllLines("Data/ProductDetails.csv",product);

            //OrderDetails
            string[] order=new string[Operations.orderList.Count];
            for(int i=0;i<Operations.orderList.Count;i++)
            {
                order[i]=$"{Operations.orderList[i].OrderID},{Operations.orderList[i].CustomerID},{Operations.orderList[i].ProductID},{Operations.orderList[i].TotalPrice},{Operations.orderList[i].PurchaseDate.ToString("dd/MM/yyyy")},{Operations.orderList[i].Quantity},{Operations.orderList[i].Status}";
            }
            File.WriteAllLines("Data/OrderDetails.csv",order);
        }
        public static void ReadfromCSV()
        {
            string[] customers=File.ReadAllLines("Data/CustomerDetails.csv");
            foreach (string customer in customers)
            {
                CustomerDetails customer1=new CustomerDetails(customer);
                Operations.customerList.Add(customer1);
            }

            string[] products=File.ReadAllLines("Data/ProductDetails.csv");
            foreach(string product in products)
            {
                ProductDetails product1=new ProductDetails(product);
                Operations.productList.Add(product1);
            }

            string[] orders=File.ReadAllLines("Data/OrderDetails.csv");
            foreach(string order in orders)
            {
                OrderDetails order1=new OrderDetails(orders);
                Operations.orderList.Add(order1);
            }
        }
    }
}