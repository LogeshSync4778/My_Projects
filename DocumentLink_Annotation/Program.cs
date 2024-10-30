using System;
using System.Formats.Tar;
using System.IO;

namespace DocumentLink_Annotation;
class Program
{

    public static void Main(string[] args)
    {
        PdfDocument document = new PdfDocument();

        PdfPage page = document.Pages.AddPage();

        PdfPage page2 = document.Pages.AddPage();

        RectangleF docLinkAnnotationRectangle = new RectangleF(100, 600, 150, 650);

        PdfDocumentLinkAnnotation documentLinkAnnotation = new PdfDocumentLinkAnnotation(docLinkAnnotationRectangle);
        documentLinkAnnotation.AnnotationFlags = PdfAnnotationFlags.NoRotate;
        documentLinkAnnotation.Text = "Document link annotation";
        documentLinkAnnotation.Color = Color.Blue;

        documentLinkAnnotation.Destination = new PdfDestination(page2);
        documentLinkAnnotation.Destination.Location = new PointF(10, 0);
        documentLinkAnnotation.Destination.Zoom = 5;

        page.DLAnnotations.Add(documentLinkAnnotation);

        document.Save("Output.pdf");
    }
}
