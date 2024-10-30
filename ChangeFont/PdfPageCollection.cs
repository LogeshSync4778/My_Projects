using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeFont
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
    }

}