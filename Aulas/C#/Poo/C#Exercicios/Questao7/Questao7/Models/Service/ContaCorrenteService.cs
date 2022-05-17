using System;
using System.Threading;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Questao7.Models.Entities;
using Questao7.Viewers;

namespace Questao7.Models.Service
{
    public static class ContaCorrenteService
    {

        static ContaCorrente poupanca;

        static void Entrada()
        {
            Console.Clear();
            //=================================== Formatos =======================================
            var agenciaFormato = new Regex(@"^\d{4}?$");
            //=================================== Agencia =======================================
            Console.WriteLine("|Digite a Agencia : Formato => 0000");
            Console.WriteLine("========================================");
            var agencia = Console.ReadLine();
            if (!agenciaFormato.IsMatch(agencia))
                throw new ArgumentException("|Error - Formato Agencia Invalido");
            //=================================== Numero =======================================
            Console.WriteLine("|Digite o Numero");
            Console.WriteLine("========================================");
            var numero = int.Parse(Console.ReadLine());
            if (numero < 0)
                throw new ArgumentException("|Error - Numero não pode ser Negativo");
            //=================================== Saldo =======================================
            Console.WriteLine("|Digite o Saldo Inicial : O Saldo precisa ser maior ou igual que R$100");
            Console.WriteLine("========================================");
            var saldo = double.Parse(Console.ReadLine());
            if (saldo < 100)
                throw new ArgumentException("|Error - Saldo Inicial não pode ser menos que R$100");
            //=================================== Mensalidade =======================================
            Console.WriteLine("|Digite a Mensalidade");
            Console.WriteLine("========================================");
            var mensalidade = double.Parse(Console.ReadLine());
            if (mensalidade < 0)
                throw new ArgumentException("|Error - Mensalidade não pode ser negativa");   
            if (mensalidade == 0)
                throw new ArgumentException("|Error - Mensalidade não pode ser zero");
            //=================================== Object =======================================
            poupanca = new ContaCorrente(numero, agencia, saldo, mensalidade);
            MenuContaCorrente.View();
        }

        public static void CriarConta()
        {
            Console.Clear();
            try
            {
                Entrada();
                MenuContaCorrente.View();
            }
            catch (FormatException ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine(ex.Message);
                Console.WriteLine("|Error - Formatação Invalida");
                Thread.Sleep(1000);
                CriarConta();
            }
            catch (OverflowException ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                CriarConta();
            }
            catch (ArgumentException ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                CriarConta();

            }
            catch (Exception ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                CriarConta();
            }
        }

        public static void DescontaMensalidade()
        {
            ErrorConta();
            if(poupanca.Mensalidade > poupanca.Saldo)
            {
                ErrorMsg();
                Console.WriteLine("|Não tem dinheiro para pagar a mensalidade");
                Thread.Sleep(1000);
                MenuContaCorrente.View();
            }
            poupanca.DescontaMensalidade();
            MenuContaCorrente.View();
        }

        public static void ExibirConta()
        {
            ErrorConta();
            poupanca.ShowDados();
            EsperarClick();
        }
        static void ErrorMsg()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("|Error - Exception");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("===========================");
        }
        static void ErrorConta()
        {
            Console.Clear();
            if (poupanca == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("|Error - Conta Vazia");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("===========================");
                Thread.Sleep(1000);
                MenuContaCorrente.View();
            }
        }

        static void EsperarClick()
        {
            Console.WriteLine("|Digite qualquer tecla para continuar");
            Console.ReadKey();
            MenuContaCorrente.View();
        }

    }
}
