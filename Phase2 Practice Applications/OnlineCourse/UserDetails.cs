using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourse
{
    public class UserDetails
    {
        private static int s_registrationID = 1000;
        public string RegistrationID { get; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public int MyProperty { get; set; }
        public GenderDetails Gender { get; set; }
        public string Qualification { get; set; }
        public long MobileNumber { get; set; }
        public string MailID { get; set; }

        public UserDetails(string username, int age, GenderDetails gender, string qualification, long mobileNumber, string mailID)
        {
            s_registrationID++;
            RegistrationID = "SYNC" + s_registrationID;
            UserName = username;
            Age = age;
            Gender = gender;
            Qualification = qualification;
            MobileNumber = mobileNumber;
            MailID = mailID;
        }
    }
}