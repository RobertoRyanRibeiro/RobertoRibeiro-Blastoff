using System;

namespace ConversaoImplicita
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float valor = 25.8f;
            int outro = 25;
            
            //float aceita int
            valor = outro; //Conversao implícita    
            
            //outro = valor Error -> Int não é compativel com float

            Console.WriteLine("Hello World!");
        }
    }
}
