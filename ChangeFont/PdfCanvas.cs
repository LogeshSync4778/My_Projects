using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeFont
{
    public class PdfCanvas
    {
        private List<string> content;

        public PdfCanvas()
        {
            content = new List<string>();
        }

        public void DrawText(string text, PdfFont font, int x, int y)
        {
            content.Add($"{color(font.color.ToString().ToLower())}\nBT /{fontname(font.Name.ToString())} {font.Size} Tf {x} {y} Td ({text}) Tj ET");
        }
        public string color(string colorname)
        {
            switch (colorname)
            {
                case "Red":
                    {
                        return "1 0 0 rg";
                    }

                case "Green":
                    {
                        return "0 1 0 rg";
                    }

                case "Blue":
                    {
                        return "0 0 1 rg";
                    }
                case "Yellow":
                    {
                        return "1 1 0 rg";
                    }

                case "Cyan":
                    {
                        return "0 1 1 rg";
                    }

                case "Magenta":
                    {
                        return "1 0 1 rg";
                    }
                case "Orange":
                    {
                        return "1 0.5 0 rg";
                    }
                case "Purple":
                    {
                        return "0.5 0 0.5 rg";
                    }

                case "Pink":
                    {
                        return "1 0.75 0.8 rg";
                    }

                case "Brown":
                    {
                        return "0.6 0.3 0.1 rg";
                    }
                default:
                    {
                        return "0 0 0";
                    }
            }
        }
        public string fontname(string font)
        {
            if (font.Equals("Helvetica"))
            {
                return "F2";
            }

            else if (font.Equals("Courier"))
            {
                return "F3";
            }

            else
            {
                return "F1";
            }
        }
        public string GetContent()
        {
            return string.Join("\n", content.ToArray());
        }
    }

}