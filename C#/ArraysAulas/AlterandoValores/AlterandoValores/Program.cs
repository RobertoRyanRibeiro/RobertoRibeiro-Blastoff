using System;

namespace AlterandoValores
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            var arr = new int[4];
            var arrb = arr;

            arrb[0] = arr[0];
            arr[0] = 23;
            Console.WriteLine(arrb[0]);

            var primeiro = new int[4];
            var segundo = new int[4];
            
            //segundo[0] = primeiro[0];
            primeiro.CopyTo(segundo,0);
            
            primeiro[0] = 23;
            Console.WriteLine(segundo[0]);
        }

    }
    public struct Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
