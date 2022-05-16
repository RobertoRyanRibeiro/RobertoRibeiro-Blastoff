using System;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Questao9.Models.Entities;
using Questao9.Viewers;

namespace Questao9.Models.Service
{
    public static class VisitanteService
    {

        static Visitante visitante;

        static void Entrada()
        {
            Console.Clear();
            //=================================== Formatos =======================================
            var nomeFormato = new Regex(@"^[a-zA-zà-ÿÀ-ÿ'][a-zA-zà-ÿÀ-ÿ'\s]*$");
            var cpfFormato = new Regex(@"^\d{3}\.?\d{3}\.?\d{3}\.?\-\d{2}$");
            //=================================== Nome =======================================
            Console.WriteLine("|Digite o Nome ");
            Console.WriteLine("========================================");
            var nome = Console.ReadLine();
            if (!nomeFormato.IsMatch(nome))
                throw new ArgumentException("|Error - Formato Nome Invalida");
            //=================================== Cpf =======================================
            Console.WriteLine("|Digite o Cpf : ###.###.###-## / #########-##");
            Console.WriteLine("========================================");
            var cpf = Console.ReadLine();
            if (!cpfFormato.IsMatch(cpf))
                throw new ArgumentException("|Error - Formato Cpf Invalido");
            //=================================== Data =======================================
            Console.WriteLine("|Digite a Data : dd/MM/yyyy");
            Console.WriteLine("========================================");
            var data = DateTime.Parse(Console.ReadLine(), CultureInfo.CreateSpecificCulture("pt-BR"));
            if (data.Year > DateTime.Now.Year)
                throw new ArgumentException("|????? - Você veio do futuro??");
            if (data.Year > DateTime.Now.Year - 5)
                throw new ArgumentException("|Quer uma chupeta? - Muito novo não??");
            //=================================== CodTema =======================================
            Console.Clear();
            Console.WriteLine("|Vintage - 1");
            Console.WriteLine("|Numismatica - 2");
            Console.WriteLine("|Historia da Musica - 3");
            Console.WriteLine("|Pinturas - 4");
            Console.WriteLine("|Escultura - 5");
            Console.WriteLine("|Digite o Codigo do Tema Desejado");
            Console.WriteLine("========================================");
            var codTema = byte.Parse(Console.ReadLine());
            if (codTema > 5 || codTema < 1)
                throw new ArgumentException("|Error opção não existe");
            //=================================== Object =======================================
            visitante = new Visitante(nome, cpf, data, codTema);
        }

        public static void CreateVisitante()
        {
            try
            {

                Console.Clear();
                Entrada();
                MenuVisitante.View();
            }
            catch (FormatException ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine("|Error - Formatação Invalida");
                Thread.Sleep(1000);
                CreateVisitante();
            }
            catch (OverflowException ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                CreateVisitante();
            }
            catch (ArgumentException ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine(ex.Message);
                Thread.Sleep(1500);
                CreateVisitante();
            }
            catch (Exception ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                CreateVisitante();
            }
        }

        public static void CalcularItens()
        {
            Console.Clear();
            if (visitante == null)
                ErrorVisitante();
            if (visitante.Quant != 0)
            {
                Console.Clear();
                Console.WriteLine("|A quantidade já foi calculada");
                Thread.Sleep(1000);
                MenuVisitante.View();
            }
            //=================================== Acesso =======================================
            var op = 0;
            do
            {
                Console.Clear();
                //Vintage
                if (!visitante.CountVintage)
                    Console.WriteLine("|[ ]Vintage - 1");
                else
                    Console.WriteLine("|[X]Vintage - 1");
                //Numismatica
                if (!visitante.CountNumismatica)
                    Console.WriteLine("|[ ]Numismatica - 2");
                else
                    Console.WriteLine("|[X]Numismatica - 2");
                //Historia da Musica
                if (!visitante.CountHistoria)
                    Console.WriteLine("|[ ]Historia Da Musica - 3");
                else
                    Console.WriteLine("|[X]Historia Da Musica - 3");
                //Pinturas
                if (!visitante.CountPinturas)
                    Console.WriteLine("|[ ]Pintura - 4");
                else
                    Console.WriteLine("|[X]Pintura - 4"); 
                //Escultura
                if (!visitante.CountEscultura)
                    Console.WriteLine("|[ ]Escultura - 5");
                else
                    Console.WriteLine("|[X]Escultura - 5");
                
                Console.WriteLine("|Terminar - 6");
                Console.WriteLine("Digite Quais temas deseja contar");
                Console.WriteLine("========================================");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1: visitante.SwitchVintage(); break;
                    case 2: visitante.SwitchNumismatica(); break;
                    case 3: visitante.SwitchHistoria(); break;
                    case 4: visitante.SwitchPintura(); break;
                    case 5: visitante.SwitchEscultura(); break;
                    case 6: break;
                    default:
                        Console.Clear();
                        ErrorMsg();
                        Console.WriteLine("|Error - Esta opção não existe");
                        Thread.Sleep(1000);
                        visitante.Reset();
                        Console.Clear();
                        break;
                }
            } while (op != 6);
            visitante.CalcularItens();
            MenuVisitante.View();
        }


        public static void ShowVisitante()
        {
            Console.Clear();
            if (visitante == null)
                ErrorVisitante();
            visitante.ImprimirDados();
            WaitUntilClick();
        }

        static void ErrorVisitante()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("|Está vazio");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("===========================");
            Thread.Sleep(1000);
            MenuVisitante.View();
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
            MenuVisitante.View();
        }
    }

}
