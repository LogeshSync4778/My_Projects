using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JS_Actions2
{
    public class PdfPageAction
    {
        public string Open { get; set; }
        public string Close { get; set; }

        public PdfPageAction()
        {
            Open = " ";
            Close = " ";
        }
        public PdfPageAction(string open, string close)
        {
            Open = open;
            Close = close;
        }
    }
}