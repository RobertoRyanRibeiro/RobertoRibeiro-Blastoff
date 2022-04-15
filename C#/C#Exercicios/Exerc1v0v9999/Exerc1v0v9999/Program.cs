using System;
using Exerc1v0v9999.Entities;
using System.Globalization; 

namespace Exerc1v0v9999
{
    internal class Program
    {
        static void Main(string[] args)
        {

            uint value;
            Numero num;
            Console.WriteLine("Digite um Valor entre 0 - 9999:");
            try
            {

                value = ushort.Parse(Console.ReadLine());
                num = new Numero(value);
                Console.WriteLine(num.ToString());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
