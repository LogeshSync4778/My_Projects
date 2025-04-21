using System;
using Hospital_Management;

namespace HospitalMangement;

class Program
{
    public static void Main(string[] args)
    {
        //Step 1 -->Call DefaultDetails
        Operations.DefaultDetails();
        //Step 2 -->Call MainMenu
        Operations.MainMenu();
    }
}