using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieTicketBooking
{
    public class ScreeningDetails
    {
        /// <summary>
        /// public property used to store Movie ID that uniquely identify as <see cref="MovieID"/> Class Instance
        /// </summary>
        public string MovieID { get; set; }

        /// <summary>
        /// public property used to store Theatre ID that uniquely identify as <see cref="TheatreID"/> Class Instance
        /// </summary>
        public string TheatreID { get; set; }

        /// <summary>
        /// public property used to store Seats available that uniquely identify as <see cref="NoOfSeatsAvailable"/> Class Instance
        /// </summary>
        public int NoOfSeatsAvailable { get; set; }

        /// <summary>
        /// public property used to store Ticket Price that uniquely identify as <see cref="TicketPrice"/> Class Instance
        /// </summary>
        public double TicketPrice { get; set; }

        //Constructor used to assign values to properties
        public ScreeningDetails(string movieID, string theatreID, double ticketPrice, int noOfSeatsAvailable)
        {
            MovieID = movieID;
            TheatreID = theatreID;
            NoOfSeatsAvailable = noOfSeatsAvailable;
            TicketPrice = ticketPrice;
        }
    }
}