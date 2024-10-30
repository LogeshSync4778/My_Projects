using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrawShapes
{
    public class PointF
    {
        public int X { get; set; }
        public int Y { get; set; }

        public PointF(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}