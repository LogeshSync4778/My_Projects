using System;
using System.Formats.Tar;
using System.IO;
using System.Text;

namespace JS_Actions2;
class Program
{

    public static void Main(string[] args)
    {
        PdfDocument document = new PdfDocument();

        PdfPage page = document.Pages.AddPage();
        PdfPage page2 = document.Pages.AddPage();

        PdfJavaScriptAction scriptAction = new PdfJavaScriptAction("app.alert(\"Document Opened!!!\")");
        document.AddJsActin = scriptAction;

        PdfPageAction Action = new PdfPageAction("app.alert('Second Page opened!!!')", "app.alert('Second Page closed!!!')");

        page2.AddJsActin = Action;

        document.Save("Output.pdf");
    }
}
