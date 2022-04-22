using System;
using System.Globalization;

namespace CultureInfoAula
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            var pt = new CultureInfo("pt-PT");
            var br = new CultureInfo("pt-BR");
            var enUs = new CultureInfo("en-US");
            var de = new CultureInfo("de-DE");
            var atual = CultureInfo.CurrentCulture;

            //Console.WriteLine(DateTime.Now.ToString("D", pt));
            Console.WriteLine(DateTime.Now.ToString("D", de));
            Console.WriteLine(String.Format("{0:D}", DateTime.Now));
        }
    }
}
