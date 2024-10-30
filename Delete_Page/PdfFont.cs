using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delete_Page
{
    public class PdfFont
    {
        public Font Name { get; set; }
        public int Size { get; set; }
        public Color color { get; set; }

        public PdfFont(Font name, int size, Color colorname)
        {
            Name = name;
            Size = size;
            color = colorname;
        }
    }
}