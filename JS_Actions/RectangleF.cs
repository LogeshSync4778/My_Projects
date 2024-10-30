using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JS_Actions
{
    public class RectangleF
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public RectangleF(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
}