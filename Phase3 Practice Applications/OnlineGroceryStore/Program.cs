using System;
namespace OnlineGroceryStore;
class Program
{
    public static void Main(string[] args)
    {
        FileHandling.Create();        
        // Operations.DefaultDetails();
        FileHandling.ReadFromCSV();
        Operations.MainMenu();
        FileHandling.WriteToCSV();
    }
}