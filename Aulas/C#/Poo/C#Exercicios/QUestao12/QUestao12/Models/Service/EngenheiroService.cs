using Questao12.Models.Entities;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Questao12.Viewers;
using System.Globalization;

namespace Questao12.Models.Service
{
    public static class EngenheiroService
    {

        static Engenheiro engenheiro;

        static void Input()
        {
            //============================================ Patterns =======================================
            var nomePattern = new Regex(@"^[a-zA-zà-ÿÀ-ÿ'][a-zA-zà-ÿÀ-ÿ'\s]*$");
            var categoriaPattern = new Regex(@"^[a-zA-zà-ÿÀ-ÿ'][a-zA-zà-ÿÀ-ÿ'\s]*$");
            var projetoPattern = new Regex(@"^[a-zA-zà-ÿÀ-ÿ'][a-zA-zà-ÿÀ-ÿ'\s]*$");
            var cpfPattern = new Regex(@"^\d{3}\.?\d{3}\.?\d{3}\-\d{2}$");
            var creaPattern = new Regex(@"^\d{9}\-\d{1}$");
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
            //============================================ Categoria =======================================
            Console.Clear();
            Console.WriteLine("|Digite o Categoria");
            Console.WriteLine("=============================");
            var categoria = Console.ReadLine();
            if (!categoriaPattern.IsMatch(categoria))
                throw new ArgumentException("|Error - Formato de Categoria Invalido");
            //============================================ Projeto =======================================
            Console.Clear();
            Console.WriteLine("|Digite o Projeto");
            Console.WriteLine("=============================");
            var projeto = Console.ReadLine();
            if (!projetoPattern.IsMatch(projeto))
                throw new ArgumentException("|Error - Formato de Projeto Invalido");
            //============================================ Crea =======================================
            Console.Clear();
            Console.WriteLine("|Digite o Crea : #########-# ");
            Console.WriteLine("=============================");
            var crea = Console.ReadLine();
            if (!creaPattern.IsMatch(crea))
                throw new ArgumentException("|Error - Formato de Crea Invalido");
            //============================================ Object =======================================
            engenheiro = new Engenheiro(nome, cpf, salario, crea, categoria,projeto);
        }

        //Main Methods
        public static void Create()
        {
            try
            {
                Console.Clear();
                Input();
                MenuEngenheiro.View();
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
            engenheiro.ExibirInfo();
            WaitUntilClick();
        }

        public static void CalculateBonus()
        {
            ErrorEmpty();
            engenheiro.CalcularBonificacao();
            MenuEngenheiro.View();
        }


        //Aux Methods
        static void ErrorEmpty()
        {
            Console.Clear();
            if (engenheiro == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("|Error - Não existe engenheiro ainda");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("=================");
                Thread.Sleep(1000);
                Console.Clear();
                MenuEngenheiro.View();
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
            MenuEngenheiro.View();
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
