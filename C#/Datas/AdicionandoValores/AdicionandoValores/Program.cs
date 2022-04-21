using System;

namespace AdicionandoValores
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            var data = DateTime.Now;

            //var dia = data.Day + 1; Evitar,porque o dia pode n existir

            Console.WriteLine(data.AddDays(1));          
            Console.WriteLine(data.AddMonths(1));
            Console.WriteLine(data.AddYears(1));
            Console.WriteLine(data.AddHours(12));
            Console.WriteLine(data.AddMinutes(12));
            Console.WriteLine(data.AddSeconds(60));
        }
    }
}
