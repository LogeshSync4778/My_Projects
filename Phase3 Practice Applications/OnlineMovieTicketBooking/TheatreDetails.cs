using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieTicketBooking
{
    public class TheatreDetails
    {
        /// <summary>
        /// private field used to auto increment Theatre ID that uniquely identify as <see cref="TheatreID"/> Class Instance
        /// </summary>
        private static int s_theatreID = 300;

        /// <summary>
        /// public property uses s_theatreID to store Theatre ID that uniquely identify as <see cref="TheatreID"/> Class Instance
        /// </summary>
        public string TheatreID { get; }

        /// <summary>
        /// public property uses Theatre Name to store Theatre ID that uniquely identify as <see cref="TheatreName"/> Class Instance
        /// </summary>
        public string TheatreName { get; set; }

        /// <summary>
        /// public property uses Location of the theatre to store Theatre ID that uniquely identify as <see cref="TheatreLocation"/> Class Instance
        /// </summary>
        public string TheatreLocation { get; set; }

        //Constructor used to assign values to the properties
        public TheatreDetails(string theatreName, string theatreLocation)
        {
            s_theatreID++;
            TheatreID = "TID" + s_theatreID;
            TheatreName = theatreName;
            TheatreLocation = theatreLocation;
        }
    }
}