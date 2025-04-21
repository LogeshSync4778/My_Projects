using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore
{
    public class BookingDetails
    {
        /// <summary>
        /// private field used to increment BookingID that uniquely identify as <see cref="BookingID"/> Class Instance
        /// </summary>
        private static int s_bookingID = 3000;

        /// <summary>
        /// public property uses s_bookingID to store Booking ID that uniquely identify as <see cref="BookingID"/> Class Instance
        /// </summary>
        /// <value>Starts from BID3001</value>
        public string BookingID { get; }

        /// <summary>
        /// public property used to store CustomerID that uniquely identify as <see cref="CustomerID"/> Class Instance
        /// </summary>
        public string CustomerID { get; set; }

        /// <summary>
        /// public property used to store Total price of the booking that uniquely identify as <see cref="TotalPrice"/> Class Instance
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

        //Constructor with parameters
        public BookingDetails(string customerID, double totalPrice, DateTime dateOfBooking, BookingStatus status)
        {
            s_bookingID++;
            BookingID = "BID" + s_bookingID;
            CustomerID = customerID;
            TotalPrice = totalPrice;
            DateOfBooking = dateOfBooking;
            Status = status;
        }

        //Constructor used to read values from csv file
        public BookingDetails(string values)
        {
            string[] value = values.Split(",");
            BookingID = value[0];
            s_bookingID = int.Parse(value[0].Remove(0, 3));
            CustomerID = value[1];
            TotalPrice = double.Parse(value[2]);
            DateOfBooking = DateTime.ParseExact(value[3], "dd/MM/yyyy", null);
            Status = Enum.Parse<BookingStatus>(value[4]);
        }
    }
}