using System;
using System.Collections;
using System.IO;

namespace SyncStays
{
    public class FileHandling
    {
        public static void Create()
        {
            //Check the Data folder is exists
            if (!Directory.Exists("SyncStaysData"))
            {
                //Create Data folder
                Directory.CreateDirectory("SyncStaysData");

                //Show successfull message
                System.Console.WriteLine("Data folder created successfully");
            }

            //Check the UserDetails csv file is exists
            if (!File.Exists("SyncStaysData/UserDetails.csv"))
            {
                //Create csv file
                File.Create("SyncStaysData/UserDetails.csv").Close();

                //Show successfull message
                System.Console.WriteLine("CSV file for UserDetails created successfully");
            }

            //Check the RoomDetails csv file is exists
            if (!File.Exists("SyncStaysData/RoomDetails.csv"))
            {
                //Create csv file
                File.Create("SyncStaysData/RoomDetails.csv").Close();

                //Show successfull message
                System.Console.WriteLine("CSV file for RoomDetails created successfully");
            }

            //Check the RoomSelectionDetails csv file is exists
            if (!File.Exists("SyncStaysData/RoomSelectionDetails.csv"))
            {
                //Create csv file
                File.Create("SyncStaysData/RoomSelectionDetails.csv").Close();

                //Show successfull message
                System.Console.WriteLine("CSV file for RoomSelection created successfully");
            }

            //Check the BookingDetails csv file is exists
            if (!File.Exists("SyncStaysData/BookingDetails.csv"))
            {
                //Create csv file
                File.Create("SyncStaysData/BookingDetails.csv").Close();

                //Show successfull message
                System.Console.WriteLine("CSV file for BookingDetails created successfully");
            }
        }
        public static void WriteToCSV()
        {
            //Create a new array to store data
            string[] users = new string[Operations.userList.Count];
            //Traverse userList
            for (int i = 0; i < Operations.userList.Count; i++)
            {
                //Store values in array
                users[i] = $"{Operations.userList[i].UserID},{Operations.userList[i].UserName},{Operations.userList[i].MobileNumber},{Operations.userList[i].AadharNumber},{Operations.userList[i].Address},{Operations.userList[i].FoodType},{Operations.userList[i].Gender},{Operations.userList[i].WalletBalance}";
            }
            //Write values to csv file
            File.WriteAllLines("SyncStaysData/UserDetails.csv", users);

            //Create a new array to store data
            string[] rooms = new string[Operations.roomList.Count];
            //Traverse roomList
            for (int i = 0; i < Operations.roomList.Count; i++)
            {
                //Store values in array
                rooms[i] = $"{Operations.roomList[i].RoomID},{Operations.roomList[i].RoomType},{Operations.roomList[i].NumberOfBeds},{Operations.roomList[i].PricePerDay}";
            }
            //Write valyes to csv file
            File.WriteAllLines("SyncStaysData/RoomDetails.csv", rooms);

            //Create a new array to store data
            string[] selections = new string[Operations.roomselectionList.Count];
            //Traverse roomselectionList
            for (int i = 0; i < Operations.roomselectionList.Count; i++)
            {
                //Store values in array
                selections[i] = $"{Operations.roomselectionList[i].SelectionID},{Operations.roomselectionList[i].BookingID},{Operations.roomselectionList[i].RoomID},{Operations.roomselectionList[i].StayingDateFrom.ToString("dd/MM/yyyy hh:mm tt")},{Operations.roomselectionList[i].StayingDateTo.ToString("dd/MM/yyyy hh:mm tt")},{Operations.roomselectionList[i].Price},{Operations.roomselectionList[i].NumberOfDays},{Operations.roomselectionList[i].Status}";
            }
            //Write values to csv file
            File.WriteAllLines("SyncStaysData/RoomSelectionDetails.csv", selections);

            //Create a new array to store data
            string[] bookings = new string[Operations.bookingList.Count];
            //Traverse bookingList
            for (int i = 0; i < Operations.bookingList.Count; i++)
            {
                bookings[i] = $"{Operations.bookingList[i].BookingID},{Operations.bookingList[i].UserID},{Operations.bookingList[i].TotalPrice},{Operations.bookingList[i].DateOfBooking.ToString("dd/MM/yyyy hh:mm tt")},{Operations.bookingList[i].Status}";
            }
            //Write values to csv file
            File.WriteAllLines("SyncStaysData/bookingDetails.csv", bookings);

        }
        public static void ReadFromCSV()
        {
            //Read from userDetails csv file
            string[] users = File.ReadAllLines("SyncStaysData/UserDetails.csv");
            foreach (string user in users)
            {
                Operations.userList.Add(new UserRegistration(user));
            }

            //Read from RoomDetails csv file
            string[] rooms = File.ReadAllLines("SyncStaysData/RoomDetails.csv");
            foreach (string room in rooms)
            {
                Operations.roomList.Add(new RoomDetails(room));
            }

            //Read from RoomSelectionDetails csv file
            string[] selections = File.ReadAllLines("SyncStaysData/RoomSelectionDetails.csv");
            foreach (string selection in selections)
            {
                Operations.roomselectionList.Add(new RoomSelectionDetails(selection));
            }

            //Read from BookingDetails csv file
            string[] bookings = File.ReadAllLines("SyncStaysData/BookingDetails.csv");
            foreach (string booking in bookings)
            {
                Operations.bookingList.Add(new BookingDetails(booking));
            }
        }
    }
}