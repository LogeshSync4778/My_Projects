using System;

namespace CovidVaccination;

class Program
{
    public static void Main(string[] args)
    {
        FileHandling.Create();

        //Operations.DefaultData();
        FileHandling.ReadfromCSV();
        
        Operations.MainMenu();

        FileHandling.WriteToCSV();
    }
}