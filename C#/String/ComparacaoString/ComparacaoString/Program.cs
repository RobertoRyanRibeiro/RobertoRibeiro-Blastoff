using System;

namespace ComparacaoString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var texto = "Testando";
            Console.WriteLine(texto.CompareTo("Testando"));
            Console.WriteLine(texto.CompareTo("testando"));

            texto = "Esse texto é um teste";
            Console.WriteLine(texto.Contains("teste"));
            Console.WriteLine(texto.Contains("Teste"));
            Console.WriteLine(texto.Contains("Teste",StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(texto.Contains(null)); //Error
        }
    }
}
