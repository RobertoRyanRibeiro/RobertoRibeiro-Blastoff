using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Tarefa2.Entities;

namespace Tarefa2.Viewers
{
    public static class LoginMenu
    {

        public static void MenuScreen()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            //LoginMenu
            Console.WriteLine("  *LOGIN MENU*");
            Console.WriteLine("+===========================+");
            Console.WriteLine("| Hello,please put your name|");
            Console.WriteLine("+===========================+");
            try
            {
                string name = Console.ReadLine();

                if (String.IsNullOrEmpty(name))
                    throw new FormatException("The value is null");
                if (String.IsNullOrWhiteSpace(name))
                    throw new FormatException("The value is just a space");

                //throw new FormatException("The value is numeric");

                Console.Clear();
                Console.WriteLine($"|  Hello {name}  |");
                Loading();

                Player player = new Player(name);

                Menu.MenuScreen(player);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
            }
            finally
            {
                LoginMenu.MenuScreen();
            }
        }


        public static void Loading()
        {
            DrawLoadingBar();
            Console.SetCursorPosition(1, 1);
            DrawLoading();

            Thread.Sleep(1500);
            Console.Clear();
            Console.WriteLine("Welcome...");
            Thread.Sleep(500);
        }

        public static void DrawLoadingBar()
        {
            Console.Write("(");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(" ");
            }
            Console.Write(")");
        }

        public static void DrawLoading()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write("X");
                Thread.Sleep(500);
            }
        }

    }
}
