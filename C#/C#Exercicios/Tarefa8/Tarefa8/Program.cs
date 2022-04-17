using System;
using System.Threading;
using System.Globalization;

namespace Tarefa8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Digite um numero de telefone : XXXX-XXXX");
            Console.WriteLine("========================================");
            var telTxt = Console.ReadLine();

            try
            {
                telTxt = AnalisarNum(telTxt);
                ImprimirNum(telTxt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                Menu();
            }

        }

        static string AnalisarNum(string telTxt)
        {

            if (telTxt.Length > 8)
                throw new Exception("O Numero ultrapassou o limite de digitos");

            if (String.IsNullOrEmpty(telTxt) || String.IsNullOrWhiteSpace(telTxt))
                throw new Exception("O Numero estar vazio");

            var telX = telTxt.Split("-");
            var tel = "";
            //Verificando se e numero
            for (var c=0; c < telTxt.Length; c++)
            {
                var numero = int.Parse(telX[c]);
                tel = telX[c];
            }

            Console.WriteLine($"Telefone: {tel}");

            if (tel.Length == 7)
            {
                Console.WriteLine("Telefone possui 7 digitos. Vou acrescentar o digito três na frente.");
                tel.Insert(6, "3");
            }

            return tel;
        }

        static void ImprimirNum(string txt)
        {
            Console.WriteLine($"Telefone Corrigido sem formatação {txt}");
            Console.WriteLine($"Telefone Corrigido sem formatação {}");
        }
    }
}
