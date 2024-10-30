using System;
using System.Formats.Tar;
using System.IO;

namespace FileAttachAnnotation;
class Program
{

    public static void Main(string[] args)
    {
        PdfDocument document = new PdfDocument();


        PdfPage page = document.Pages.AddPage();
        PdfPage page2 = document.Pages.AddPage();

        RectangleF attachmentRectangle = new RectangleF(100, 570, 120, 600);
        FileStream Stream = new FileStream("Wallpaper.jpg", FileMode.Open, FileAccess.Read);
        PdfAttachmentAnnotation attachmentAnnotation = new PdfAttachmentAnnotation(attachmentRectangle, "Wallpaper.jpg", Stream);
        attachmentAnnotation.Icon = PdfAttachmentIcon.Paperclip;
        attachmentAnnotation.Color = Color.Blue;

        RectangleF attachmentRectangle2 = new RectangleF(400, 570, 420, 600);
        FileStream Stream2 = new FileStream("Sample.txt", FileMode.Open, FileAccess.Read);
        PdfAttachmentAnnotation attachmentAnnotation2 = new PdfAttachmentAnnotation(attachmentRectangle2, "Sample.txt", Stream2);
        attachmentAnnotation2.Icon = PdfAttachmentIcon.Graph;
        attachmentAnnotation2.Color = Color.Green;

        RectangleF attachmentRectangle3 = new RectangleF(550, 570, 580, 590);
        PdfAttachmentAnnotation attachmentAnnotation3 = new PdfAttachmentAnnotation(attachmentRectangle3, "Sample.txt", Stream2);
        attachmentAnnotation3.Icon = PdfAttachmentIcon.Tag;
        attachmentAnnotation3.Color = Color.Yellow;

        page.Annotations.Add(attachmentAnnotation);
        page.Annotations.Add(attachmentAnnotation2);
        page.Annotations.Add(attachmentAnnotation3);

        document.Save("Output.pdf");
    }
}
