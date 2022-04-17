using System;
using System.Threading;

namespace Tarefa3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Attributes
            uint[] lados = new uint[3];

            do
            {
                //Input
                try
                {
                    Console.Clear();
                    Console.WriteLine("<Bem Vindo>");
                    for (int cont = 0; cont < 3; cont++)
                    {
                        Console.WriteLine($"Digite o {cont + 1}º valor");
                        Console.WriteLine($"=========================");
                        lados[cont] = uint.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.InnerException);
                    Console.WriteLine(ex.Message);
                    ErrorMessage(args);
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.InnerException);
                    Console.WriteLine(ex.Message);
                    ErrorMessage(args);
                }

                VerificandoTriangulo(lados[0], lados[1], lados[2]);

                OpMessage();

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        static void VerificandoTriangulo(params uint[] lados)
        {
            //Auxiliar
            uint aux;

            Console.Clear();
            //Organizando do maior para o menor
            for (int current = 0; current < lados.Length; current++)
            {
                for (int prox = current + 1; prox <= lados.Length - 1; prox++)
                {
                    if (lados[prox] > lados[current])
                    {
                        aux = lados[current];
                        lados[current] = lados[prox];
                        lados[prox] = aux;
                    }
                }
            }

            //Imprimindo os lados em ordem
            Console.WriteLine("Ordem de Maior para menor");
            Console.WriteLine("=========================");
            Console.Write("| ");
            for (int cont = 0; cont < 3; cont++)
            {
                Console.Write($"{lados[cont]} | ");
            }

            //Verificando se é um triangulo
            Console.WriteLine(" ");
            if (lados[0] < lados[1] + lados[2])
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("+As retas formam um triangulo+");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-As retas não formam um triangulo-");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        static void ErrorMessage(string[] args)
        {
            Console.WriteLine("Digite os dados novamente...");
            Thread.Sleep(1000);
            Main(args);
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
