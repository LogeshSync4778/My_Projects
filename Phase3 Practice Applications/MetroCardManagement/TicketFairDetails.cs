using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class TicketFairDetails
    {
        /// <summary>
        /// private field used to auto Increment TicketID that uniquely Identify as <see cref="TicketID"/> Class Instance
        /// </summary>
        private static int s_ticketID = 3000;

        /// <summary>
        /// public property uses s_ticketID that uniquely Identify as <see cref="TicketID"/> Class Instance
        /// </summary>
        /// <value>Starts from MR3001 </value>
        public string TicketID { get; }

        /// <summary>
        /// public property used to store From location of user that uniquely Identify as <see cref="FromLocation"/> Class Instance
        /// </summary>
        public Location FromLocation { get; set; }

        /// <summary>
        /// public property used to store To Location of user that uniquely Identify as <see cref="ToLocation"/> Class Instance
        /// </summary>
        public Location ToLocation { get; set; }

        /// <summary>
        /// public property used to store Ticket price that uniquely Identify as <see cref="TicketPrice"/> Class Instance
        /// </summary>
        public double TicketPrice { get; set; }

        //Constructor with parameters
        public TicketFairDetails(Location fromLocation, Location toLocation, double ticketPrice)
        {
            s_ticketID++;
            TicketID = "MR" + s_ticketID;
            FromLocation = fromLocation;
            ToLocation = toLocation;
            TicketPrice = ticketPrice;
        }

        //Constructor used to read values from the CSV file
        public TicketFairDetails(string values)
        {
            string[] value = values.Split(",");
            TicketID = value[0];
            s_ticketID = int.Parse(value[0].Remove(0, 2));
            FromLocation = Enum.Parse<Location>(value[1], true); ;
            ToLocation = Enum.Parse<Location>(value[2], true); ;
            TicketPrice = double.Parse(value[3]);
        }
    }
}