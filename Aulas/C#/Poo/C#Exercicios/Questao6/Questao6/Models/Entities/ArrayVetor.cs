using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Questao6.Viewers;

namespace Questao6.Models.Entities
{
    public class ArrayVetor
    {

        float[] array = new float[5];
        public bool isNotEmpty = false;

        public void AddValues()
        {
            Console.Clear();
            isNotEmpty = true;
            try
            {
                for (var c = 0; c < array.Length; c++)
                {
                    Console.WriteLine($"|Digite o {c + 1}º valor");
                    Console.WriteLine("==============================");
                    var value = float.Parse(Console.ReadLine());
                    if (value < 0)
                    {
                        ErrorMsg();
                        throw new ArgumentException("|O valor não pode ser negativo");
                    }
                    array[c] = value;
                }
            }
            catch (FormatException ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine("|Error de Formatação");
                Thread.Sleep(1000);
                AddValues();
            }
            catch (OverflowException ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine("|Error de Formatação");
                Thread.Sleep(1000);
                AddValues();
            }
            catch (ArgumentException ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                AddValues();
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

        public void ShowValues()
        {
            for (var c = 0; c < array.Length; c++)
            {
                Console.WriteLine($"|{c + 1}º Valor - {array[c]}");
            }
        }

        public void ShowValuesInt()
        { 
            for (var c = 0; c < array.Length; c++)
            {
                Console.WriteLine($"|{c + 1}º Valor - {(int)array[c]}");
            }
        }

        public void MultValues(float mult)
        {
            for (var c = 0; c < array.Length; c++)
            {
                array[c] *= mult;
            }
        }

    }
}
