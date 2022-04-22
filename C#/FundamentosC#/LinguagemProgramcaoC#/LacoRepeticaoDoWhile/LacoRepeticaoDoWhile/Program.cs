using System;

namespace LacoRepeticaoDoWhile
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var valor = 0;

            //do
            //{
            //    Console.WriteLine("Teste");
            //    valor++;
            //} while (valor < 5);    
            
            do
            {
                Console.WriteLine("Teste");
                valor++;
            } while (valor <= 5);    
            
            Console.WriteLine("Hello World!");
        }
    }
}
