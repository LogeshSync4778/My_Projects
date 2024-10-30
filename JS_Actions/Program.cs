using System;
using System.Formats.Tar;
using System.IO;
using System.Text;

namespace JS_Actions;
class Program
{

    public static void Main(string[] args)
    {
        PdfDocument document = new PdfDocument();

        PdfPage page = document.Pages.AddPage();

        PdfJavaScriptAction scriptAction = new PdfJavaScriptAction("app.alert(\"Hello World!!!\")");
        document.AddJsActin = scriptAction;

        PdfFont font = new PdfFont(Font.Courier, 20, Color.Purple);
        page.Canvas.DrawText("Hello Pdf World !", font, 100, 600);

        document.Save("Output.pdf");
    }
}
