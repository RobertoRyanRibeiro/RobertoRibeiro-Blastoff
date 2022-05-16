using System;
using System.Threading;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Questao10.Models.Entities;
using Questao10.Viewers;

namespace Questao10.Models.Service
{
    public static class CompraService
    {
        static Compra compra;

        static void Entrada()
        {
            Console.Clear();
            //=================================== Formatos =======================================
            var tipoFormato = new Regex(@"^[a-zA-zà-ÿÀ-ÿ'][a-zA-zà-ÿÀ-ÿ'\s]*$");
            //=================================== Preco =======================================
            Console.WriteLine("|Digite o Preço");
            Console.WriteLine("========================================");
            var preco = double.Parse(Console.ReadLine());
            if (preco < 0)
                throw new ArgumentException("|Error - Preço não pode ser negativo");
            if (preco == 0)
                throw new ArgumentException("|Error - Preço não pode ser zero");
            //=================================== Parcelas =======================================
            Console.WriteLine("|Digite a quantidade de Parcelas");
            Console.WriteLine("========================================");
            var parcela = int.Parse(Console.ReadLine());
            if (parcela < 0)
                throw new ArgumentException("|Error - Parcela não pode ser negativa");
            if (parcela == 0)
                throw new ArgumentException("|Error - Parcela não pode ser zero");
            //=================================== Tipo =======================================
            Console.WriteLine("|Digite o Tipo");
            Console.WriteLine("========================================");
            var tipo = Console.ReadLine();
            if (!tipoFormato.IsMatch(tipo))
                throw new ArgumentException("|Error - Formato Tipo Invalido");
            //=================================== Object =======================================
            compra = new Compra(preco, parcela, tipo);
        }

        public static void CreateCompra()
        {
            try
            {
                Console.Clear();
                Entrada();
                MenuCompra.View();
            }
            catch (FormatException ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine("|Error - Formatação Invalida");
                WaitUntilThread();
            }
            catch (OverflowException ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine(ex.Message);
                WaitUntilThread();
            }
            catch (ArgumentException ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine(ex.Message);
                WaitUntilThread();
            }
            catch (Exception ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine(ex.Message);
                WaitUntilThread();
            }
        }


        public static void PagarParcela()
        {
            Console.Clear();
            if (compra == null)
                ErrorEmpty();

            if (compra.Status != Enum.EStatus.Pendente)
            {
                ErrorMsg();
                Console.WriteLine("|Error - A Compra já foi finalizada");
                Thread.Sleep(1000);
                Console.Clear();
                MenuCompra.View();
            }

            try
            {
                Console.Clear();
                Console.WriteLine("Quantas parcelas vai pagar?");
                var qtd = int.Parse(Console.ReadLine());
                if (qtd < 0)
                    throw new ArgumentException("|Error - A Quantidade não pode ser negativa");
                if (qtd == 0)
                    throw new ArgumentException("|Error - A Quantidade não pode ser zero");
                if (qtd > compra.Parcelas)
                    throw new ArgumentException("|Error - Não existe essa Quantidade de Parcelas");
                compra.PagarParcela(qtd);
                MenuCompra.View();
            }
            catch (FormatException ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine("|Error - Formtação Invalida");
                Thread.Sleep(1000);
                PagarParcela();
            }
            catch (OverflowException ex)
            {
                Console.Clear();
                ErrorMsg();

                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                PagarParcela();
            }
            catch (ArgumentException ex)
            {
                Console.Clear();
                ErrorMsg();

                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                PagarParcela();
            }
        }

        public static void QuitarCompra()
        {
            Console.Clear();
            if (compra == null)
                ErrorEmpty();

            if (compra.Status != Enum.EStatus.Pendente)
            {
                ErrorMsg();
                Console.WriteLine("|Error - A Compra já foi finalizada");
                Thread.Sleep(1000);
                Console.Clear();
                MenuCompra.View();
            }

            compra.QuitarCompra();
            Thread.Sleep(1000);
            MenuCompra.View();
        }

        public static void CancelarCompra()
        {

            Console.Clear();
            if (compra == null)
                ErrorEmpty();

            if (compra.Status != Enum.EStatus.Pendente)
            {
                ErrorMsg();
                Console.WriteLine("|Error - A Compra já foi finalizada");
                Thread.Sleep(1000);
                Console.Clear();
                MenuCompra.View();
            }

            compra.CancelarCompra();
            Thread.Sleep(1000);
            MenuCompra.View();
        }

        public static void RenegociarCompra()
        {
            Console.Clear();
            if (compra == null)
                ErrorEmpty();

            if (compra.Status != Enum.EStatus.Pendente)
            {
                ErrorMsg();
                Console.WriteLine("|Error - A Compra já foi finalizada");
                Thread.Sleep(1000);
                Console.Clear();
                MenuCompra.View();
            }

            try
            {
                Console.WriteLine("|Qual o Valor do Juros%?");
                var juros = double.Parse(Console.ReadLine());
                if (juros < 0)
                    throw new ArgumentException("|Error - A Quantidade não pode ser negativa");
                if (juros == 0)
                    throw new ArgumentException("|Error - A Quantidade não pode ser zero");
                Console.WriteLine("|Quantas parcelas vai pagar?");
                var qtd = int.Parse(Console.ReadLine());
                if (qtd < 0)
                    throw new ArgumentException("|Error - A Quantidade não pode ser negativa");
                if (qtd == 0)
                    throw new ArgumentException("|Error - A Quantidade não pode ser zero");
                Console.Clear();
                compra.AtualizarParcela(juros/100, qtd);
                Thread.Sleep(1000); 
                MenuCompra.View();
            }
            catch (FormatException ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine("|Error - Formtação Invalida");
                Thread.Sleep(1000);
                RenegociarCompra();
            }
            catch (OverflowException ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                RenegociarCompra();
            }
            catch (ArgumentException ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                RenegociarCompra();
            }
        }

        public static void ShowCompra()
        {
            Console.Clear();
            if (compra == null)
                ErrorEmpty();
            compra.ImprimirDados();
            WaitUntilClick();
        }


        //Tools
        static void ErrorEmpty()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("|Está Vazio");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("===========================");
            Thread.Sleep(1000);
            MenuCompra.View();
        }

        static void ErrorMsg()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("|Error - Exception");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("===========================");
        }

        static void WaitUntilClick()
        {
            Console.WriteLine("|Digite qualquer tecla para continuar...");
            Console.ReadKey();
            MenuCompra.View();
        }

        static void WaitUntilThread()
        {
            Thread.Sleep(1000);
            CreateCompra();
        }
    }

}
