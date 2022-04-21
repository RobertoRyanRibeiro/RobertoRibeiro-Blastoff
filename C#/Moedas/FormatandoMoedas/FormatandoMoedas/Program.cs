using System;
using System.Globalization;

namespace FormatandoMoedas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            decimal valor = 10.25m;
            Console.WriteLine(valor.ToString("G",CultureInfo.CreateSpecificCulture("pt-BR")));
            Console.WriteLine(valor.ToString("C",CultureInfo.CreateSpecificCulture("pt-BR")));
            Console.WriteLine(valor.ToString("C",CultureInfo.CreateSpecificCulture("es-ES")));
            Console.WriteLine(valor.ToString("C",CultureInfo.CreateSpecificCulture("en-US")));

            Console.WriteLine(valor.ToString("E04",CultureInfo.CreateSpecificCulture("pt-BR")));
            Console.WriteLine(valor.ToString("N",CultureInfo.CreateSpecificCulture("pt-BR")));
            Console.WriteLine(valor.ToString("P",CultureInfo.CreateSpecificCulture("pt-BR")));
        }
    }
}
