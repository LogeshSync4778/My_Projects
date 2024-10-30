using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JS_Actions
{
    public class PdfGraphics
    {
        private List<string> content;

        public PdfGraphics()
        {
            content = new List<string>();
        }

        public void DrawLine(PdfPen pen, PointF x, PointF y)
        {
            content.Add($"{color(pen.color.ToString())} {ColType(pen.Draw.ToString())}\n{pen.Width} w {x.X} {x.Y} m {y.X} {y.Y} l {pen.Draw}");
        }
        public void DrawRectangle(PdfPen pen, RectangleF rect)
        {
            content.Add($"{color(pen.color.ToString())} {ColType(pen.Draw.ToString())}\n{pen.Width} w {rect.X} {rect.Y} {rect.Width} {rect.Height} re {pen.Draw}");
        }
        public string GetContent()
        {
            return string.Join("\n", content.ToArray());
        }
        public static string color(string colorname)
        {
            switch (colorname)
            {
                case "Red":
                    {
                        return "1 0 0";
                    }

                case "Green":
                    {
                        return "0 1 0";
                    }

                case "Blue":
                    {
                        return "0 0 1";
                    }
                case "Yellow":
                    {
                        return "1 1 0";
                    }

                case "Cyan":
                    {
                        return "0 1 1";
                    }

                case "Magenta":
                    {
                        return "1 0 1";
                    }
                case "Orange":
                    {
                        return "1 0.5 0";
                    }
                case "Purple":
                    {
                        return "0.5 0 0.5";
                    }

                case "Pink":
                    {
                        return "1 0.75 0.8";
                    }

                case "Brown":
                    {
                        return "0.6 0.3 0.1";
                    }
                default:
                    {
                        return "0 0 0";
                    }
            }
        }
        public static string ColType(string type)
        {
            if (type == "S")
            {
                return "RG";
            }
            else
            {
                return "rg";
            }
        }
    }
}