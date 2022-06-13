using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreem
{
    public static class ListScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Users");
            Console.WriteLine("-------------");
            List();
            Console.ReadKey();
            MenuScreen.Load();
        }

        private static void List()
        {
            var repository = new UserRepository(Database.Connection);
            var items = repository.Get();



            foreach (var item in items)
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
        }
    }
}