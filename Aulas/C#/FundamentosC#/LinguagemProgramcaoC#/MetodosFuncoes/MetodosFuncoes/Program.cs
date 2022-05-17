using System;

namespace MetodosFuncoes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Invocação  do método
            MeuMetodo("C# é legal!");

            var nome = RetornaNome("André", "Baltieri");

            Console.WriteLine(nome);
        }

        //Definição do Método
        static void MeuMetodo(string parametro)
        {
            Console.WriteLine(parametro);
        }

        static string RetornaNome(string nome, string sobrenome)
        {
            //Retorna o nome e sobrenome
            return nome + " " + sobrenome;
        }

    }
}
