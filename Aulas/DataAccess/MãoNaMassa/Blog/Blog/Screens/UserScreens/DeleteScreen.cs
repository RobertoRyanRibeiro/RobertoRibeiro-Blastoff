using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreem
{
    public static class DeleteScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir um user");
            Console.WriteLine("-------------");
            Console.Write("Qual o id do User que deseja exluir? ");
            var id = Console.ReadLine();

            Delete(int.Parse(id));
            Console.ReadKey();
            MenuScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new UserRepository(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("User exluído com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível exluir a User");
                Console.WriteLine(ex.Message);
            }
        }
    }
}