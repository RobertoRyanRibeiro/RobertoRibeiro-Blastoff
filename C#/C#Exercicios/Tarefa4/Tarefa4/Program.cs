﻿using System;
using System.Threading;
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
            try
            {
                Console.WriteLine("Digite a Taxa:");
                Console.WriteLine("====================");
                var taxa = double.Parse(Console.ReadLine());
                Console.WriteLine("Digite o Kg do peixe");
                Console.WriteLine("====================");
                var kg = double.Parse(Console.ReadLine());
                var notaFiscal = new NotaFiscal(taxa, kg);
                notaFiscal.CalcularExcesso();

                Console.Clear();
                Console.WriteLine(notaFiscal.ToString());
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
