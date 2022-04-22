using System;

namespace ConversaoExplicita
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inteiro = 10;
            uint inteiroSemSinal = (uint) inteiro; //Conversao Explicita
            //(uint) cast

            Console.WriteLine("Hello World!");
        }
    }
}
