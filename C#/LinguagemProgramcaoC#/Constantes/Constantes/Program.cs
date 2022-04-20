using System;

namespace Constantes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            const int IDADE_MINIMA; -> Correto inicia com zero 
            const int IDADE_MINIMA = 25; -> Correto inicia  com 25
            const var IDADE_MINIMA = 25; -> Errado
            const var IDADE_MINIMA; -> Errado
            Não da para usar var com const
            */

            Console.WriteLine("Hello World!");
        }
    }
}
