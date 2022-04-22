using System;

namespace ArraysAula
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            var meuArray = new int[5] { 1, 2, 3, 4, 5 };
            //var meuArray = new string[5] { 1, 2, 3, 4 ,5};
            //var meuArray = new bool[5] { 1, 2, 3, 4 ,5};
            //var meuArray = new int[5] 
            //int[] meuArray = new int[5];

            //var meuArray = new Teste[5] { new Teste() , new Teste()};
            //meuArray[0] = new teste();
           
            meuArray[0] = 12;

            Console.WriteLine(meuArray[0]);
            Console.WriteLine(meuArray[1]);
            Console.WriteLine(meuArray[2]);
            Console.WriteLine(meuArray[3]);
            Console.WriteLine(meuArray[4]);
            //Console.WriteLine(meuArray[5]); Error => além do limite do vetor
        }

        struct teste{}
    }
}
