using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieTicketBooking
{
    public class BookingDetails
    {
        /// <summary>
        /// private field used to auto increment BookingID that uniquely identify as <see cref="BookingID"/> Class Instance
        /// </summary>
        private static int s_bookingID = 7000;

        /// <summary>
        /// public property uses s_bookingID to store BookingID that uniquely identify as <see cref="BookingID"/>  Class Instance
        /// </summary>
        public string BookingID { get; }

        /// <summary>
        /// public property used to store User ID that uniquely identify as <see cref="UserID"/> Class Instance
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// public property used to store Movie ID that uniquely identify as <see cref="MovieID"/> Class Instance
        /// </summary>
        public string MovieID { get; set; }

        /// <summary>
        /// public property used to store Theatre ID that uniquely identify as <see cref="TheatreID"/> Class Instance
        /// </summary>
        public string TheatreID { get; set; }

        /// <summary>
        /// public property used to store Seat count that uniquely identify as <see cref="SeatCount"/> Class Instance
        /// </summary>
        public int SeatCount { get; set; }

        /// <summary>
        /// public property used to store Total Amount of booking that uniquely identify as <see cref="TotalAmount"/> Class Instance
        /// </summary>
        public double TotalAmount { get; set; }

        /// <summary>
        /// public property used to store Booking status that uniquely identify as <see cref="Status"/> Class Instance
        /// </summary>
        public BookingStatus Status { get; set; }

        //Constructor used to assign values to the properties
        public BookingDetails(string userID, string movieID, string theatreID,int seatCount, double totalAmount, BookingStatus status)
        {
            s_bookingID++;
            BookingID = "BID" + s_bookingID;
            UserID = userID;
            MovieID = movieID;
            TheatreID = theatreID;
            SeatCount = seatCount;
            TotalAmount = totalAmount;
            Status = status;
        }
    }
}