using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace RotatePdf
{
    public class PdfPage
    {
        public List<string> content;
        public int Rotation { get; set; } 

        public PdfPage()
        {
            content = new List<string>();
        }

        public void RotatePage(int degrees)
        {
            Rotation = degrees;
        }

        public void AddText(string text, double x, double y)
        {
            content.Add($"BT /F1 24 Tf {x} {y} Td ({text}) Tj ET");
        }

        public string GetContent()
        {
            return string.Join("\n", content.ToArray());
        }
    }
}