using System;
using System.Collections.Generic;
using System.Text;
using Questão1.Entities.Forms;

namespace Questão1.Entities.Materials
{
    public sealed class Floor
    {
        public double Width { get; private set; }
        public double Length { get; private set; }

        public Floor(double width, double length)
        {
            Width = width / 100;
            Length = length / 100;
        }
        public string PrintSides()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"|Comprimento:{Width:F2} cm");
            sb.AppendLine($"|Largura:{Length:F2} cm");
            return sb.ToString();
        }

    }
}
