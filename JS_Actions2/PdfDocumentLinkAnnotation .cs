using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JS_Actions2
{
    public class PdfDocumentLinkAnnotation
    {
        public PdfAnnotationFlags AnnotationFlags { get; set; }
        public string Text { get; set; }
        public Color Color { get; set; }
        public PdfDestination Destination = new PdfDestination();
        public RectangleF Bounds { get; set; }

        public int Zoom { get; set; }
        public PdfAttachmentIcon Icon { get; set; }

        public PdfDocumentLinkAnnotation(RectangleF bounds)
        {
            Bounds = bounds;
        }

        public int FindFlag(string flagName)
        {
            switch (flagName)
            {
                case "Invisible":
                    {
                        return 1;
                    }
                case "Hidden":
                    {
                        return 2;
                    }
                case "Print":
                    {
                        return 4;
                    }
                case "NoZoom":
                    {
                        return 8;
                    }
                case "NoRotate":
                    {
                        return 16;
                    }
                case "NoView":
                    {
                        return 32;
                    }
                case "ReadOnly":
                    {
                        return 64;
                    }
                case "Locked":
                    {
                        return 128;
                    }
                case "ToggleNoView":
                    {
                        return 256;
                    }
                case "LockedContents":
                    {
                        return 512;
                    }
                default:
                    {
                        return 0;
                    }
            }
        }
    }
}