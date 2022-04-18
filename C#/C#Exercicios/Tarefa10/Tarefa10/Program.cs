using System;
using System.Text.RegularExpressions;

namespace Tarefa10
{
    internal class Program
    {
        static string pattern = @"[A-Z][a-z].*\s[A-Z][a-z].*";

        static void Main(string[] args)
        {
            Menu();  
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Digite o nome completo:");
            Console.WriteLine("=======================");
            string nome = Console.ReadLine();

            try
            {
                VerificarNome(nome);
            }
            catch (OverflowException ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                ErrorMsg();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                ErrorMsg();
            }

        }

        static void VerificarNome(string nome)
        {
            Match match = Regex.Match(nome, pattern);
            if (match.Success)
            {
                //Quantidade do 1 Nome
                var nomeCortado = nome.Split(' ');
                var quant1Nome = nomeCortado[0].Length;

                //Quantidade Total do Nome
                var quantNomeCompleto = 0;
                var aux = nome;
                aux = aux.Replace(" ", "");
                quantNomeCompleto = aux.Length;
                Console.WriteLine(aux);

                Console.WriteLine("==================================");
                Console.WriteLine($"Quantidade de letras nome completo: {quantNomeCompleto} ");
                Console.WriteLine($"Quantidade de letras 1º nome: {quant1Nome} ");
                Console.WriteLine($"Nome Em Caixa Alta: {nome.ToUpper()} ");
                Console.WriteLine($"Nome Em Caixa Alta: {nome.ToLower()} ");
            }
            else
            {
                ErrorMsg();
                Menu();
            }
        }

        static void ErrorMsg()
        {
            Console.Clear();
            Console.WriteLine("|Error de formatação");
            Console.WriteLine("|Digite novamente...");
            Console.WriteLine("");
            Console.WriteLine("Digite qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
