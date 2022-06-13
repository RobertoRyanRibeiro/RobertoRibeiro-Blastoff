using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreem
{
    public static class UpdateScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando um User");
            Console.WriteLine("-------------");
            Console.Write("Id: ");
            var id = Console.ReadLine();

            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Update(new User
            {
                Id = int.Parse(id),
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuScreen.Load();
        }

        public static void Update(User user)
        {
            try
            {
                var repository = new UserRepository(Database.Connection);
                repository.Update(user);
                Console.WriteLine("User atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar o user");
                Console.WriteLine(ex.Message);
            }
        }
    }
}