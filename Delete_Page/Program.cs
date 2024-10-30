using System;
using System.Formats.Tar;

namespace Delete_Page;
class Program
{
    public static void Main(string[] args)
    {
        PdfDocument document = new PdfDocument();
        for (int i = 0; i < 5; i++)
        {
            PdfPage page = document.Pages.AddPage();
        }

        PdfFont font = new PdfFont(Font.Courier, 20, Color.Blue);
        document.pages[0].Canvas.DrawText("First page", font, 100, 600);
        document.pages[1].Canvas.DrawText("Second page", font, 100, 600);
        document.pages[2].Canvas.DrawText("Third page", font, 100, 600);
        document.pages[3].Canvas.DrawText("Fourth page", font, 100, 600);
        document.pages[4].Canvas.DrawText("Fifth page", font, 100, 600);

        document.Pages.RemoveAt(2);
        document.Pages.RemoveAt(0);
        document.Pages.RemoveAt(0);

        document.Save("Output.pdf");
    }
}