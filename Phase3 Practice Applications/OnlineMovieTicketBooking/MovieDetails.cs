using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieTicketBooking
{
    public class MovieDetails
    {
        /// <summary>
        /// private field used to auto increment MovieID that uniquely identify as <see cref="MovieID"/> Class Instance
        /// </summary>
        private static int s_movieID = 500;

        /// <summary>
        /// public property uses s_movieID to store Movie ID that uniquely identify as <see cref="MovieID"/> Class Instance
        /// </summary>
        /// <value>Starts from MID501</value>
        public string MovieID { get; }

        /// <summary>
        /// public property used to store Movie name that uniquely identify as <see cref="MovieName"/> Class Instance
        /// </summary>
        public string MovieName { get; set; }

        /// <summary>
        /// public property used to store Language of the movie that uniquely identify as <see cref="Language"/> Class Instance
        /// </summary>
        /// <value></value>
        public string Language { get; set; }

        //Constructor used to assign values to the properties
        public MovieDetails(string movieName, string language)
        {
            s_movieID++;
            MovieID = "MID" + s_movieID;
            MovieName = movieName;
            Language = language;
        }
    }
}