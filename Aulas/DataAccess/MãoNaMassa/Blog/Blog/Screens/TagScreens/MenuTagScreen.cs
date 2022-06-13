using System;

namespace Blog.Screens.TagScreens
{
    public static class MenuScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de tags");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar tags");
            Console.WriteLine("2 - Cadastrar tags");
            Console.WriteLine("3 - Atualizar tag");
            Console.WriteLine("4 - Excluir tag");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ListScreen.Load();
                    break;
                case 2:
                    CreateScreen.Load();
                    break;
                case 3:
                    UpdateScreen.Load();
                    break;
                case 4:
                    DeleteScreen.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}