using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace MetroCardManagement
{
    public class FileHandling
    {
        public static void Create()
        {

            //Check the directory is exists
            if (!Directory.Exists("MetroCardManagementData"))
            {
                //Create new folder
                Directory.CreateDirectory("MetroCardManagementData");
                System.Console.WriteLine("Successfully created Metro Card Management Data Folder");
            }

            //Check the userDetails file is exists
            if (!File.Exists("MetroCardManagementData/UserDetails.csv"))
            {
                //Create new csv file
                File.Create("MetroCardManagementData/UserDetails.csv").Close();
                System.Console.WriteLine("Successfully created User Details File");
            }

            //Check the TicketfairDetails file is exists
            if (!File.Exists("MetroCardManagementData/TicketFairDetails.csv"))
            {
                //Create new csv file
                File.Create("MetroCardManagementData/TicketFairDetails.csv").Close();
                System.Console.WriteLine("Successfully created TicketFair Details File");
            }

            //Check the TravelDetails file is exists
            if (!File.Exists("MetroCardManagementData/TravelDetails.csv"))
            {
                //Create new csv file
                File.Create("MetroCardManagementData/TravelDetails.csv").Close();
                System.Console.WriteLine("Successfully created Travel Details File");
            }
        }
        public static void WriteToCSV()
        {
            //Write values into userDetails csv file
            string[] users = new string[Operations.userList.Count];
            for (int i = 0; i < Operations.userList.Count; i++)
            {
                users[i] = $"{Operations.userList[i].CardNumber},{Operations.userList[i].Name},{Operations.userList[i].Phone},{Operations.userList[i].Balance}";
            }
            //Write the values in array to csv file
            File.WriteAllLines("MetroCardManagementData/UserDetails.csv", users);

            //Write values into TicketfairDetails csv file
            string[] tickets = new string[Operations.ticketfairList.Count];
            for (int i = 0; i < Operations.ticketfairList.Count; i++)
            {
                tickets[i] = $"{Operations.ticketfairList[i].TicketID},{Operations.ticketfairList[i].FromLocation},{Operations.ticketfairList[i].ToLocation},{Operations.ticketfairList[i].TicketPrice}";
            }
            //Write the values in array to csv file
            File.WriteAllLines("MetroCardManagementData/TicketFairDetails.csv", tickets);

            //Write values into TravelDetails csv file
            string[] travels = new string[Operations.travelList.Count];
            for (int i = 0; i < Operations.travelList.Count; i++)
            {
                travels[i] = $"{Operations.travelList[i].TravelID},{Operations.travelList[i].CardNumber},{Operations.travelList[i].FromLocation},{Operations.travelList[i].ToLocation},{Operations.travelList[i].TravelDate.ToString("dd/MM/yyyy")},{Operations.travelList[i].TravelCost}";
            }
            //Write the values in array to csv file
            File.WriteAllLines("MetroCardManagementData/TravelDetails.csv", travels);
        }

        public static void ReadFromCSV()
        {
            //Copy values in csv file to an array
            string[] users = File.ReadAllLines("MetroCardManagementData/UserDetails.csv");
            foreach (string user in users)
            {
                //Create and add object into list
                Operations.userList.Add(new UserDetails(user));
            }

            //Copy values in csv file to an array
            string[] tickets = File.ReadAllLines("MetroCardManagementData/TicketFairDetails.csv");
            foreach (string ticket in tickets)
            {
                //Create and add object into list
                Operations.ticketfairList.Add(new TicketFairDetails(ticket));
            }

            //Copy values in csv file to an array
            string[] travels = File.ReadAllLines("MetroCardManagementData/TravelDetails.csv");
            foreach (string travel in travels)
            {
                //Create and add object into list
                Operations.travelList.Add(new TravelDetails(travel));
            }
        }
    }
}