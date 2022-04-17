using System;
using System.Threading;
using Tarefa5.Entities;

namespace Tarefa5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Digite a quantidade de horas");
                Console.WriteLine("===========================");
                var hrTrab = double.Parse(Console.ReadLine());
                Console.WriteLine("Digite o valor da Hora");
                Console.WriteLine("======================");
                var valHr = double.Parse(Console.ReadLine());

                FolhaPagamento folPag = new FolhaPagamento(hrTrab, valHr);
                folPag.CalcularSalLiquido();
                Console.WriteLine(folPag.ToString());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                ErrorMsg();
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                ErrorMsg();
            }
        }
        static void ErrorMsg()
        {
            Console.WriteLine("Digite Novamente...");
            Thread.Sleep(1000);
            Menu();
        }

    }
}
