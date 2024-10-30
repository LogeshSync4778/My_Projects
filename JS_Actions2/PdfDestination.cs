using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JS_Actions2
{
    public class PdfDestination
    {
        public PdfPage Page { get; set; }
        public PointF Location { get; set; }
        public float Zoom { get; set; }

        public PdfDestination() { }
        public PdfDestination(PdfPage page)
        {
            Page = page;
            Location = new PointF(0, 0);
            Zoom = 1.0f;
        }
    }
}