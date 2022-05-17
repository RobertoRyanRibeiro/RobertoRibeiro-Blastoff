using System;

namespace Object
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var idade;
            //idade = "André"; -> Error
            
            //var quantidade;
            //int quantidade;

            //object idade = 25;
            //idade = "André"; 
            //object nome = "André";

            //int idade = 25;
            //idade = 2.3; -> Error

            object quantidade;
            quantidade = 1;
            quantidade = 2.5;
            quantidade = "Teste";
            
            Console.WriteLine("Hello World!");
        }
    }
}
