using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncStays
{
    public class RoomDetails
    {
        /// <summary>
        /// private field used to auto increment Room ID that uniquely identify as <see cref="RoomID"/> Class Instance
        /// </summary>
        private static int s_roomID = 2000;

        /// <summary>
        /// public property uses s_roomID to store RoomID that uniquely identify as <see cref="RoomID"/> Class Instance
        /// </summary>
        /// <value>Starts from RID2001</value>
        public string RoomID { get; }

        /// <summary>
        /// public property used to store Room Type that uniquely identify as <see cref="RoomType"/> Class Instance
        /// </summary>
        public RoomStatus RoomType { get; set; }

        /// <summary>
        /// public property used to store Bed Count that uniquely identify as <see cref="NumberOfBeds"/> Class Instance
        /// </summary>
        public int NumberOfBeds { get; set; }

        /// <summary>
        /// public property used to Room price per day that uniquely identify as <see cref="PricePerDay"/> Class Instance
        /// </summary>
        public double PricePerDay { get; set; }

        //Constructor used to assign values to properties
        public RoomDetails(RoomStatus roomType, int numberOfBeds, double pricePerDay)
        {
            s_roomID++;
            RoomID = "RID" + s_roomID;
            RoomType = roomType;
            NumberOfBeds = numberOfBeds;
            PricePerDay = pricePerDay;
        }

        //Constructor used to get values from csv file
        public RoomDetails(string values)
        {
            string[] value = values.Split(",");
            RoomID = value[0];
            s_roomID = int.Parse(value[0].Remove(0, 3));
            RoomType = Enum.Parse<RoomStatus>(value[1]);
            NumberOfBeds = int.Parse(value[2]);
            PricePerDay = double.Parse(value[3]);
        }
    }
}

