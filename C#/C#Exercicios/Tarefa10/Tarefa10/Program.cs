using System;
using System.Text.RegularExpressions;
using System.Configuration;

namespace Tarefa10
{
    public class Program
    {

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            do
            {
                DrawMenu();

                try
                {
                    string nome = Console.ReadLine();
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

                DrawMenuOp();

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            Console.Clear();
             System.Environment.Exit(0);
        }

        static void DrawMenu()
        {
            Console.Clear();
            Console.WriteLine("Digite o nome completo:");
            Console.WriteLine("=======================");
        }

        static void DrawMenuOp()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Aperte Esc para sair,se quiser repetir aperte qualquer outra tecla.");
            Console.WriteLine("=======================");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static string pattern = @"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ][A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]*$";
        static void VerificarNome(string nome)
        {
            Match match = Regex.Match(nome,pattern);

            //Verificando Formatação
            if (Regex.IsMatch(nome,pattern))
            {
                TransformaNome(match.Value);
            }
            else
            {
                ErrorMsg();
                Menu();
            }
        }

        static void TransformaNome(string nome)
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
