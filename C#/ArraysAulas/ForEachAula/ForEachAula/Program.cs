using System;

namespace ForEachAula
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            var meuArray = new int[5] { 1, 2, 3, 4, 5 };

            meuArray[0] = 12;

            foreach (var item in meuArray)
                Console.WriteLine(item);


            var funcionarios = new Funcionario[5];
            funcionarios[0] = new Funcionario() { Id = 2579, Nome = "Andre"};
            foreach(var func in funcionarios)
            {
                Console.WriteLine(func.Id) ;
            }

        }

    }
    public struct Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
