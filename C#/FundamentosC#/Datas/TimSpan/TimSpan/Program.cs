using System;

namespace TimSpanAula
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            var timeSpan = new TimeSpan();
            Console.WriteLine(timeSpan);

            var timeSpanNanoSeg = new TimeSpan(1);
            Console.WriteLine(timeSpanNanoSeg);

            var timeSpanHoraMinutoSeg = new TimeSpan(5,12,8);
            Console.WriteLine(timeSpanHoraMinutoSeg);

            var timeSpanDiaHoraMinutoSeg = new TimeSpan(3,5, 50, 10);
            Console.WriteLine(timeSpanDiaHoraMinutoSeg);

            var timeSpanDiaHoraMinutoSegMili = new TimeSpan(15,12, 55, 8,100);
            Console.WriteLine(timeSpanDiaHoraMinutoSegMili);

            Console.WriteLine(timeSpanDiaHoraMinutoSeg - timeSpanDiaHoraMinutoSeg);
            Console.WriteLine(timeSpanDiaHoraMinutoSeg.Days);
            Console.WriteLine(timeSpanDiaHoraMinutoSeg.Add(new TimeSpan(12,0,0)));

        }
    }
}
