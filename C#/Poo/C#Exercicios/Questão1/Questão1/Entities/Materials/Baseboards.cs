using System;
using System.Collections.Generic;
using System.Text;
using Questão1.Entities.Forms;

namespace Questão1.Entities.Materials
{
    public sealed class Baseboard 
    {
        public double Width { get; private set; }
        public double Length { get; private set; }
        public Baseboard(double height)
        {
            Width = 0;
            Length = height / 100;
        }
        public string PrintSides()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"|Altura:{Length:F2} cm");
            return sb.ToString();
        }
    }
}
