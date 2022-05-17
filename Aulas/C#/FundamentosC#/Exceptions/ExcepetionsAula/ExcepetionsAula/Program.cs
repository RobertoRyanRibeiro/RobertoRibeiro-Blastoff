using System;

namespace ExcepetionsAula
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[3];

            for (var index = 0; index < 10; index++)
            {
                //System.IndexOutOfRangeException
                Console.WriteLine(arr[index]);
            }
        }
    }
}
