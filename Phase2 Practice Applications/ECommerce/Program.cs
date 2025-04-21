using System;

namespace ECommerce;

class Program
{
    public static void Main(string[] args)
    {
        //Step1 --> Call DefaultData
        Operations.DefaultData();
        //Step2 --> Call MainMenu
        Operations.MainMenu();
    }
}