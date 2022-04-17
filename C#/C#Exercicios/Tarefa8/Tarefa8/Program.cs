using System;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Tarefa8
{
    internal class Program
    {
        static Regex pattern = new Regex(@"\d{4}\-*\d{3,4}");

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {

            Console.Clear();
            Console.WriteLine("Digite um numero de telefone : XXXX-XXXX");
            Console.WriteLine("========================================");
            var tel = Console.ReadLine();

            try
            {
                Match matchTelFormat = pattern.Match(tel);
                if (matchTelFormat.Success)
                {
                    AnalisarNum(tel);
                }
                else
                {
                    Console.Clear();
                    ErrorMsg();
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                ErrorMsg();
            }

        }

        static void AnalisarNum(string tel)
        {
            Console.Clear();
            var aux = tel;

            //Verificando se tem -
            if (aux.Contains("-"))
            {
                aux = Regex.Replace(tel, @"\-", "");
            }
            //Verificando se o numero tem menos de 7 digitos
            if (aux.Length == 7)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Telefone possui 7 dígitos. Vou acrescentar o digito três na frente.");
                aux += "3";
                tel += "3";
                Console.ForegroundColor = ConsoleColor.White;
            }

            //Formatação
            var telFixF = int.Parse(aux).ToString(@"0000-0000");
            var telFix = int.Parse(aux).ToString(@"00000000");
            ImprimirNum(tel, telFix, telFixF);
        }

        static void ImprimirNum(string tel, string telFix, string telFixF)
        {
            Console.WriteLine("Valida e corrige número de telefone");
            Console.WriteLine($"Telefone: {tel}");
            Console.WriteLine("===================================");
            Console.WriteLine($"Telefone Corrigido com formatação {telFixF}");
            Console.WriteLine($"Telefone Corrigido sem formatação {telFix}");
        }

        static void ErrorMsg()
        {
            Console.WriteLine("Error: Formatação de Numero errado");
            Thread.Sleep(1000);
            Menu();
        }
    }
}
