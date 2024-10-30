using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrawShapes
{
    public class PdfPage
    {
        public PdfCanvas Canvas { get; set; }
        public PdfGraphics Graphics { get; set; }
        public int Rotation { get; set; }

        public PdfPage()
        {
            Graphics = new PdfGraphics();
            Canvas = new PdfCanvas();
        }

        public void RotatePage(int degrees)
        {
            Rotation = degrees;
        }
    }
}