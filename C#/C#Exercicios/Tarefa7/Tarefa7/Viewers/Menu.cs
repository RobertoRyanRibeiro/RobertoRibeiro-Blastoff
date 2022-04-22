using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Tarefa7.Entities;

namespace Tarefa7.Viewers
{
    internal class Menu
    {
        public static void View()
        {
            Console.Clear();

            ////Lista Funcionarios
            //var funcs = new List<Funcionario>()
            //{
            //new Funcionario("Roberto",3000),
            //new Funcionario("Carlos",10000),
            //new Funcionario("Max",4250),
            //new Funcionario("Marco",7500),
            //new Funcionario("Romulo",6000),
            //new Funcionario("Carros",2000),
            //new Funcionario("Lucas",8000)
            //};

            //Lista de Valores
            var salarioDados = new SalarioDados[9]
            {
                new SalarioDados(1, 200, 299),
                new SalarioDados(2, 300, 399),
                new SalarioDados(3, 400, 499),
                new SalarioDados(4, 500, 599),
                new SalarioDados(5, 600, 699),
                new SalarioDados(6, 700, 799),
                new SalarioDados(7, 800, 899),
                new SalarioDados(8, 900, 999),
                new SalarioDados(9, 1000),
             };

            try
            {
                Exibir(InputDados(), salarioDados);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                ErrorMsg();
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
                ErrorMsg();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                ErrorMsg();
            }

        }

        static List<Funcionario> InputDados()
        {
            var funcs = new List<Funcionario>();

            Console.Clear();
            do
            {
                Console.Clear();
                Console.WriteLine("Digite o Nome:");
                Console.WriteLine("===============");
                var nome = Console.ReadLine();
                Console.WriteLine("Digite o Valor Bruto de Vendas:");
                Console.WriteLine("===============");
                var vdBruto = double.Parse(Console.ReadLine());

                funcs.Add(new Funcionario(nome, vdBruto));

                Console.WriteLine("Aperte qualquer tecla para inserir um novo funcionario,caso não queira aperte Esc");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            return funcs;
        }

        static void Exibir(List<Funcionario> funcs, params SalarioDados[] salarioDados)
        {
            Console.Clear();
            //Rodando List
            foreach (var func in funcs)
            {
                //Exibindo os Valores dos Funcionarios
                Console.WriteLine(func.ToString());
                for (var cont = 0; cont < salarioDados.Length; cont++)
                {
                    salarioDados[cont].Intervalo(func.Total());
                }
            }

            Console.WriteLine("===============================================");

            //Exibindo resultados
            for (var cont = 0; cont < salarioDados.Length; cont++)
            {
                Console.WriteLine(salarioDados[cont].ToString());
            }
        }

        static void ErrorMsg()
        {
            Console.WriteLine("Digite Novamente...");
            Thread.Sleep(1000);
            Menu.View();
        }

    }
}
