using System;
using System.IO;
using System.Reflection;

namespace JS_Actions2
{
    public class PdfAttachmentAnnotation
    {
        public RectangleF Bounds { get; set; }
        public string FileName { get; set; }
        public string FileFormat { get; set; }
        public PdfPage Destination { get; set; }
        public FileStream FileStream { get; set; }
        public PdfAttachmentIcon Icon { get; set; }
        public Color Color { get; set; }

        public PdfAttachmentAnnotation(RectangleF bounds, string fileName, FileStream fileStream)
        {
            Bounds = bounds;
            FileName = fileName;
            FileStream = fileStream;
            Format(fileName);
        }
        public void Format(string filename)
        {
            string extension = Path.GetExtension(filename);
            if (extension.StartsWith("."))
            {
                FileFormat = extension.Substring(1);
            }
        }
        public string Extension(string ext)
        {
            if (ext == "jpg" || ext == "jpeg" || ext == "png")
            {
                return "Image";
            }
            else if (ext == "txt")
            {
                return "Text";
            }
            else
            {
                return "None";
            }
        }
    }
}