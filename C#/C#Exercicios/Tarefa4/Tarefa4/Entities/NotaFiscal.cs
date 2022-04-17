using System;
using System.Collections.Generic;
using System.Text;

namespace Tarefa4.Entities
{
    public class NotaFiscal
    {
        public double Taxa { get; set; }
        public double Multa { get; set; }
        public double KgExcesso {get; set; }
        public double Kg {get; set; }

        public NotaFiscal(double taxa,double kg)
        {
            Taxa = taxa;
            Multa = 0;
            KgExcesso = 0;
            Kg = kg;
        }

        public void CalcularExcesso()
        {
            if (Kg > 50)
            {
                KgExcesso = Kg - 50;
                Multa = KgExcesso * Taxa;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if(KgExcesso > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-Acima do limite de peso-");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("+Tudo Ok+");
                Console.ForegroundColor = ConsoleColor.White;
            }


            sb.AppendLine("<NOTA FISCAL>");
            sb.AppendLine($"|Taxa: {Taxa.ToString("C")}");
            sb.AppendLine($"|Multa: {Multa.ToString("C")}");
            sb.AppendLine($"|KgExcesso: {KgExcesso} Kg");
            sb.AppendLine($"|Kg: {Kg} Kg");

            return sb.ToString();
        } 
    }
}
