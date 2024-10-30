using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JS_Actions2
{
    public class PdfPage
    {
        public PdfCanvas Canvas { get; set; }
        public PdfGraphics Graphics { get; set; }
        public PdfPageAction AddJsActin { get; set; }
        public List<PdfAttachmentAnnotation> Annotations { get; set; }
        public List<PdfDocumentLinkAnnotation> DLAnnotations { get; set; }
        
        public int Rotation { get; set; }
        public PdfPage()
        {
            Graphics = new PdfGraphics();
            Canvas = new PdfCanvas();
            Annotations = new List<PdfAttachmentAnnotation>();
            DLAnnotations = new List<PdfDocumentLinkAnnotation>();
        }

        public void RotatePage(int degrees)
        {
            Rotation = degrees;
        }
    }
}