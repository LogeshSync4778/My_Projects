using System;
using System.IO;
using System.Collections.Generic;

namespace RotatePdf;
class Program
{
    public static void Main(string[] args)
    {
        PdfDocument document = new PdfDocument();

        PdfPage page1 = document.Pages.Add();
        page1.AddText("This is a Page with 0 Degree Rotation", 100, 600);
        page1.RotatePage(0);

        PdfPage page2 = document.Pages.Add();
        page2.RotatePage(90);
        page2.AddText("This is a Page with 90 Degree Rotation", 100, 600);

        PdfPage page3 = document.Pages.Add();
        page3.RotatePage(180);
        page3.AddText("This is a Page with 180 Degree Rotation", 100, 600);

        PdfPage page4 = document.Pages.Add();
        page4.RotatePage(270);
        page4.AddText("This is a Page with 270 Degree Rotation", 100, 600);

        document.Save("Output.pdf");
    }
}




