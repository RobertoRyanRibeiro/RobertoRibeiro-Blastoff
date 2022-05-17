using System;
using System.Collections.Generic;
using System.Text;
using Questão1.Entities.Forms;
using Questão1.Entities.Materials;
using Questão1.NotificationContext;

namespace Questão1.Entities
{
    public class FoundationArea : Rectangle
    {
        public Floor Floor { get; private set; }
        public Baseboard Baseboard { get; private set; }
        public double QuantOfFloor { get; private set; }
        public double QuantOfBaseboard { get; private set; }

        public FoundationArea(double width, double length, Floor floor, Baseboard baseboard) : base(width, length)
        {
            if(width == 0 || length == 0)
                IsInvalid = true;  


            Floor = floor;
            Baseboard = baseboard;

            if (floor == null)
                Floor = new Floor(60, 60);
            if (baseboard == null)
                Baseboard = new Baseboard(10);

        }

        public void CalculateTheMaterials()
        {
            var areaTotalFloors = Math.Ceiling(Area() / (Floor.Length * Floor.Width));
            areaTotalFloors += areaTotalFloors * 0.1;
            QuantOfFloor = areaTotalFloors;


            var areaTotalBaseBoards = 2 * ((Width * Baseboard.Length) + (Length * Baseboard.Length));
            areaTotalBaseBoards += areaTotalBaseBoards * 0.15;
            QuantOfBaseboard = areaTotalBaseBoards;
        }

        public override string ToString()
        {
            if (IsInvalid)
            {
                AddNotification(new Notification("Formatação", "Valor Invalido"));
                PrintNotification();
                return "";
            }

            Console.Clear();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("|Local Informações");
            sb.AppendLine(PrintSides());
            sb.AppendLine($"|Area do Local e: {Area()} m²");
            sb.AppendLine($"|Perimetro do Local e: {Perimeter()} m");
            sb.AppendLine("=====================================================");
            sb.AppendLine("|Materiais");
            sb.AppendLine("|Piso:");
            sb.AppendLine(Floor.PrintSides());
            sb.AppendLine("|Rodape:");
            sb.AppendLine(Baseboard.PrintSides());
            sb.AppendLine("=====================================================");
            sb.AppendLine("|Quantidade necessaria já ajustada de material ");
            sb.AppendLine($"|Quantidade de Pisos: {QuantOfFloor:F2} m²");
            sb.AppendLine($"|Quantidade de Rodapes: {QuantOfBaseboard:F2} m²");

            return sb.ToString();
        }
    }
}
