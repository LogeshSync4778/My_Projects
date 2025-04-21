using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibraryManagement
{
    public class BorrowDetails
    {
        /// <summary>
        /// Private field Auto incremented that Uniquely identify <see cref="BorrowID" /> Class Instance
        /// </summary> 
        private static int s_borrowID = 2000;

        /// <summary>
        /// Public property uses _borrowID field that Uniquely identify <see cref="BorrowID" /> Class Instance 
        /// </summary>
        public string BorrowID { get; }

        /// <summary>
        /// public property used to store BookID that uniquely identify <see cref="BookID" /> Class Instance
        /// </summary>
        public string BookID { get; set; }

        /// <summary>
        /// public property used to store UserID that uniquely identify <see cref="UserID" /> Class Instance
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// public property used to store BorrowDate that uniquely identify <see cref="BorrowDate" /> Class Instance
        /// </summary>
        public DateTime BorrowDate { get; set; }

        /// <summary>
        /// public property used to store Count of the book that uniquely identify <see cref="BookCount" /> Class Instance
        /// </summary>
        public int BookCount { get; set; }

        /// <summary>
        /// public property used to store Status of the book that uniquely identify <see cref="Status" /> Class Instance
        /// </summary>
        public BookStatus Status { get; set; }

        /// <summary>
        /// public property used to store Fineamount for the late return of the book that uniquely identify <see cref="FineAmount" /> Class Instance
        /// </summary>
        public double FineAmount { get; set; }

        public BorrowDetails(string bookID, string userID, DateTime borrowDate, int bookCount, BookStatus status, double fineAmount)
        {
            s_borrowID++;
            BorrowID = "LB" + s_borrowID;
            BookID = bookID;
            UserID = userID;
            BorrowDate = borrowDate;
            BookCount = bookCount;
            Status = status;
            FineAmount = fineAmount;
        }
    }
}