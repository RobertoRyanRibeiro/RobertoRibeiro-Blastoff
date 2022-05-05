using System;
using System.Collections.Generic;
using System.Text;
using Questao5.Models.Enum;

namespace Questao5.Models.Entities
{
    public class CelestialBody
    {
        private double mass;
        private double height;

        public CelestialBody(double mass, double height, string name)
        {
            Mass = mass;
            Height = height;
            Name = name;
        }  

        protected ETypeCelestialBody Type { get; set; }
        public string Name { get; private set; }

        public double Mass
        {
            get { return mass; }
            set { mass = value; }
        }

        public double Height
        {
            get { return height; }
            set { height = value; }
        }


        public string ExibirDados()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"|Nome - {Name}");
            sb.AppendLine($"|Tipo - {Type}");
            sb.AppendLine("====================================");
            sb.AppendLine($"|Massa - {Mass:E}");
            sb.AppendLine($"|Tamanho - {Height:E}");

            return sb.ToString();
        }

    }
}
