using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class TravelDetails
    {
        /// <summary>
        /// private field used to auto Increment TravelID that uniquely Identify as <see cref="TravelID"/> Class Instance
        /// </summary>
        private static int s_travelID = 2000;

        /// <summary>
        /// public property uses TravelID that uniquely Identify as <see cref="TravelID"/> Class Instance
        /// </summary>
        /// <value>Starts from TID2001</value>
        public string TravelID { get; }

        /// <summary>
        /// public property used to store card number that uniquely Identify as <see cref="CardNumber"/> Class Instance
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// public property used to store From Location of travel that uniquely Identify as <see cref="FromLocation"/> Class Instance
        /// </summary>
        public Location FromLocation { get; set; }

        /// <summary>
        /// public property used to store TO Location of travel that uniquely Identify as <see cref="ToLocation"/> Class Instance
        /// </summary>
        public Location ToLocation { get; set; }

        /// <summary>
        /// public property used to store Travel Date that uniquely Identify as <see cref="TravelDate"/> Class Instance
        /// </summary>
        public DateTime TravelDate { get; set; }

        /// <summary>
        /// public property used to store Travel Cost that uniquely identify as <see cref="TravelCost"/> Class Instance
        /// </summary>
        public double TravelCost { get; set; }

        //Default Constructore
        public TravelDetails() { }

        //Constructor with parameters
        public TravelDetails(string cardNumber, Location fromLocation, Location toLocation, DateTime travelDate, double travelCost)
        {
            s_travelID++;
            TravelID = "TID" + s_travelID;
            CardNumber = cardNumber;
            FromLocation = fromLocation;
            ToLocation = toLocation;
            TravelDate = travelDate;
            TravelCost = travelCost;
        }

        //Constructor used to read values in CSV file
        public TravelDetails(string values)
        {
            string[] value = values.Split(",");
            TravelID = value[0];
            s_travelID = int.Parse(value[0].Remove(0, 3));
            CardNumber = value[1];
            FromLocation = Enum.Parse<Location>(value[2], true);
            ToLocation = Enum.Parse<Location>(value[3], true); ;
            TravelDate = DateTime.ParseExact(value[4], "dd/MM/yyyy", null);
            TravelCost = double.Parse(value[5]);
        }
    }
}