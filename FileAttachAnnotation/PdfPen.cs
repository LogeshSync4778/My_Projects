using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileAttachAnnotation
{
    public class PdfPen
    {
        public Color color { get; set; }
        public int Width { get; set; }
        public Paint Draw { get; set; }

        public PdfPen(Color colorname, int width, Paint draw)
        {
            color = colorname;
            Width = width;
            Draw = draw;
        }
    }
}