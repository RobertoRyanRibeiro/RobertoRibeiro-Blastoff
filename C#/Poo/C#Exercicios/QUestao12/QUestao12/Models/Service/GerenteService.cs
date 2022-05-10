using Questao12.Models.Entities;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Questao12.Viewers;
using System.Globalization;

namespace Questao12.Models.Service
{
    public static class GerenteService
    {

        static Gerente gerente;

        static void Input()
        {
            //============================================ Patterns =======================================
            var nomePattern = new Regex(@"^[a-zA-zà-ÿÀ-ÿ'][a-zA-zà-ÿÀ-ÿ'\s]*$");
            var cpfPattern = new Regex(@"^\d{3}\.?\d{3}\.?\d{3}\-\d{2}$");
            //============================================ Nome =======================================
            Console.Clear();
            Console.WriteLine("|Digite o Nome");
            Console.WriteLine("=============================");
            var nome = Console.ReadLine();
            if (!nomePattern.IsMatch(nome))
                throw new ArgumentException("|Error - Formato de Nome Invalido");
            //============================================ Cpf =======================================
            Console.Clear();
            Console.WriteLine("|Digite o Cpf : ###.###.###-##");
            Console.WriteLine("=============================");
            var cpf = Console.ReadLine();
            if (!cpfPattern.IsMatch(cpf))
                throw new ArgumentException("|Error - Formato de Cpf Invalido");
            //============================================ Salario =======================================
            Console.WriteLine("|Digite o Salario");
            Console.WriteLine("=============================");
            var salario = double.Parse(Console.ReadLine());
            if (salario < 0)
                throw new ArgumentException("|Error - O Salario não pode ser negativo");
            if (salario == 0)
                throw new ArgumentException("|Error - O Salario não pode ser negativo");
            //============================================ SenhaEspecial =======================================
            Console.WriteLine("|Digite o Senha Especial");
            Console.WriteLine("=============================");
            var senha = float.Parse(Console.ReadLine());
            if (senha < 0)
                throw new ArgumentException("|Error - O Senha não pode ser negativo");
            if (senha == 0)
                throw new ArgumentException("|Error - O Senha não pode ser negativo"); 
            //============================================ QtdFuncionario =======================================
            Console.WriteLine("|Digite a quantidade de funcionarios");
            Console.WriteLine("=============================");
            var qtd = int.Parse(Console.ReadLine());
            if (qtd < 0)
                throw new ArgumentException("|Error - O Quantidade não pode ser negativo");
            if (qtd == 0)
                throw new ArgumentException("|Error - O Quantidade não pode ser negativo");
            //============================================ Object =======================================
            gerente = new Gerente(nome, cpf,salario, senha, qtd);
        }

        //Main Methods
        public static void Create()
        {
            try
            {
                Console.Clear();
                Input();
                MenuGerente.View();
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

        public static void Show()
        {
            ErrorEmpty();
            gerente.ExibirInfo();
            WaitUntilClick();
        }

        public static void CalculateBonus()
        {
            ErrorEmpty();
            gerente.CalcularBonificacao();
            MenuGerente.View();
        }


        //Aux Methods
        static void ErrorEmpty()
        {
            Console.Clear();
            if (gerente == null)
            {
                Console.WriteLine("|Error - Não existe gerente ainda");
                Thread.Sleep(1000);
                Console.Clear();
                MenuGerente.View();
            }
        }

        static void WaitUntilThreadComplete()
        {
            Thread.Sleep(1000);
            Console.Clear();
            Create();
        }

        static void WaitUntilClick()
        {
            Console.ReadKey();
            Console.Clear();
            MenuGerente.View();
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
