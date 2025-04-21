using System;
namespace SyncStays;
class Program
{
    public static void Main(string[] args)
    {
        FileHandling.Create();
        FileHandling.ReadFromCSV();
        // Operations.DefaultDetails();   
        Operations.MainMenu();
        FileHandling.WriteToCSV();
    }
}

