using System;

namespace ComparandoDatas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            //DateTime? data = DateTime.Now;
            var data = DateTime.Now;

            //if(data == DateTime.Now)  Eles nunca vão ser igual
            //{
            //    Console.WriteLine("É igual");
            //}

            if (data.Date == DateTime.Now)
                Console.WriteLine("É igual");

            if (data.Date < DateTime.Now)
                Console.WriteLine("É igual");

            if (data.Date <= DateTime.Now)
                Console.WriteLine("É igual");

            if (data.Date > DateTime.Now)
                Console.WriteLine("É igual");
            
            if (data.Date >= DateTime.Now)
                Console.WriteLine("É igual");

            Console.WriteLine(data);
        }
    }
}
