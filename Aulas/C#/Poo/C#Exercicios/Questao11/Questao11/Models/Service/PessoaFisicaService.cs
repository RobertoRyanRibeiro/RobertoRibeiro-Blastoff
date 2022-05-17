using Questao11.Models.Entities;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Questao11.Viewers;
using System.Globalization;

namespace Questao11.Models.Service
{
    public static class PessoaFisicaService
    {

        static ContratoPessoaFisica pessoa;


        static void Input()
        {
            //============================================ Patterns =======================================
            var nomePattern = new Regex(@"^[a-zA-zà-ÿÀ-ÿ'][a-zA-zà-ÿÀ-ÿ'\s]*$");
            var cpfPattern = new Regex(@"^\d{3}\.?\d{3}\.?\d{3}\-\d{2}$");
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
            //============================================ CPF =======================================
            Console.WriteLine("|Digite o CPF : ###.###.###-##");
            Console.WriteLine("=============================");
            var cpf = Console.ReadLine();
            if (!cpfPattern.IsMatch(cpf))
                throw new ArgumentException("|Error - Formato do Cpf Invalido");
            //============================================ Data =======================================
            Console.WriteLine("|Digite a data de Nascimento dd/MM/yyyy");
            Console.WriteLine("=============================");
            var ano = DateTime.Parse(Console.ReadLine(), CultureInfo.CreateSpecificCulture("pt-BR"));
            if (ano > DateTime.Now)
                throw new ArgumentException("|Error - A Data não pode ser do Futuro");
            var idade = (short)(DateTime.Now.Year - ano.Year);
            //============================================ Object =======================================
            pessoa = new ContratoPessoaFisica(numero, nome, valor, prazo, cpf, idade);
        }

        //Main Methods
        public static void CreateContract()
        {
            try
            {
                Console.Clear();
                Input();
                MenuPessoaFisica.View();
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
            MenuPessoaFisica.View();
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
                MenuPessoaFisica.View();
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
            MenuPessoaFisica.View();
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
