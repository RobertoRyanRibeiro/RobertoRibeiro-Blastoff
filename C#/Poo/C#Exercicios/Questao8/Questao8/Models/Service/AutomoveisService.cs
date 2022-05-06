using System;
using System.Threading;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Questao8.Models.Entities;
using Questao8.Viewers;

namespace Questao8.Models.Service
{
    public static class AutomoveisService
    {

        static Automovel automovel;
        static AutomovelLuxo automovelLuxo;

        static Automovel Entrada()
        {
            Console.Clear();
            //=================================== Formatos =======================================
            var placaFormato = new Regex(@"^\w{3}\d{1}\w{1}\d{2}$");
            var modeloFormato = new Regex(@"^[a-zA-zà-ÿÀ-ÿ'\d][a-zA-zà-ÿÀ-ÿ'\s\d]*$");
            var corFormato = new Regex(@"^[a-zA-zà-ÿÀ-ÿ']*$");
            //=================================== Placa =======================================
            Console.WriteLine("|Digite a Placa : Formato => AAA1A11");
            Console.WriteLine("========================================");
            var placa = Console.ReadLine();
            if (!placaFormato.IsMatch(placa))
                throw new ArgumentException("|Error - Formato Placa Invalida");
            //=================================== Modelo =======================================
            Console.WriteLine("|Digite o Modelo");
            Console.WriteLine("========================================");
            var modelo = Console.ReadLine();
            if (!modeloFormato.IsMatch(modelo))
                throw new ArgumentException("|Error - Formato Modelo Invalido");
            //=================================== Cor =======================================
            Console.WriteLine("|Digite a Cor");
            Console.WriteLine("========================================");
            var cor = Console.ReadLine();
            if (!corFormato.IsMatch(cor))
                throw new ArgumentException("|Error - Formato Cor Invalida");
            //=================================== Ano =======================================
            Console.WriteLine("|Digite o Ano");
            Console.WriteLine("========================================");
            var ano = short.Parse(Console.ReadLine());
            if (ano < 0)
                throw new ArgumentException("|Error - O ano precisa ser um ano valido não negativo");
            if (ano > DateTime.Now.Year)
                throw new ArgumentException("|Error - O Carro precisa ser desse ano");
            //=================================== Combustivel =======================================
            Console.Clear();
            Console.WriteLine("|Gasolina - 1");
            Console.WriteLine("|Alcool - 2");
            Console.WriteLine("|Diesel - 3");
            Console.WriteLine("|Gas - 4");
            Console.WriteLine("|Digite o Combustivel Desejado");
            Console.WriteLine("========================================");
            var combustivel = byte.Parse(Console.ReadLine());
            if (combustivel > 4 || combustivel < 1)
                throw new ArgumentException("|Error opção não existe");
            //=================================== Object =======================================
            return new Automovel(placa, modelo, cor, ano, combustivel);
        }

        public static void CreateAutomovel()
        {
            try
            {

                Console.Clear();
                automovel = Entrada();
                automovel.CalcularValor();
                MenuOp.View();
            }
            catch (FormatException ex)
            {
                Console.Clear();
                Console.WriteLine("|Error - Formatação Invalida");
                Thread.Sleep(1000);
                CreateAutomovel();
            }
            catch (OverflowException ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                CreateAutomovel();
            }
            catch (ArgumentException ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                CreateAutomovel();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                CreateAutomovel();
            }
        }

        public static void ShowAutomovel()
        {
            Console.Clear();
            if (automovel == null)
                ErrorAutomovel();
            automovel.ImprimirDados();
            WaitUntilClick();
        }

        //==================== AutomovelLuxo =======================

