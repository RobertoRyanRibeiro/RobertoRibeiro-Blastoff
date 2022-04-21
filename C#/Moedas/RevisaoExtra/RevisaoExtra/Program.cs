using System;
using System.Globalization;

namespace RevisaoExtra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            decimal valor = 10536.25m;
            string.Format("{0:C}", CultureInfo.CreateSpecificCulture("pt-BR"));
            valor.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"));
            Math.Round(valor);
            Math.Ceiling(valor);
            Math.Floor(valor);  
        }
    }
}
