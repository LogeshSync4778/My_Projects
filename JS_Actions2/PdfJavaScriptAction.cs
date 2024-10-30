using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JS_Actions2
{
    public class PdfJavaScriptAction
    {
        public string Script { get; set; }

        public PdfJavaScriptAction(string text)
        {
            Script = text;
        }
    }
}