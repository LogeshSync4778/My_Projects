using System;

namespace FontColor;
class Program
{
    static void Main(string[] args)
    {
        PdfDocument document = new PdfDocument();

        PdfPage page = document.Pages.AddPage();

        PdfCanvas canvas = page.Canvas;

        PdfFont font = new PdfFont();
        font.Size = 20;
        font.color = Color.Red;
        canvas.DrawText("Hello World", font, 100, 700);

        PdfFont font2 = new PdfFont();
        font2.Size = 20;
        font2.color = Color.Orange;
        canvas.DrawText("Pdf World", font2, 100, 650);

        document.Save("Output.pdf");
    }
}