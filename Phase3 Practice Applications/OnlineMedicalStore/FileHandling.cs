using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace OnlineMedicalStore
{
    public class FileHandling
    {
        public static void Create()
        {
            //Check Data folder is exists
            if (!Directory.Exists("OnlineMedicalStoreData"))
            {
                //Create Data Folder
                Directory.CreateDirectory("OnlineMedicalStoreData");
                //Show message
                System.Console.WriteLine("Data folder created successfully");
            }

            //Check UserDetails file is exists
            if (!File.Exists("OnlineMedicalStoreData/UserDetails.csv"))
            {
                //Create UserDetails CSV file
                File.Create("OnlineMedicalStoreData/UserDetails.csv").Close();
                //Show message
                System.Console.WriteLine("User Details file created successfully");
            }

            //Check MedicineDetails file is exists
            if (!File.Exists("OnlineMedicalStoreData/MedicineDetails.csv"))
            {
                //Create MedicineDetails CSV file
                File.Create("OnlineMedicalStoreData/MedicineDetails.csv").Close();
                //Show message
                System.Console.WriteLine("Medicine Details file created successfully");
            }

            //Check OrderDetails file is exists
            if (!File.Exists("OnlineMedicalStoreData/OrderDetails.csv"))
            {
                //Create OrderDetails CSV file
                File.Create("OnlineMedicalStoreData/OrderDetails.csv").Close();
                //Show message
                System.Console.WriteLine("Order Details file created successfully");
            }
        }

        public static void WriteToCSV()
        {
            //Write user Details to csv file
            string[] users = new string[Operations.userList.Count];
            //Adding values to array
            for (int i = 0; i < Operations.userList.Count; i++)
            {
                users[i] = $"{Operations.userList[i].UserID},{Operations.userList[i].Name},{Operations.userList[i].Age},{Operations.userList[i].City},{Operations.userList[i].Phone},{Operations.userList[i].WalletBalance}";
            }
            //Load values in array to csv file
            File.WriteAllLines("OnlineMedicalStoreData/UserDetails.csv", users);

            //Write medicine Details to csv file
            string[] medicines = new string[Operations.medicineList.Count];
            //Adding values to array
            for (int i = 0; i < Operations.medicineList.Count; i++)
            {
                medicines[i] = $"{Operations.medicineList[i].MedicineID},{Operations.medicineList[i].MedicineName},{Operations.medicineList[i].AvailableCount},{Operations.medicineList[i].Price},{Operations.medicineList[i].DateOfExpiry.ToString("dd/MM/yyyy")}";
            }
            //Load values in array to csv file
            File.WriteAllLines("OnlineMedicalStoreData/MedicineDetails.csv", medicines);

            //Write order Details to csv file
            string[] orders = new string[Operations.orderList.Count];
            //Adding values to array
            for (int i = 0; i < Operations.orderList.Count; i++)
            {
                orders[i] = $"{Operations.orderList[i].OrderID},{Operations.orderList[i].UserID},{Operations.orderList[i].MedicineID},{Operations.orderList[i].MedicineCount},{Operations.orderList[i].TotalPrice},{Operations.orderList[i].OrderDate.ToString("dd/MM/yyyy")},{Operations.orderList[i].Status}";
            }
            //Load values in array to csv file
            File.WriteAllLines("OnlineMedicalStoreData/OrderDetails.csv", orders);
        }

        public static void ReadFromCSV()
        {
            //Read csv file  datas into array
            string[] users = File.ReadAllLines("OnlineMedicalStoreData/UserDetails.csv");
            foreach (string user in users)
            {
                //Add values into list
                Operations.userList.Add(new UserDetails(user));
            }

            //Read csv file  datas into array
            string[] medicines = File.ReadAllLines("OnlineMedicalStoreData/MedicineDetails.csv");
            foreach (string medicine in medicines)
            {
                //Add values into list
                Operations.medicineList.Add(new MedicineDetails(medicine));
            }

            //Read csv file  datas into array
            string[] orders = File.ReadAllLines("OnlineMedicalStoreData/OrderDetails.csv");
            foreach (string order in orders)
            {
                //Add values into list
                Operations.orderList.Add(new OrderDetails(order));
            }
        }
    }
}