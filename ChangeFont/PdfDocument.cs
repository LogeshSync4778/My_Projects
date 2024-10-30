using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeFont
{
    public class PdfDocument
    {
        public List<PdfPage> pages = new List<PdfPage>();
        public int objectCount = 1;

        public PdfPageCollection Pages { get; set; }

        public PdfDocument()
        {
            Pages = new PdfPageCollection(this);
        }

        public void AddPage(PdfPage page)
        {
            pages.Add(page);
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
                writer.WriteLine($"/Pages {objectCount+1} 0 R");
                writer.WriteLine(">>");
                writer.WriteLine("endobj");

                writer.WriteLine($"{++objectCount} 0 obj");
                writer.Write($"<< /Type /Pages /Count {pages.Count} /Kids [ ");
                for (int i = 0; i < pages.Count; i++)
                {
                    writer.Write($"{pageObjectStart + i} 0 R ");
                }
                writer.WriteLine($"]\n>>");
                writer.WriteLine("endobj");

                writer.WriteLine($"{++objectCount} 0 obj");
                writer.WriteLine("<< /Font <</F1 <</Type /Font /BaseFont /Times-Roman  /Subtype /Type1 >> >> >> \nendobj");

                for (int i = 0; i < pages.Count; i++)
                {
                    writer.WriteLine($"{++objectCount} 0 obj");
                    writer.Write($"<< /Type /Page /Parent 2 0 R /MediaBox [0 0 612 792] /Resources 3 0 R /Contents {contentObjectStart + i} 0 R ");
                    writer.WriteLine(">>");
                    writer.WriteLine("endobj");
                }

                for (int i = 0; i < pages.Count; i++)
                {
                    string content = pages[i].Canvas.GetContent();
                    writer.WriteLine($"{++objectCount} 0 obj");
                    writer.WriteLine("<< >>");
                    writer.WriteLine("stream");
                    writer.WriteLine("BT ET");
                    writer.Write(content);
                    writer.WriteLine("\nendstream");
                    writer.WriteLine("endobj");
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