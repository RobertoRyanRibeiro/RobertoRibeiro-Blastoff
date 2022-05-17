using System;
using System.Threading;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Questao4.Models.Entities;
using Questao4.Viewers;

namespace Questao4.Models.Service
{
    public static class LivroService
    {

        static Livro EntradaDados()
        {
            Regex isbnRegex = new Regex(@"^\d{3}\-\d{2}\-\d{5}\-\d{2}\-\d{1}$");
            Regex tituloRegex = new Regex(@"^[a-zA-zà-ÿÀ-ÿ'][a-zA-zà-ÿÀ-ÿ'\s]*$");
            Match match;

            Console.Clear();
            Console.WriteLine("|Insira o Titulo");
            Console.WriteLine("=====================");
            var titulo = Console.ReadLine();
            match = tituloRegex.Match(titulo);
            if (!match.Success)
                throw new ArgumentException("|Error - Formatação do Titulo está Errado");

            Console.WriteLine("|Insira a quantidade de paginas");
            Console.WriteLine("=====================");
            var quantPag = int.Parse(Console.ReadLine());
            if (quantPag < 0)
                throw new ArgumentException("|Error - Quantidade de paginas não pode ser Negativa");

            Console.WriteLine("|Insira o ISBN 000-00-00000-00-0");
            Console.WriteLine("=====================");
            var isbn = Console.ReadLine();
            match = isbnRegex.Match(isbn);
            if (!match.Success)
                throw new ArgumentException("|Error - Formatação do ISBN está Errado");

            return new Livro(titulo, quantPag, isbn);
        }

        public static void CadastrarLivro()
        {
            try
            {
                Biblioteca.AddLivro(EntradaDados());
                MenuOp.View();
            }
            catch (FormatException ex)
            {
                ErrorMsg();
                Console.WriteLine("|Error - Formatação Errada");
                Thread.Sleep(1000);
                CadastrarLivro();
            }
            catch (OverflowException ex)
            {
                ErrorMsg();
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                CadastrarLivro();
            }
            catch (ArgumentException ex)
            {
                ErrorMsg();
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                CadastrarLivro();
            }
        }

        public static void VerLivros()
        {
            Console.Clear();
            ErrorListaMsg("A Lista está vazia");
            TituloService("Biblioteca - Livros");
            Biblioteca.ListarLivros();
            Footer();
        }

        public static void MaiorMenorLivro()
        {
            Console.Clear();
            ErrorListaMsg("Não Existe Maior e Menor Ainda");
            TituloService("Maior - Menor");
            Biblioteca.ExibirMaiorEMenor();
            Footer();
        }

        public static void Footer()
        {
            Console.WriteLine("Digite qualquer tecla para continuar...");
            Console.ReadKey();
            MenuOp.View();
        }

        //Service Title
        static void TituloService(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"= {msg} =");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
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
            if (Biblioteca.Livros.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"-{msg}-");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("===================================================");
                Thread.Sleep(1000);
                MenuOp.View();
            }
        }
    }
}
