using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using Questao3.Models.Entities.Enum;

namespace Questao3.Models.Entities
{
    public abstract class Ingresso
    {
        protected Ingresso()
        {
            Valor = 5;
        }


        public double Valor { get; protected set; }

        public ETipoIngresso Tipo { get; protected set; } = ETipoIngresso.Normal;

        public virtual string ImprimirIngresso()
        {
            StringBuilder sb = new StringBuilder();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"|Ingresso - {Tipo}");
            Console.WriteLine("====================");
            Console.ForegroundColor = ConsoleColor.White;
            sb.AppendLine(ExibirValor());

            return sb.ToString();   
        }

        protected virtual string ExibirValor()
        {
            return $"|Valor - {Valor.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"))}";
        }
    }
}
