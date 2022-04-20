using System;

namespace StartsWithEndsWith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Exemplo 1
            var texto = "Este texto é um teste";
            Console.WriteLine(texto.StartsWith("Este"));
            Console.WriteLine(texto.StartsWith("este"));
            Console.WriteLine(texto.StartsWith("texto"));
            Console.WriteLine(texto.StartsWith(" Este"));

            Console.WriteLine(texto.EndsWith("teste"));
            Console.WriteLine(texto.EndsWith("Teste"));
            Console.WriteLine(texto.EndsWith("xpro"));
            Console.WriteLine(texto.EndsWith(" teste"));
        }
    }
}
