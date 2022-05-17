using System;
using System.Text;

namespace StringBuilderAula
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var texto = "Este texto é um teste";
            //var texto2 = texto;
            //texto += " aqui"; => Não fica legal quando tem muito texto
            var sb = new StringBuilder();
            sb.Append("Este texto é um teste");
            sb.Append("é um teste");
            sb.Append("Este texto");
            sb.Append("Este um teste");

            Console.WriteLine(sb);
            Console.WriteLine(sb.ToString());
        }
    }
}
