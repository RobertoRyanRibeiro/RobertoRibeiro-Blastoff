using System;
using BaltaMaoMassa.ContentContext;

namespace BaltaMaoMassa
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var course = new Course();
            course.Level = ContentContext.Enums.EContentLevel.Beginner;
            
            foreach(var item in course.Modules)
            {

            }

            var carrer = new Carrer();
            carrer.Items.Add(new CarrerItem());
            Console.WriteLine(carrer.TotalCourses);
        }
    }
}
