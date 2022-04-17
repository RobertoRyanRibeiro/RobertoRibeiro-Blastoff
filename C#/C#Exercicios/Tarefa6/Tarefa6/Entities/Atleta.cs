using System;
using System.Collections.Generic;
using System.Text;

namespace Tarefa6.Entities
{
    public class Atleta
    {
        public string Nome { get; private set; }
        public double[] Saltos { get; private set; }
        public double MelhorSalto { get; private set; }
        public double PiorSalto { get; private set; }
        public double MediaSaltos { get; private set; }

        public Atleta(string nome,params double[] saltos)
        {
            Nome = nome;
            Saltos = saltos;    
        }

        public void Avaliar()
        {
            MelhorSalto = 0;
            PiorSalto = double.MaxValue;

            for(var cont = 0; cont < Saltos.Length; cont++)
            {
                if (Saltos[cont] > MelhorSalto)
                    MelhorSalto = Saltos[cont];
                if(Saltos[cont] < PiorSalto)
                    PiorSalto = Saltos[cont];
            }

            //Armazenando os Saltos Restantes
            var restoSaltos = new double[3];
            //Contador de Restos    
            var contResSal = 0;

            for (var cont = 0; cont < Saltos.Length; cont++)
            {
                if (Saltos[cont] != MelhorSalto && Saltos[cont] != PiorSalto)
                {
                    restoSaltos[contResSal] = Saltos[cont];
                    contResSal++;
                }
            }

            MediaSaltos = (restoSaltos[0] + restoSaltos[1] + restoSaltos[2]) / 3;
        }

        public override string ToString()
        {
            Console.Clear();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("==========================================================");
            sb.AppendLine("");

            sb.AppendLine($"Atleta: {Nome}");
            sb.AppendLine("");
            sb.AppendLine($"Primeiro Salto: {Saltos[0].ToString("F1")} m");
            sb.AppendLine($"Segundo Salto: {Saltos[1].ToString("F1")} m");
            sb.AppendLine($"Terceiro Salto: {Saltos[2].ToString("F1")} m");
            sb.AppendLine($"Quarto Salto: {Saltos[3].ToString("F1")} m");
            sb.AppendLine($"Quinto Salto: {Saltos[4].ToString("F1")} m");
            sb.AppendLine("==========================================================");
            sb.AppendLine("");

            sb.AppendLine($"Melhor Salto: {MelhorSalto.ToString("F1")} m");
            sb.AppendLine($"Pior Salto: {PiorSalto.ToString("F1")} m");
            sb.AppendLine($"Média dos demais saltos: {MediaSaltos.ToString("F1")} m");
            sb.AppendLine("==========================================================");
            sb.AppendLine("");

            sb.AppendLine("Resultado Final");
            sb.AppendLine($"{Nome}: {MediaSaltos.ToString("F1")} m");

            return sb.ToString();
        }
    }
}
