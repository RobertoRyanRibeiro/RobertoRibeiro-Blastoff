using System;

namespace MetodosFuncoesPratica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string MeuMetodo() { } -> Error não pode criar um metodo dentro de outro, a não ser função anonima e lambda

            MeuMetodo();

            string nome = RetornaNome("André", "Baltieri");
            Console.WriteLine(nome);

            nome = RetornaNome("André", "Baltieri",15);
        }

        static void MeuMetodo()
        {
            Console.WriteLine("C# é legal");
        }

        //static string RetornaNome()
        //{
        //    //if (1 == 55)
        //    //    return ""
        //}

        static string RetornaNome(string nome,string sobrenome)
        {
            //return nome + sobrenome;
            return nome + " " + sobrenome;
        }

        static string RetornaNome(
            string nome,
            string sobrenome,
            //int idade = 34;
            int idade,
            bool teste = false,
            double novo = 33.42
            )
        {
            //return nome + sobrenome;
            return nome + " " + sobrenome + " tem " + idade.ToString();
        }

    }
}
