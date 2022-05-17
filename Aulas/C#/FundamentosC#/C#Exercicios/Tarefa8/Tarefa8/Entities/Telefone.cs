using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Tarefa8.Entities
{
    public class Telefone
    {
        private string telFixF;
        private string telFix;

        public string Numero { get; private set; }

        public Telefone(string numero)
        {
            Numero = numero;
        }

        public void AnalisarNum()
        {
            Console.Clear();
            var aux = Numero;

            //Verificando se tem -
            if (aux.Contains("-"))
            {
                aux = Regex.Replace(Numero, @"\-", "");
            }

            //Verificando se o numero tem menos de 7 digitos
            if (aux.Length == 7)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Telefone possui 7 dígitos. Vou acrescentar o digito três na frente.");
                aux += "3";
                Numero += "3";
                Console.ForegroundColor = ConsoleColor.White;
            }

            //Formatação
            telFixF= int.Parse(aux).ToString(@"0000-0000");
            telFix = int.Parse(aux).ToString(@"00000000");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Valida e corrige número de telefone");
            sb.AppendLine($"Telefone: {Numero}");
            sb.AppendLine("===================================");
            sb.AppendLine($"Telefone Corrigido com formatação {telFixF}");
            sb.AppendLine($"Telefone Corrigido sem formatação {telFix}");

            return sb.ToString();
        }

    }
}
