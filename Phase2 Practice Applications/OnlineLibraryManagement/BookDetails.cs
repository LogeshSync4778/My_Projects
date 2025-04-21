using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibraryManagement
{
    public class BookDetails
    {
        /// <summary>
        /// Private field Auto incremented that Uniquely identify <see cref="BookID" /> Class Instance
        /// </summary> 
        private static int s_bookID = 1000;

        /// <summary>
        /// Public property uses _bookID field that Uniquely identify <see cref="BookID" /> Class Instance 
        /// </summary>
        public string BookID { get; }

        /// <summary>
        /// public property used to store Name of the book that uniquely identify <see cref="BookName" /> Class Instance
        /// </summary>
        public string BookName { get; set; }

        /// <summary>
        /// public property used to store Name of the Book's Author that uniquely identify <see cref="AuthorName" /> Class Instance
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// public property used to store Count of the book that uniquely identify <see cref="BookCount" /> Class Instance
        /// </summary>
        public int BookCount { get; set; }

        public BookDetails(string bookname, string authorname, int bookcount)
        {
            s_bookID++;
            BookID = "BID" + s_bookID;
            BookName = bookname;
            AuthorName = authorname;
            BookCount = bookcount;
        }
    }
}