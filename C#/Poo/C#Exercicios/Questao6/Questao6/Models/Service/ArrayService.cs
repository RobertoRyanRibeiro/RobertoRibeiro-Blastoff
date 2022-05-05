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
            array.ShowValues();
            WaitUntilClick();
        }

        public static void ShowInt()
        {
            ErrorArray();
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
                    throw new ArgumentException("Error - O valor não pode ser negativo");
                array.MultValues(value);
                WaitUntilClick();
            }
            catch (FormatException ex)
            {
                Console.Clear();
                Console.WriteLine("Error - Formatação Invalida");
                Thread.Sleep(1000);
                Mult();
            }
            catch (OverflowException ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                Mult();
            }
            catch (ArgumentException ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                Mult();
            }
        }

        static void ErrorArray()
        {
            Console.Clear();
            if (!array.isNotEmpty)
            {
                Console.WriteLine("O Array está vazio");
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
