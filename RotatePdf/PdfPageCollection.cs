using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RotatePdf
{
    public class PdfPageCollection
{
    private PdfDocument document;

    public PdfPageCollection(PdfDocument doc)
    {
        this.document = doc;
    }

    public PdfPage Add()
    {
        PdfPage newPage = new PdfPage();
        document.AddPage(newPage);
        return newPage;
    }
}
}