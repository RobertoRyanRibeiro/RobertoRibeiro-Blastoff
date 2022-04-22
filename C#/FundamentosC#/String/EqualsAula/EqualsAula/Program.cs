using System;

namespace EqualsAula
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var texto = "Este texto é um teste";
            Console.WriteLine(texto.Equals("Este texto é um teste")); 
            Console.WriteLine(texto.Equals("este texto é um teste")); 
            Console.WriteLine(texto.Equals("este texto é um teste",StringComparison.OrdinalIgnoreCase)); 
            Console.WriteLine(texto.Equals(" Este texto é um teste")); 
            
            //var teste = 33;
            //teste.Equals(35);
        }
    }
}
