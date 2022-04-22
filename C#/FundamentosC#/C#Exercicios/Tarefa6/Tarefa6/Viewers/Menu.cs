using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Tarefa6.Entities;
using System.Threading;

namespace Tarefa6.Viewers
{
    internal class Menu
    {
        public static void View()
        {
            do
            {
                Console.Clear();
                try
                {
                    Process();
                    OpMessage();
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
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.InnerException);
                    Console.WriteLine(ex.Message);
                    ErrorMsg();
                }

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
          
        }


        static void AvaliandoSaltos(string nome, params double[] salto)
        {
            var atleta = new Atleta(nome, salto);
            atleta.Avaliar();

            Console.WriteLine(atleta.ToString());
        }

        static bool NomeValido(string nome)
        {
            string pattern = @"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ][A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ\s]*$";

            Match match = Regex.Match(nome, pattern);

            if (match.Success)
                return true;
            else
                return false;
        }

        static void Process()
        {
            var salto = new double[5];

            Console.WriteLine("Digite o nome do Atleta:");
            Console.WriteLine("========================");
            var nome = Console.ReadLine();

            if (NomeValido(nome))
            {
                for (var cont = 0; cont < 5; cont++)
                {
                    Console.Clear();
                    Console.WriteLine($"Digite o {cont + 1}º salto:");
                    Console.WriteLine("========================");
                    salto[cont] = double.Parse(Console.ReadLine());
                    if (salto[cont] < 0)
                        throw new ArgumentException("Error: Valor Negativo");
                    if (salto[cont] == 0)
                        throw new ArgumentException("Error: O Atleta precisa saltar");
                    if (salto[cont] > 100)
                        throw new ArgumentException("Error: O Salto precisa ser possivel");
                }
                AvaliandoSaltos(nome, salto);
            }
            else
                throw new ArgumentException("Error: Escreva um Nome valido");
        }

        static void ErrorMsg()
        {
            Console.WriteLine("Digite Novamente...");
            Thread.Sleep(1000);
            Menu.View();
        }

        static void OpMessage()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Aperte Esc para sair da Aplicação,Caso deseje repetir aperte qualquer outra tecla");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
