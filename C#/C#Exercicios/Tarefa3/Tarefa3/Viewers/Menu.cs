using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Globalization;
using Tarefa3.Entities;

namespace Tarefa3.Viewers
{
    public struct Menu
    {

        public static void View()
        {
            //Attributes
            double[] lados = new double[3];

            do
            {
                Console.Clear();
                Console.WriteLine("<Bem Vindo>");
                //Input
                try
                {
                    for (var cont = 0; cont < 3; cont++)
                    {
                        Console.WriteLine($"Digite o {cont + 1}º valor");
                        Console.WriteLine($"=========================");
                        lados[cont] = double.Parse(Console.ReadLine(), CultureInfo.CreateSpecificCulture("pt-BR"));
                        if (lados[cont] < 0)
                            throw new ArgumentException("Valor Negativo...");
                        Console.Clear();
                    }
                    Verificar(lados);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.InnerException);
                    Console.WriteLine(ex.Message);
                    ErrorMessage();
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.InnerException);
                    Console.WriteLine(ex.Message);
                    ErrorMessage();
                }    
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.InnerException);
                    Console.WriteLine(ex.Message);
                    ErrorMessage();
                }
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }


        public static void Verificar(params double[] lados)
        {

            var tri = new Triangulo(lados);
            tri.OrganizandoLados();
            tri.Analisar();
            Console.WriteLine(tri.ToString());
            OpMessage();
        }

        static void ErrorMessage()
        {
            Console.WriteLine("Digite os dados novamente...");
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

