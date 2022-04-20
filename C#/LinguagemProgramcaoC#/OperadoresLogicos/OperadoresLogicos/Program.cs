using System;

namespace OperadoresLogicos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //&& = E - And
            //|| = Ou - Or
            //! = Negação - Not

            int x = 12;
            bool entre = (x > 25) && (x < 40); // false
            bool ou = (x > 25) || (x < 40); // true
            bool negacao = !(x < 25); // false


            Console.WriteLine("Hello World!");
        }
    }
}
