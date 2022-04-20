using System;

namespace ObtendoValoresData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            var data = new DateTime(2020,10,12,8,23,14);
            //var data = new DateTime(2020,10,12,13,23,14);
            //var data = DateTime.Now;

            Console.WriteLine(data);
            Console.WriteLine(data.Year);
            Console.WriteLine(data.Month);
            Console.WriteLine(data.Day);
            Console.WriteLine(data.Hour);
            Console.WriteLine(data.Minute);
            Console.WriteLine(data.Second);


            Console.WriteLine((int)data.DayOfWeek);
            Console.WriteLine(data.DayOfWeek);
            
            Console.WriteLine((int)data.DayOfYear);
            Console.WriteLine(data.DayOfYear);
        }
    }
}
