using System;
using System.Threading;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Questao10.Models.Entities;
using Questao10.Viewers;

namespace Questao10.Models.Service
{
    public static class ContaEstudanteService
    {
        static ContaEstudante contaEstudante;

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
            contaEstudante = new ContaEstudante(preco, parcela, tipo);
        }

        public static void CreateCompra()
        {
            try
            {
                Console.Clear();
                Entrada();
                MenuContaEstudante.View();
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
            if (contaEstudante == null)
                ErrorEmpty();

            if (contaEstudante.Status != Enum.EStatus.Pendente)
            {
                ErrorMsg();
                Console.WriteLine("|Error - A Compra já foi finalizada");
                Thread.Sleep(1000);
                Console.Clear();
                MenuContaEstudante.View();
            }

            try
            {
                Console.Clear();
                contaEstudante.PagarParcela(1);
                MenuContaEstudante.View();
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
            if (contaEstudante == null)
                ErrorEmpty();

            if (contaEstudante.Status != Enum.EStatus.Pendente)
            {
                ErrorMsg();
                Console.WriteLine("|Error - A Compra já foi finalizada");
                Thread.Sleep(1000);
                Console.Clear();
                MenuContaEstudante.View();
            }

            contaEstudante.QuitarCompra();
            Thread.Sleep(1000);
            MenuContaEstudante.View();
        }

        public static void CancelarCompra()
        {

            Console.Clear();
            if (contaEstudante == null)
                ErrorEmpty();

            if (contaEstudante.Status != Enum.EStatus.Pendente)
            {
                ErrorMsg();
                Console.WriteLine("|Error - A Compra já foi finalizada");
                Thread.Sleep(1000);
                Console.Clear();
                MenuContaEstudante.View();
            }

            contaEstudante.CancelarCompra();
            Thread.Sleep(1000);
            MenuContaEstudante.View();
        }

        public static void RenegociarCompra()
        {
            Console.Clear();
            if (contaEstudante == null)
                ErrorEmpty();

            if (contaEstudante.Status != Enum.EStatus.Pendente)
            {
                ErrorMsg();
                Console.WriteLine("|Error - A Compra já foi finalizada");
                Thread.Sleep(1000);
                Console.Clear();
                MenuContaEstudante.View();
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
                contaEstudante.AtualizarParcela(juros / 100, qtd);
                Thread.Sleep(1000);
                MenuContaEstudante.View();
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

        public static void EntradaEspecial()
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
            //=================================== Obj =======================================
            Console.WriteLine(" = Object =");
            Console.WriteLine(" 1 - Compra");
            Console.WriteLine(" 2 - Conta Estudante");
            Console.WriteLine("|Digite qual Obj vc deseja que esse seja");
            Console.WriteLine("========================================");
            var aux = int.Parse(Console.ReadLine());
            switch (aux)
            {
                case 1: contaEstudante.Especial(new Compra(preco, parcela, contaEstudante.Tipo)); break;
                case 2: contaEstudante.Especial(new ContaEstudante(preco, parcela, contaEstudante.Tipo)); break;
                default:
                    Console.Clear();
                    ErrorMsg();
                    Console.WriteLine("|Error - Esta Op não existe");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Especial(); break;
            }
        }

        public static void Especial()
        {
            //Verificando se esta vazio
            Console.Clear();
            if (contaEstudante == null)
                ErrorEmpty();

            //Verificando se a compra foi finalizada
            if (contaEstudante.Status != Enum.EStatus.Pendente)
            {
                ErrorMsg();
                Console.WriteLine("|Error - A Compra já foi finalizada");
                Thread.Sleep(1000);
                Console.Clear();
                MenuContaEstudante.View();
            }

            try
            {
                EntradaEspecial();
                MenuContaEstudante.View();
            }
            catch (FormatException ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine("|Error - Formatação Invalida");
                WaitUntilThreadEspecial();
            }
            catch (OverflowException ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine(ex.Message);
                WaitUntilThreadEspecial();
            }
            catch (ArgumentException ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine(ex.Message);
                WaitUntilThreadEspecial();
            }
            catch (Exception ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine(ex.Message);
                WaitUntilThreadEspecial();
            }

        }

        public static void ShowCompra()
        {
            Console.Clear();
            if (contaEstudante == null)
                ErrorEmpty();
            contaEstudante.ImprimirDados();
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
            MenuContaEstudante.View();
        }

        static void WaitUntilClick()
        {
            Console.WriteLine("|Digite qualquer tecla para continuar...");
            Console.ReadKey();
            MenuContaEstudante.View();
        }

        static void ErrorMsg()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("|Error - Exception");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("===========================");
        }

        static void WaitUntilThread()
        {
            Thread.Sleep(1000);
            CreateCompra();
        }

        static void WaitUntilThreadEspecial()
        {
            Thread.Sleep(1000);
            Especial();
        }
    }

}
