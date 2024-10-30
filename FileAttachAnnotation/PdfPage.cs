using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileAttachAnnotation
{
    public class PdfPage
    {
        public PdfCanvas Canvas { get; set; }
        public PdfGraphics Graphics { get; set; }
        public List<PdfAttachmentAnnotation> Annotations { get; set; }
        public int Rotation { get; set; }

        public PdfPage()
        {
            Graphics = new PdfGraphics();
            Canvas = new PdfCanvas();
            Annotations = new List<PdfAttachmentAnnotation>();
        }

        public void RotatePage(int degrees)
        {
            Rotation = degrees;
        }
    }
}