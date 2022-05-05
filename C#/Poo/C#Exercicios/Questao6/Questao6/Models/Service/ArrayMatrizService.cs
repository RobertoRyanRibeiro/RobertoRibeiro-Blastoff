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
            array.ShowValues();
            WaitUntilClick();
        }

        public static void Sum()
        {
            ErrorArray();
            Console.WriteLine(array.Sum());
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
            Console.WriteLine(array.Media());
            WaitUntilClick();

        }

        static void ErrorArray()
        {
            Console.Clear();
            if (!array.isNotEmpty)
            {
                Console.WriteLine("O Array está vazio");
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
