using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncStays
{
    public class BookingDetails
    {
        /// <summary>
        /// private field used to auto increment Booking ID that uniquely idetify as <see cref="BookingID"/> Class Instance
        /// </summary>
        private static int s_bookingID = 4000;

        /// <summary>
        /// public property uses s_bookingID that uniquely identify as <see cref="BookingID"/> Class Instance
        /// </summary>
        /// <value>Starts from BID4001</value>
        public string BookingID { get; }

        /// <summary>
        /// public property used to store UserID that uniquely identify as <see cref="UserID"/> Class Instance
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// public property used to store Total price of booking that uniquely identify as <see cref="TotalPrice"/> Class Instance
        /// </summary>
        public double TotalPrice { get; set; }

        /// <summary>
        /// public property used to store Booking Date that uniquely identify as <see cref="DateOfBooking"/> Class Instance
        /// </summary>
        public DateTime DateOfBooking { get; set; }

        /// <summary>
        /// public property used to store Booking status that uniquely identify as <see cref="Status"/> Class Instance
        /// </summary>
        public BookingStatus Status { get; set; }

        //Constructor used to assign values to properties
        public BookingDetails(string userID, double totalPrice, DateTime dateOfBooking, BookingStatus status)
        {
            s_bookingID++;
            BookingID = "BID" + s_bookingID;
            UserID = userID;
            TotalPrice = totalPrice;
            DateOfBooking = dateOfBooking;
            Status = status;
        }

        //Constructor used to get values from csv file
        public BookingDetails(string values)
        {
            string[] value = values.Split(",");
            BookingID = value[0];
            s_bookingID = int.Parse(value[0].Remove(0, 3));
            UserID = value[1];
            TotalPrice = double.Parse(value[2]);
            DateOfBooking = DateTime.ParseExact(value[3], "dd/mm/yyyy HH:mm tt", null);
            Status = Enum.Parse<BookingStatus>(value[4]);
        }
    }
}

