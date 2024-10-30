using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JS_Actions2
{
    public class PdfDocument
    {
        public List<PdfPage> pages = new List<PdfPage>();
        public int objectCount = 1;

        public PdfPageCollection Pages { get; set; }
        public PdfJavaScriptAction AddJsActin { get; set; }
        public PdfDocument()
        {
            Pages = new PdfPageCollection(this);
        }
        public void AddPage(PdfPage page)
        {
            pages.Add(page);
        }
        public void RemovePageAt(int index)
        {
            pages.RemoveAt(index);
        }

        public void Save(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine("%PDF-1.0");

                int pageObjectStart = objectCount + 3;
                int contentObjectStart = pageObjectStart + pages.Count;

                writer.WriteLine($"{objectCount} 0 obj");
                writer.WriteLine("<<");
                writer.WriteLine("/Type /Catalog");
                writer.WriteLine($"/Pages {objectCount + 2} 0 R");
                if (AddJsActin != null)
                {
                    writer.WriteLine($"/OpenAction {objectCount + 1} 0 R");
                }
                writer.WriteLine(">>");
                writer.WriteLine("endobj");

                if (AddJsActin != null)
                {
                    writer.WriteLine($"{++objectCount} 0 obj");
                    writer.WriteLine("<< /S /JavaScript /JS (" + AddJsActin.Script + ") >>");
                    writer.WriteLine("endobj");
                }

                writer.WriteLine($"{++objectCount} 0 obj");
                writer.Write($"<< /Type /Pages /Count {pages.Count} /Kids [ ");
                if (AddJsActin != null)
                {
                    for (int i = 0; i < pages.Count; i++)
                    {
                        writer.Write($"{pageObjectStart + i + 1} 0 R ");
                    }
                }
                else
                {
                    for (int i = 0; i < pages.Count; i++)
                    {
                        writer.Write($"{pageObjectStart + i} 0 R ");
                    }
                }
                writer.WriteLine($"]\n>>");
                writer.WriteLine("endobj");

                writer.WriteLine($"{++objectCount} 0 obj");
                writer.WriteLine("<< /Font <</F1 <</Type /Font /BaseFont /Times-Roman  /Subtype /Type1 >> >> >> \nendobj");

                for (int i = 0; i < pages.Count; i++)
                {
                    writer.WriteLine($"{++objectCount} 0 obj");
                    writer.Write($"<< /Type /Page /Parent 3 0 R /MediaBox [0 0 612 792] ");
                    if (AddJsActin != null)
                    {
                        writer.Write($"/Resources 4 0 R /Contents {contentObjectStart + i + 1} 0 R ");
                    }
                    else
                    {
                        writer.Write($"/Resources 3 0 R /Contents {contentObjectStart + i} 0 R ");
                    }
                    writer.Write("/Annots [ ");
                    for (int j = 0; j < pages[i].Annotations.Count * 3; j += 3)
                    {
                        writer.Write($"{contentObjectStart + pages.Count + j} 0 R ");
                    }
                    for (int j = 0; j < pages[i].DLAnnotations.Count; j++)
                    {
                        writer.Write($"{contentObjectStart + pages.Count + j} 0 R ");
                    }
                    writer.Write("] ");
                    if (pages[i].AddJsActin != null)
                    {
                        writer.WriteLine($"/AA << /O << /S /JavaScript /JS ({pages[i].AddJsActin.Open}) >> /C << /S /JavaScript /JS ({pages[i].AddJsActin.Close}) >> >>");
                    }
                    writer.WriteLine(">>");
                    writer.WriteLine("endobj");
                }

                for (int i = 0; i < pages.Count; i++)
                {
                    string content1 = pages[i].Graphics.GetContent();
                    string content2 = pages[i].Canvas.GetContent();
                    writer.WriteLine($"{++objectCount} 0 obj");
                    writer.WriteLine("<< >>");
                    writer.WriteLine("stream");
                    writer.WriteLine("BT ET");
                    writer.Write(content1);
                    writer.Write(content2);
                    writer.WriteLine("\nendstream");
                    writer.WriteLine("endobj");
                }

                for (int i = 0; i < pages.Count; i++)
                {
                    for (int j = 0; j < pages[i].Annotations.Count; j++)
                    {
                        PdfAttachmentAnnotation annotation = pages[i].Annotations[j];

                        writer.WriteLine($"{++objectCount} 0 obj");
                        writer.WriteLine("<< /Type /Annot /Subtype /FileAttachment");
                        writer.WriteLine($"/Rect [{annotation.Bounds.X} {annotation.Bounds.Y} {annotation.Bounds.Width} {annotation.Bounds.Height}]");
                        writer.WriteLine($"/Contents (Attached File: {annotation.FileName}) /Name /{annotation.Icon} /C [{PdfGraphics.color(annotation.Color.ToString())}]");
                        writer.WriteLine($"/FS {objectCount + 1} 0 R >>\nendobj");

                        writer.WriteLine($"{++objectCount} 0 obj");
                        writer.WriteLine($"<< /Type /Filespec\n/F ({annotation.FileName})\n/EF << /F {objectCount + 1} 0 R >> >>\nendobj");

                        writer.WriteLine($"{++objectCount} 0 obj");
                        writer.WriteLine($"<< /Type /EmbeddedFile\n/Subtype /{annotation.Extension(annotation.FileFormat)} \n/Length 65432 >>\nstream\nHello World !\nendstream\nendobj");
                    }
                }

                for (int i = 0; i < pages.Count; i++)
                {
                    for (int j = 0; j < pages[i].DLAnnotations.Count; j++)
                    {
                        PdfDocumentLinkAnnotation DLAnnot = pages[i].DLAnnotations[j];
                        PdfDestination destination = DLAnnot.Destination;

                        writer.WriteLine($"{++objectCount} 0 obj");
                        writer.WriteLine("<< /Type /Annot /Subtype /Link");
                        writer.WriteLine($"/Rect [{DLAnnot.Bounds.X} {DLAnnot.Bounds.Y} {DLAnnot.Bounds.Width} {DLAnnot.Bounds.Height}]");
                        writer.WriteLine($"/Contents ({DLAnnot.Text}) /C [{PdfGraphics.color(DLAnnot.Color.ToString())}]");

                        writer.WriteLine($"/Dest [{pages.IndexOf(destination.Page) + pageObjectStart} 0 R /XYZ {destination.Location.X} {destination.Location.Y} {destination.Zoom}]\n/F {DLAnnot.FindFlag(DLAnnot.AnnotationFlags.ToString())}");
                        writer.WriteLine(">>\nendobj");
                    }
                }

                writer.WriteLine("xref");

                writer.WriteLine("trailer");
                writer.WriteLine($"<</Root 1 0 R >>");
                writer.WriteLine("startxref");
                writer.WriteLine("%%EOF");
            }

            Console.WriteLine("PDF saved successfully as " + filename);
        }
    }
}