using System;

namespace PadroesFormatacao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            var data = DateTime.Now;

            //t = tempo
            //d = data
            //T = Tempo total
            //D = Data total
            //f = D e T
            //r = padrao de todo programa
            //R = -//-
            //s = -//-
            //u = -//-
            var formatada = string.Format("0:t",data);
            Console.WriteLine(formatada);
        }
    }
}
