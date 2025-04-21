using System;

namespace CollegeAdmission;

class Program
{
    public static void Main(string[] args)
    {
        //Step1 --> Call DefaultData
        Operations.DefaultData();
        
        //Step2 --> Call Mainmenu
        Operations.MainMenu();
    }
}