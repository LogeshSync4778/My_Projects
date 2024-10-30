using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeFont
{
    public class PdfPage
    {
        public PdfCanvas Canvas { get; set; }
        public int Rotation { get; set; }

        public PdfPage()
        {
            Canvas = new PdfCanvas();
        }

        public void RotatePage(int degrees)
        {
            Rotation = degrees;
        }
    }
}