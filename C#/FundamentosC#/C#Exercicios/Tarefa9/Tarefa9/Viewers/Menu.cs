using System;
using System.Collections.Generic;
using System.Text;
using Tarefa9.Entities;

namespace Tarefa9.Viewers
{
    public static class Menu
    {

        public static void View()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Digite um numero de Cpf :  XXX.XXX.XXX-XX");
                Console.WriteLine("========================================");
                var cpf = Console.ReadLine();

                try
                {
                    CPF Cpf = new CPF(cpf);
                    Cpf.Validar();
                    Console.WriteLine(Cpf.ToString());
                    OpMessage();
                }
                catch (OverflowException ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    ErrorMsg();
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    ErrorMsg();
                }
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        static void ErrorMsg()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-Error: Formatação Errada-");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("|Insira um CPF valido.");
            Console.WriteLine("|No formato XXX.XXX.XXX-XX");
            Console.WriteLine("=======================================");
            Console.WriteLine("Aperte qualquer tecla para continuar...");
            Console.ReadKey();
            Menu.View();
        }
        static void OpMessage()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Aperte Esc para sair da Aplicação,Caso deseje repetir aperte qualquer outra tecla");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
