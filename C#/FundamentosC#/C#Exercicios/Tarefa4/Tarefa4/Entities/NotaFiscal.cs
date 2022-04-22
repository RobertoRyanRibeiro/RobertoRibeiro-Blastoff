using System;
using System.Collections.Generic;
using System.Text;

namespace Tarefa4.Entities
{
    public class NotaFiscal
    {
        public double Taxa { get;private set; }
        public double Multa { get; private set; }
        public double KgExcesso {get; private set; }
        public double Kg {get; private set; }

        public NotaFiscal(double taxa,double kg)
        {
            //Zero
            if (taxa == 0 && kg == 0)
                throw new ArgumentException("Os Dados não podem ser igual a zero");
            if (taxa == 0)
                throw new ArgumentException("Taxa não pode ser igual a zero");
            if (kg == 0)
                throw new ArgumentException("Kg não pode ser igual a zero");
            //Negativo
            if (taxa < 0 && kg < 0)
                throw new ArgumentException("Os Dados não podem ser negativo");
            if (taxa < 0)
                throw new ArgumentException("Taxa não pode ser negativa");
            if (kg < 0)
                throw new ArgumentException("Kg não pode ser negativo");


            Taxa = taxa;
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
