using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace SyncStays
{
    public class RoomSelectionDetails
    {
        /// <summary>
        /// private field used to auto increment SelectionID that uniquely identify as <see cref="SelectionID"/> Class Instance
        /// </summary>
        private static int s_selectionID = 3000;

        /// <summary>
        /// public property uses s_selectionID to store Selection ID that uniquely identify ass <see cref="SelectionID"/> Class Instance
        /// </summary>
        /// <value>Starts from SID3001</value>
        public string SelectionID { get; }

        /// <summary>
        /// public property used to store Room ID tha uniquely identify as <see cref="RoomID"/> Class Instance
        /// </summary>
        public string RoomID { get; set; }

        /// <summary>
        /// public property used to store Booking ID tha uniquely identify as <see cref="BookingID"/> Class Instance
        /// </summary>
        public string BookingID { get; set; }

        /// <summary>
        /// public property used to store Start date of Staying in room that uniquely identify as <see cref="StayingDateFrom"/> Class Instance
        /// </summary>
        public DateTime StayingDateFrom { get; set; }

        /// <summary>
        /// public property used to store End date of Staying in room that uniquely identify as <see cref="StayingDateTo"/> Class Instance
        /// </summary>
        public DateTime StayingDateTo { get; set; }

        /// <summary>
        /// public property used to store Room Price that uniquely identify as <see cref="Price"/> Class Instance
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// public property used to store No of Days Staying in room that uniquely identify as <see cref="NumberOfDays"/> Class Instance
        /// </summary>
        public double NumberOfDays { get; set; }

        /// <summary>
        /// public property used to store Room status of room that uniquely identify as <see cref="Status"/> Class Instance
        /// </summary>
        public BookingStatus Status { get; set; }

        // Constructor used to assign values to properties
        public RoomSelectionDetails(string bookingID, string roomID, DateTime stayingDateFrom, DateTime stayingDateTo, double price, double numberOfDays, BookingStatus status)
        {
            s_selectionID++;
            SelectionID = "SID" + s_selectionID;
            RoomID = roomID;
            BookingID = bookingID;
            StayingDateFrom = stayingDateFrom;
            StayingDateTo = stayingDateTo;
            Price = price;
            NumberOfDays = numberOfDays;
            Status = status;
        }

        //Constructor used to get values from csv file
        public RoomSelectionDetails(string values)
        {
            string[] value = values.Split(",");
            SelectionID = value[0];
            s_selectionID = int.Parse(value[0].Remove(0, 3));
            BookingID = value[1];
            RoomID = value[2];
            StayingDateFrom = DateTime.ParseExact(value[3], "dd/MM/yyyy hh:mm tt", null);
            StayingDateTo = DateTime.ParseExact(value[4], "dd/MM/yyyy hh:mm tt", null);
            Price = double.Parse(value[5]);
            NumberOfDays = double.Parse(value[6]);
            Status = Enum.Parse<BookingStatus>(value[7]);
        }
    }
}