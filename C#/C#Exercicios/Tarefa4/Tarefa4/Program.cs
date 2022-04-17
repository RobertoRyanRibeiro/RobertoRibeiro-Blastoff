using System;
using Tarefa4.Entities;

namespace Tarefa4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Digite a Taxa:");
            Console.WriteLine("====================");
            var taxa = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Kg do peixe");
            Console.WriteLine("====================");
            var kg = double.Parse(Console.ReadLine());

            NotaFiscal notaFiscal = new NotaFiscal(taxa, kg);
            notaFiscal.CalcularExcesso();

            Console.Clear();
            Console.WriteLine(notaFiscal.ToString()); 
        }
    }
}
