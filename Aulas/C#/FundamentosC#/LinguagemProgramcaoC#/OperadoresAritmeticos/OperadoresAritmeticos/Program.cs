using System;

namespace OperadoresAritmeticos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Soma => +
            //Subtração => -
            //Multiplicacao => *
            //Divisao => /

            int soma = 25 + 22;
            int subtração = 25 - 22;
            int divisao = 25 / 22; // Resultado = 4 ; Foi arredondado
            int multiplicacao = 25 * 22;

            int x = 2 + 2 * 2; // 6
            int y = 2 + (2 * 2); // 6
            int y = (2 + 2) * 2; // 8
            Console.WriteLine("Hello World!");
        }
    }
}
