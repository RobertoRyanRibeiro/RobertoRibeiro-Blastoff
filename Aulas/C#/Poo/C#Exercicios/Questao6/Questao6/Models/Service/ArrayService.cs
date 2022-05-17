using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using Questao6.Models.Entities;
using Questao6.Viewers;

namespace Questao6.Models.Service
{
    public static class ArrayService
    {

        static ArrayVetor array = new ArrayVetor();

        public static void Add()
        {
            array.AddValues();
            MenuArray.View();
        }

        public static void Show()
        {
            ErrorArray();
            Console.WriteLine("==== Valores ====");
            array.ShowValues();
            WaitUntilClick();
        }

        public static void ShowInt()
        {
            ErrorArray();
            Console.WriteLine("==== Valores em Inteiros ====");
            array.ShowValuesInt();
            WaitUntilClick();
        }

        public static void Mult()
        {
            ErrorArray();
            Console.Clear();
            try
            {
                Console.WriteLine("|Digite o Valor");
                var value = float.Parse(Console.ReadLine());
                if (value < 0)
                {
                    ErrorMsg();
                    throw new ArgumentException("Error - O valor não pode ser negativo");
                }
                array.MultValues(value);
                WaitUntilClick();
            }
            catch (FormatException ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine("Error - Formatação Invalida");
                Thread.Sleep(1000);
                Mult();
            }
            catch (OverflowException ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                Mult();
            }
            catch (ArgumentException ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                Mult();
            }
        }

        static void ErrorMsg()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("|Error - Na Entrada de Dados");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("===========================");
        }

        static void ErrorArray()
        {
            Console.Clear();
            if (!array.isNotEmpty)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("|O Array está vazio");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("===========================");
                Thread.Sleep(1000);
                MenuArray.View();
            }
        }

        static void WaitUntilClick()
        {
            Console.WriteLine("Digite qualquer tecla para continuar...");
            Console.ReadKey();
            MenuArray.View();
        }
    }
}
