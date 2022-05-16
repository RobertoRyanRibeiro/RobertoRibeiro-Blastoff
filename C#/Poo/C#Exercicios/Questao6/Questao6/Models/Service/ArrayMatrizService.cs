using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using Questao6.Models.Entities;
using Questao6.Viewers;

namespace Questao6.Models.Service
{
    public static class ArrayMatrizService
    {

        static ArrayMatriz array = new ArrayMatriz();

        public static void Add()
        {
            array.AddValues();
            MenuMatriz.View();
        }

        public static void Show()
        {
            ErrorArray();
            Console.WriteLine("==== Valores ====");
            array.ShowValues();
            WaitUntilClick();
        }

        public static void Sum()
        {
            ErrorArray();
            Console.WriteLine("==== Soma ====");
            Console.WriteLine(array.Sum().ToString("F2"));
            WaitUntilClick();
        }

        public static void MajorAndMinor()
        {
            ErrorArray();
            array.MajorAndMinor();
            WaitUntilClick();
        }

        public static void Media()
        {
            ErrorArray();
            Console.Clear();
            Console.WriteLine("==== Media ====");
            Console.WriteLine(array.Media().ToString("F2"));
            WaitUntilClick();

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
                MenuMatriz.View();
            }
        }

        static void WaitUntilClick()
        {
            Console.WriteLine("Digite qualquer tecla para continuar...");
            Console.ReadKey();
            MenuMatriz.View();
        }
    }
}
