using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreem
{
    public static class CreateScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Novo User");
            Console.WriteLine("-------------");
            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Console.Write("Perfil Id: ");
            var perfilId = Console.ReadLine();

            Create(new User
            {
                Name = name,
                Slug = slug,
                PerfilId = int.Parse(perfilId)
            });
            Console.ReadKey();
            MenuScreen.Load();
        }

        public static void Create(User user)
        {
            try
            {
                var repository = new UserRepository(Database.Connection);
                repository.Create(user);
                Console.WriteLine("User cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível salvar a User");
                Console.WriteLine(ex.Message);
            }
        }
    }
}