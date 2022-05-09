using System;
using System.Threading;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Questao5.Models.Entities;
using Questao5.Viewers;

namespace Questao5.Models.Service
{
    public static class CelestialBodyService
    {

        static CelestialBody[] celestials = new CelestialBody[6];
        static bool universoPreenchido = false;
        static int cont = 0;

        static CelestialBody Entrada()
        {
            Console.Clear();

            var nomeFormat = new Regex(@"^[\da-zA-zà-ÿÀ-ÿ'][a-zA-zà-ÿÀ-ÿ\d'\s]*$");
            //=========================Nome=========================
            Console.WriteLine("|Digite o Nome do Corpo Celeste");
            Console.WriteLine("===============================");
            var nome = Console.ReadLine();
            if (!nomeFormat.IsMatch(nome))
                throw new ArgumentException("|Error - Formatação do Nome Invalido");
            //=========================Tipo=========================
            Console.WriteLine("|Digite o Tipo do Corpo Celeste A-Asteroide P-Planeta N-Nebula");
            Console.WriteLine("===============================");
            var tipoC = char.Parse(Console.ReadLine().ToUpper());
            if (tipoC == ' ')
                throw new ArgumentException("|Error - Formatação Op não pode ser vazia");
            //=========================Massa=========================
            Console.WriteLine("|Digite a Massa do Corpo Celeste");
            Console.WriteLine("===============================");
            var massa = Math.Log10(double.Parse(Console.ReadLine()));
            if (double.IsNaN(massa))
                throw new ArgumentException("|Error  - Massa não pode ser negativa");
            if (double.IsNegativeInfinity(massa))
                throw new ArgumentException("|Error  - Massa não pode ser zero");
            //=========================Tamanho=========================
            Console.WriteLine("|Digite o Diametro do Corpo Celeste");
            Console.WriteLine("===============================");
            var tamanho = Math.Log10(double.Parse(Console.ReadLine()));
            if (double.IsNaN(tamanho))
                throw new ArgumentException("|Error  - Tamanho não pode ser negativa");
            if (double.IsNegativeInfinity(tamanho))
                throw new ArgumentException("|Error  - Tamanho não pode ser zero");


            universoPreenchido = true;
            
            //Retorno
            switch (tipoC)
            {
                case 'A':
                    return new Asteroid(massa, tamanho, nome);
                case 'P':
                    return new Planet(massa, tamanho, nome);
                case 'N':
                    return new Nebula(massa, tamanho, nome);
                default:
                    return new Asteroid(massa, tamanho, nome);
            }
        }

        public static void InserirCelestial()
        {
            try
            {
                if (cont < 6)
                {
                    celestials[cont] = Entrada();
                    cont++;
                }
                else
                    ErrorListaMsg("O Universo foi preenchido...");
                MenuOp.View();
            }
            catch (FormatException ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine("|Error - Formatação Invalida");
                Console.WriteLine("Digite qualquer tecla para continuar...");
                Console.ReadKey();
                InserirCelestial();
            }
            catch (OverflowException ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine(ex.Message);
                Console.WriteLine("Digite qualquer tecla para continuar...");
                Console.ReadKey();
                InserirCelestial();
            }
            catch (ArgumentException ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine(ex.Message);
                Console.WriteLine("Digite qualquer tecla para continuar...");
                Console.ReadKey();
                InserirCelestial();
            }
            catch (Exception ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine(ex.Message);
                Console.WriteLine("Digite qualquer tecla para continuar...");
                Console.ReadKey();
                InserirCelestial();
            }
        }

        public static void ExibirCelestial()
        {
            Console.Clear();
            if (!universoPreenchido)
                ErrorListaMsg("O Universo está Vazio");

            for (var cont = 0; cont < celestials.Length; cont++)
            {
                if (celestials[cont] != null)
                    Console.WriteLine(celestials[cont].ExibirDados());
                Console.WriteLine("");
            }

            Console.ReadKey();
            MenuOp.View();
        }

        static void ErrorMsg()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("|Error - Na Entrada de Dados");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("===========================");
        }

        static void ErrorListaMsg(string msg)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"-{msg}-");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("===================================================");
            Thread.Sleep(1000);
            MenuOp.View();

        }

    }
}
