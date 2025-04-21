using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourse
{
    public class CourseDetails
    {
        private static int s_courseID = 2000;
        public string CourseID { get; }
        public string CourseName { get; set; }
        public string TrainerName { get; set; }
        public int Duration { get; set; }
        public int Seats { get; set; }

        public CourseDetails(string courseName, string trainerName, int duration, int seats)
        {
            s_courseID++;
            CourseID = "CS" + s_courseID;
            CourseName = courseName;
            TrainerName = trainerName;
            Duration = duration;
            Seats = seats;
        }
    }
}