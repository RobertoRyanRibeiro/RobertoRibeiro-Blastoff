using System;

namespace Indices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var texto = "Este texto é um teste";
            Console.WriteLine(texto.IndexOf("é"));
            Console.WriteLine(texto.IndexOf("um"));
            Console.WriteLine(texto.LastIndexOf("s"));
        }
    }
}
