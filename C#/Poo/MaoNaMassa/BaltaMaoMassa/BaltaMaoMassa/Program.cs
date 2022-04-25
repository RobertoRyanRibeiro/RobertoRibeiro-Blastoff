using System;
using System.Collections.Generic;
using System.Linq;
using BaltaMaoMassa.ContentContext;

namespace BaltaMaoMassa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var articles = new List<Article>();
            //articles.Add(new Article("Artigo sobre OOP","orientação-objetos"));
            //articles.Add(new Article("Artigo sobre C#","csharp"));
            //articles.Add(new Article("Artigo sobre .NET","dotnet"));
            //foreach(var article in articles)
            //{
            //    Console.WriteLine(article.Id);
            //    Console.WriteLine(article.Title);
            //    Console.WriteLine(article.Url);
            //}

            var courses = new List<Course>();
            var courseOPP = new Course("Fundamentos OOP", "fundamentos-oop");
            var courseCsharp = new Course("Fundamentos C#", "fundamentos-csharp");
            var courseAspNet = new Course("Fundamentos ASP.NET", "fundamentos-asp.net");
            courses.Add(courseOPP);
            courses.Add(courseCsharp);
            courses.Add(courseAspNet);

            //if (courseAspNet.IsInvalid) { }

            var carrers = new List<Carrer>();
            var carrerDotnet = new Carrer("Especialista .Net","especialista-donet");
            var carrerItem2 = new CarrerItem(2,"OOP","",courseOPP);
            var carrerItem = new CarrerItem(1,"Comece por aqui","",courseCsharp);
            var carrerItem3 = new CarrerItem(3,"Aprenda .Net","",courseAspNet);
            var carrerItem4 = new CarrerItem(3,"Aprenda .Net","",null);
            carrerDotnet.Items.Add(carrerItem2);
            carrerDotnet.Items.Add(carrerItem3);
            carrerDotnet.Items.Add(carrerItem);
            carrerDotnet.Items.Add(carrerItem4);

            carrers.Add(carrerDotnet);
            foreach(var carrer in carrers)
            {
                Console.WriteLine(carrer.Title);
                foreach(var item in carrer.Items.OrderBy(x => x.Order))
                {
                    Console.WriteLine($"{item.Order} - {item.Title}");
                    Console.WriteLine(item.Course?.Title);
                    Console.WriteLine(item.Course?.Level);

                    foreach(var notification in item.Notifications)
                    {
                        Console.WriteLine($"{notification.Property} - {notification.Message}");
                    }
                }
            }
        }
    }
}
