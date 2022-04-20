using System;

namespace GuidsAula
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var id = Guid.NewGuid(); //Gera um novo Guid
            id.ToString();
            Console.WriteLine(id);

            id = new Guid("ea1e4ce4-1f15-41df-9bae-c4de14b17812"); // Cria um Guid apartir de um HashCode
            Console.WriteLine(id);
            Console.WriteLine(id.ToString().Substring(0,8));

            id = new Guid();
            Console.WriteLine(id);
        }


    }
}
