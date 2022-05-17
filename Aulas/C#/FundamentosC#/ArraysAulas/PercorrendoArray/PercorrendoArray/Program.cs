using System;

namespace PercorrendoArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            var meuArray = new int[5] { 1, 2, 3, 4, 5 };

            meuArray[0] = 12;

            Console.WriteLine(meuArray.Length);

            //Error : Porque o index vai ultrapassar a quantidade do length
            //for (var index = 0; index <= meuArray.Length; index++)
            //{
            //    Console.WriteLine(meuArray[index]);
            //} 
            
            for (var index = 0; index < meuArray.Length; index++)
            {
                Console.WriteLine(meuArray[index]);
            }

            //meuArray.Clone();
            //meuArray.CopyTo();
            //meuArray.Length;

        }
    }
}
