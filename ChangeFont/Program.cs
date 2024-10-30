using System;

namespace ChangeFont;
class Program
{
    static void Main(string[] args)
    {
        PdfDocument document = new PdfDocument();

        PdfPage page = document.Pages.AddPage();

        PdfCanvas canvas = page.Canvas;

        PdfFont font1 = new PdfFont(Font.Courier, 20, Color.Brown);
        canvas.DrawText("Text with Courier font", font1, 100, 700);

        PdfFont font2 = new PdfFont(Font.Helvetica, 25, Color.Purple);
        canvas.DrawText("Text with Helvetica font", font2, 100, 600);

        document.Save("Output.pdf");
    }
}