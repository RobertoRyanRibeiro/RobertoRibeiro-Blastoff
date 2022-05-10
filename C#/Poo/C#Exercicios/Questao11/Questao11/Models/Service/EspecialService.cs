using Questao11.Models.Entities;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Questao11.Viewers;
using System.Globalization;

namespace Questao11.Models.Service
{
    public static class EspecialService
    {

        static Contrato pessoa;


        static void Input()
        {
            //============================================ Patterns =======================================
            var nomePattern = new Regex(@"^[a-zA-zà-ÿÀ-ÿ'][a-zA-zà-ÿÀ-ÿ'\s]*$");
            var cpfPattern = new Regex(@"^\d{3}\.?\d{3}\.?\d{3}\-\d{2}$");
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
            //============================================ Obj =======================================
            Console.WriteLine("|Pessoa Fisica - 1");
            Console.WriteLine("|Pessoa Juridica - 2");
            Console.WriteLine("|Digite a op");
            Console.WriteLine("=============================");
            var op = int.Parse(Console.ReadLine());
            switch (op)
            {

                case 1: pessoa = new ContratoPessoaFisica(numero, nome, valor, prazo, cpf, idade); break;
                case 2: pessoa = new ContratoPessoaJuridica(numero, nome, valor, prazo, cnpj,ieec); break;
                default:
                    Console.Clear();
                    Console.WriteLine("|Error - Op Invalida");
                    Thread.Sleep(1000);
                    Console.Clear();
                    CreateContract();
                    break;
            }
        }

        //Main Methods
        public static void CreateContract()
        {
            try
            {
                Console.Clear();
                Input();
                MenuEspecial.View();
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
            Contrato.CalcularPrestacao(pessoa);
            MenuEspecial.View();
        }


        //Aux Methods
        static void ErrorEmpty()
        {
            Console.Clear();
            if (pessoa == null)
            {
                Console.WriteLine("|Error - Não existe pessoa ainda");
                Thread.Sleep(1000);
                Console.Clear();
                MenuEspecial.View();
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
            MenuEspecial.View();
        }

        static void ErrorMessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("|ERROR");
            Console.WriteLine("=================");
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
