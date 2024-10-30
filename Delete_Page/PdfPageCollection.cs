using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delete_Page
{
    public class PdfPageCollection
    {
        private PdfDocument document;

        public PdfPageCollection(PdfDocument doc)
        {
            this.document = doc;
        }

        public PdfPage AddPage()
        {
            PdfPage newPage = new PdfPage();
            document.AddPage(newPage);
            return newPage;
        }
        public void RemoveAt(int index)
        {
            document.RemovePageAt(index);
        }
    }
}