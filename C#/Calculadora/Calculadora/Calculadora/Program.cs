using System;

namespace Calculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            
            Console.WriteLine("Primeiro Valor");
            float v1 = float.Parse(Console.ReadLine());
            
            Console.WriteLine("Segundo Valor");
            float v2 = float.Parse(Console.ReadLine());


            float soma = v1+v2;

            Console.WriteLine($"A soma de {v1} + {v2} = {soma}");
        }
    }
}
