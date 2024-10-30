using System.Drawing;

namespace FileAttachmentAnnotation
{
    public class EllipseF
    {
        public PointF X { get; set; }
        public PointF Y { get; set; }
        public PointF A { get; set; }
        public PointF B { get; set; }
        public PointF C { get; set; }
        public PointF D { get; set; }

        public EllipseF(PointF x, PointF y, PointF a, PointF b, PointF c, PointF d)
        {
            X = x;
            Y = y;
            A = a;
            B = b;
            C = c;
            D = d;
        }
    }
}