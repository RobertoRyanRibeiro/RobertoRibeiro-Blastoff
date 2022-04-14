using System;

namespace Calculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
         {
            Console.Clear();

            Console.WriteLine("Menu - Seja Bem Vindo");
            Console.WriteLine("1-Soma");
            Console.WriteLine("2-Subtração");
            Console.WriteLine("3-Divisão");
            Console.WriteLine("4-Multiplicação");
            Console.WriteLine("0-Sair");
            int op = int.Parse(Console.ReadLine());
                
            switch (op)
            {
                case 1: Soma(); break;
                case 2: Subt(); break;
                case 3: Div();  break;
                case 4: Mult(); break;
                case 0: return;
                default: Menu();break;
            }
        }

        static void Soma()
        { 
            Console.Clear();

            //Input
            Console.WriteLine("Primeiro Valor");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Segundo Valor");
            float v2 = float.Parse(Console.ReadLine());

            float result = v1 + v2;

            Console.WriteLine($"A soma de {v1} + {v2} = {result}");
            Console.ReadKey();
            Menu(); 
        }

        static void Subt()
        {
            Console.Clear();

            //Input
            Console.WriteLine("Primeiro Valor");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Segundo Valor");
            float v2 = float.Parse(Console.ReadLine());

            float result = v1 - v2;

            Console.WriteLine($"A subtação de {v1} - {v2} = {result}");
            Console.ReadKey();
            Menu();
        }
        static void Mult()
        {
            Console.Clear();

            //Input
            Console.WriteLine("Primeiro Valor");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Segundo Valor");
            float v2 = float.Parse(Console.ReadLine());

            float result = v1 * v2;

            Console.WriteLine($"A multiplicação de {v1} * {v2} = {result}");
            Console.ReadKey();
            Menu();
        }

        static void Div()
        {
            Console.Clear();

            //Input
            Console.WriteLine("Primeiro Valor");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Segundo Valor");
            float v2 = float.Parse(Console.ReadLine());

            float result = v1 / v2;

            Console.WriteLine($"A divisão de {v1} / {v2} = {result}");
            Console.ReadKey();
            Menu();
        }
    }
}
