using System;
using System.Runtime.CompilerServices;

namespace OnlineCourse;

class Program
{
    public static void Main(string[] args)
    {
        //Step1 --> Call DefaultDetails
        Operations.DefaultDetails();
        
        //Step2 --> Call MainMenu
        Operations.MainMenu();
    }
}