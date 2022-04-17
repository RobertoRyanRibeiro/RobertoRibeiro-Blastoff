using System;
using System.Threading;
using Tarefa7.Entities;
using System.Collections.Generic;

namespace Tarefa7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            //Lista Funcionarios
            var funcs = new List<Funcionario>()
            {
                new Funcionario("Roberto",3000),
                new Funcionario("Carlos",10000),
                new Funcionario("Max",4250),
                new Funcionario("Marco",7500),
                new Funcionario("Romulo",6000),
                new Funcionario("Carros",2000),
                new Funcionario("Lucas",8000)
            };

            //Lista de Valores
            var salarioDados = new SalarioDados[9]
            {
                new SalarioDados(1,200,299),
                new SalarioDados(2,300,399),
                new SalarioDados(3,400,499),
                new SalarioDados(4,500,599),
                new SalarioDados(5,600,699),
                new SalarioDados(6,700,799),
                new SalarioDados(7,800,899),
                new SalarioDados(8,900,999),
                new SalarioDados(9,1000),
            };

            try
            {
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
            catch (FormatException ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                ErrorMsg();
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                ErrorMsg();
            }
        }
        static void ErrorMsg()
        {
            Console.WriteLine("Digite Novamente...");
            Thread.Sleep(1000);
            Menu();
        }

    }
}