        static AutomovelLuxo EntradaLuxo()
        {
            Console.Clear();
            //=================================== Formatos =======================================
            var placaFormato = new Regex(@"^\w{3}\d{1}\w{1}\d{2}$");
            var modeloFormato = new Regex(@"^[a-zA-zà-ÿÀ-ÿ'\d][a-zA-zà-ÿÀ-ÿ'\s\d]*$");
            var corFormato = new Regex(@"^[a-zA-zà-ÿÀ-ÿ']*$");
            //=================================== Placa =======================================
            Console.WriteLine("|Digite a Placa : Formato => AAA1A11");
            Console.WriteLine("========================================");
            var placa = Console.ReadLine();
            if (!placaFormato.IsMatch(placa))
                throw new ArgumentException("|Error - Formato Placa Invalida");
            //=================================== Modelo =======================================
            Console.WriteLine("|Digite o Modelo");
            Console.WriteLine("========================================");
            var modelo = Console.ReadLine();
            if (!modeloFormato.IsMatch(modelo))
                throw new ArgumentException("|Error - Formato Modelo Invalido");
            //=================================== Cor =======================================
            Console.WriteLine("|Digite a Cor");
            Console.WriteLine("========================================");
            var cor = Console.ReadLine();
            if (!corFormato.IsMatch(cor))
                throw new ArgumentException("|Error - Formato Cor Invalida");
            //=================================== Ano =======================================
            Console.WriteLine("|Digite o Ano");
            Console.WriteLine("========================================");
            var ano = short.Parse(Console.ReadLine());
            if (ano < 0)
                throw new ArgumentException("|Error - O ano precisa ser um ano valido não negativo");
            if (ano > DateTime.Now.Year)
                throw new ArgumentException("|Error - O Carro precisa ser desse ano");
            //=================================== Combustivel =======================================
            Console.Clear();
            Console.WriteLine("|Gasolina - 1");
            Console.WriteLine("|Alcool - 2");
            Console.WriteLine("|Diesel - 3");
            Console.WriteLine("|Gas - 4");
            Console.WriteLine("|Digite o Combustivel Desejado");
            Console.WriteLine("========================================");
            var combustivel = byte.Parse(Console.ReadLine());
            if (combustivel > 4 || combustivel < 1)
                throw new ArgumentException("|Error opção não existe");
            //=================================== Object =======================================
            return new AutomovelLuxo(placa, modelo, cor, ano, combustivel);
        }
        static void Acessorios()
        {
            //=================================== Acesso =======================================
            Console.Clear();
            var op = 0;
            do
            {
                Console.Clear();
                if(!automovelLuxo.HasArCondicionado)
                    Console.WriteLine("|[ ]Ar-Condicionado - 1");
                else
                    Console.WriteLine("|[X]Ar-Condicionado - 1");
                if(!automovelLuxo.HasDirecaoHidralica)
                    Console.WriteLine("|[ ]Direção Hidraulica - 2");
                else
                    Console.WriteLine("|[X]Direção Hidraulica - 2");
                if(!automovelLuxo.HasVidroEletrico)
                    Console.WriteLine("|[ ]Vidro Eletrico - 3");
                else
                    Console.WriteLine("|[X]Vidro Eletrico - 3");
                Console.WriteLine("|Terminar - 4");
                Console.WriteLine("========================================");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1: automovelLuxo.SwitchArcondicionado(); break;
                    case 2: automovelLuxo.SwitchDirecaoHidralica(); break;
                    case 3: automovelLuxo.SwitchVidroEletrico(); break;
                    case 4: break;
                    default:
                        Console.Clear();
                        Console.WriteLine("|Error - Esta opção não existe");
                        Thread.Sleep(1000);
                        automovelLuxo.Reset();
                        Console.Clear();
                        break;
                }
            } while (op != 4);
        }


        public static void CreateAutomovelLuxo()
        {
            try
            {
                Console.Clear();
                automovelLuxo = EntradaLuxo();
                Acessorios();
                automovelLuxo.CalcularValor();
                MenuOp.View();
            }
            catch (FormatException ex)
            {
                Console.Clear();
                Console.WriteLine("|Error - Formatação Invalida");
                Thread.Sleep(1000);
                CreateAutomovelLuxo();
            }
            catch (OverflowException ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                CreateAutomovelLuxo();
            }
            catch (ArgumentException ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                CreateAutomovelLuxo();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                CreateAutomovelLuxo();
            }
        }

        public static void ShowAutomoveLuxo()
        {
            Console.Clear();
            if (automovelLuxo == null)
                ErrorAutomovel();
            automovelLuxo.ImprimirDados();
            WaitUntilClick();
        }

        static void ErrorAutomovel()
        {
            Console.Clear();
            Console.WriteLine("|Está vazio");
            Thread.Sleep(1000);
            MenuOp.View();
        }

        static void WaitUntilClick()
        {
            Console.WriteLine("|Digite qualquer tecla para continuar...");
            Console.ReadKey();
            MenuOp.View();
        }
    }

}
