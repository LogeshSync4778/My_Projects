using System;

namespace DrawShapes;
class Program
{
    static void Main(string[] args)
    {
        PdfDocument document = new PdfDocument();
        PdfPage page = document.Pages.AddPage();

        PdfGraphics Graphics = page.Graphics;

        PdfPen pen1 = new PdfPen(Color.Red, 3, Paint.S);
        PointF point1 = new PointF(100, 600);
        PointF point2 = new PointF(400, 600);
        page.Graphics.DrawLine(pen1, point1, point2);

        PdfPen pen2 = new PdfPen(Color.Brown, 5, Paint.f);
        RectangleF points = new RectangleF(100, 450, 300, 100);
        page.Graphics.DrawRectangle(pen2, points);

        PdfPen pen3 = new PdfPen(Color.Green, 3, Paint.f);
        PointF X = new PointF(100, 700);
        PointF Y = new PointF(400, 700);
        PointF A = new PointF(100, 800);
        PointF B = new PointF(400, 800);
        PointF C = new PointF(400, 600);
        PointF D = new PointF(100, 600);
        EllipseF values = new EllipseF(X, Y, A, B, C, D);
        page.Graphics.DrawEllipse(pen3, values);

        document.Save("Output.pdf");
    }
}