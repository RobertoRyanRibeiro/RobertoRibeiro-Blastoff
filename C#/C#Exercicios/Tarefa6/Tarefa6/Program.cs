using System;
using System.Threading;
using Tarefa6.Entities;


namespace Tarefa6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            var salto = new double[5];

            Console.Clear();
            try
            {
                Console.WriteLine("Digite o nome do Atleta:");
                Console.WriteLine("========================");
                var nome = Console.ReadLine();

                if(String.IsNullOrEmpty(nome) || String.IsNullOrWhiteSpace(nome))
                    System.Environment.Exit(0); 

                for(var cont = 0; cont < 5; cont++)
                {
                    Console.Clear();
                    Console.WriteLine($"Digite o {cont+1}º salto:");
                    Console.WriteLine("========================");
                    salto[cont] = double.Parse(Console.ReadLine());
                }
                var atleta = new Atleta(nome,salto);
                atleta.Avaliar();
                Console.WriteLine(atleta.ToString());
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
