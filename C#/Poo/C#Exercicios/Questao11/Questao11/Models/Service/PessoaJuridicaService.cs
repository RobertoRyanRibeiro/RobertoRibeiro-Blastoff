using Questao11.Models.Entities;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Questao11.Viewers;
using System.Globalization;

namespace Questao11.Models.Service
{
    public static class PessoaJuridicaService
    {

        static ContratoPessoaJuridica pessoa;


        static void Input()
        {
            //============================================ Patterns =======================================
            var nomePattern = new Regex(@"^[a-zA-zà-ÿÀ-ÿ'][a-zA-zà-ÿÀ-ÿ'\s]*$");
            var cnpjPattern = new Regex(@"^\d{2}\.?\d{3}\.?\d{3}\/[0]{3}[1,2]{1}\-\d{2}$");
            var ieecPattern = new Regex(@"^\d{2}\.?\d{3}\.?\d{3}\-\d{1}$");
            //============================================ Nome =======================================
            Console.Clear();
            Console.WriteLine("|Digite o Nome do Contratante");
            Console.WriteLine("=============================");
            var nome = Console.ReadLine();
            if (!nomePattern.IsMatch(nome))
                throw new ArgumentException("|Error - Formato de Nome Invalido");
            //============================================ Numero =======================================
            Console.WriteLine("|Digite o Numero do Contratante");
            Console.WriteLine("=============================");
            var numero = int.Parse(Console.ReadLine());
            if (numero < 0)
                throw new ArgumentException("|Error - O Numero não pode ser negativo");
            //============================================ Valor =======================================
            Console.WriteLine("|Digite o Valor do Contratante");
            Console.WriteLine("=============================");
            var valor = float.Parse(Console.ReadLine());
            if (valor < 0)
                throw new ArgumentException("|Error - O Valor não pode ser negativo");
            if (valor == 0)
                throw new ArgumentException("|Error - O Valor não pode ser zero");
            //============================================ Prazo =======================================
            Console.WriteLine("|Digite o Prazo do Contratante");
            Console.WriteLine("=============================");
            var prazo = int.Parse(Console.ReadLine());
            if (valor < 0)
                throw new ArgumentException("|Error - O Prazo não pode ser negativo");
            if (valor == 0)
                throw new ArgumentException("|Error - O Prazo não pode ser zero");
            //============================================ CNPJ =======================================
            Console.WriteLine("|Digite o CNPJ : ##.###.###/0001-##  | ##.###.###/0002-##");
            Console.WriteLine("=============================");
            var cnpj = Console.ReadLine();
            if (!cnpjPattern.IsMatch(cnpj))
                throw new ArgumentException("|Error - Formato do CNPJ Invalido");
            //============================================ IEEC =======================================
            Console.WriteLine("|Digite o IEEC : ##.###.###-#");
            Console.WriteLine("=============================");
            var ieec = Console.ReadLine();
            if (!ieecPattern.IsMatch(ieec))
                throw new ArgumentException("|Error - Formato do IEEC Invalido");
            //============================================ Object =======================================
            pessoa = new ContratoPessoaJuridica(numero, nome, valor, prazo, cnpj,ieec);
        }

        //Main Methods
        public static void CreateContract()
        {
            try
            {
                Console.Clear();
                Input();
                MenuPessoaJuridica.View();
            }
            catch (FormatException ex)
            {
                ErrorMessage();
                Console.WriteLine("|Error - Formatação Invalida");
                WaitUntilThreadComplete();
            }
            catch (OverflowException ex)
            {
                ErrorMessage();
                Console.WriteLine(ex.Message);
                WaitUntilThreadComplete();
            }
            catch (ArgumentException ex)
            {
                ErrorMessage();
                Console.WriteLine(ex.Message);
                WaitUntilThreadComplete();
            }
            catch (Exception ex)
            {
                ErrorMessage();
                Console.WriteLine(ex.Message);
                WaitUntilThreadComplete();
            }
        }

        public static void ShowContract()
        {
            ErrorEmpty();
            pessoa.ExibirInfo();
            WaitUntilClick();
        }

        public static void CalculateContract()
        {
            ErrorEmpty();
            pessoa.CalcularPrestacao();
            MenuPessoaJuridica.View();
        }


        //Aux Methods
        static void ErrorEmpty()
        {
            Console.Clear();
            if (pessoa == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("|Error - Não existe pessoa ainda");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("=================");
                Thread.Sleep(1000);
                Console.Clear();
                MenuPessoaJuridica.View();
            }
        }

        static void WaitUntilThreadComplete()
        {
            Thread.Sleep(1000);
            Console.Clear();
            CreateContract();
        }

        static void WaitUntilClick()
        {
            Console.ReadKey();
            Console.Clear();
            MenuPessoaJuridica.View();
        }

        static void ErrorMessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("|Error");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("=================");
        }

    }
}
