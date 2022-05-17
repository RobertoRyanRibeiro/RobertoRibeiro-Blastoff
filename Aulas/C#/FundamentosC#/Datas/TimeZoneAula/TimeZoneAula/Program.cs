using System;
using System.Globalization;

namespace TimeZoneAula
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            var utcDate = DateTime.UtcNow;

            Console.WriteLine(DateTime.Now);
            Console.WriteLine(utcDate);

            Console.WriteLine(utcDate.ToLocalTime());

            var timezoneAustralia = TimeZoneInfo.FindSystemTimeZoneById("Pacific/Aucklnd");
            Console.WriteLine(timezoneAustralia);

            //var horaAustralia = TimeZoneInfo.ConvertTimeToUtc(utcDate, timezoneAustralia);
            var horaAustralia = TimeZoneInfo.ConvertTimeFromUtc(utcDate, timezoneAustralia);
            Console.WriteLine(horaAustralia);

            var getTimeZones = TimeZoneInfo.GetSystemTimeZones();

            foreach (var zone in getTimeZones)
            {
                Console.WriteLine(zone.Id);
                Console.WriteLine(zone);
                Console.WriteLine(TimeZoneInfo.ConvertTimeFromUtc(utcDate,zone));
                Console.WriteLine("________________");
            }
        }
    }
}
