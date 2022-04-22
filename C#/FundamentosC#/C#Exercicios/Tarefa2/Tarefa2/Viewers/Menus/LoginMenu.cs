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

        public static Menu menu = new Menu();

        public static void MenuScreen()
        {
            Console.Clear();
            ResetSettings();
            DrawMenu();

            string name = Console.ReadLine();
           
            try
            {
                LoadMenu(name);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                ErrorMsg();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                ErrorMsg();
            }
        }

        //Desenhar Menu e Resetar Config
        private static void ResetSettings()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }
        private static void DrawMenu()
        {
            //LoginMenu
            Console.WriteLine("  *LOGIN MENU*");
            Console.WriteLine("+===========================+");
            Console.WriteLine("| Hello,please put your name|");
            Console.WriteLine("+===========================+");
        }
        //ValidarNome
        private static Player ValidateName(string name)
        {
            string pattern = @"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ][A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]*$";
            Match match = Regex.Match(name, pattern);
            if (match.Value == "" || match.Value == @"\s")
                throw new ArgumentException("O valor está vazio");
            if (match.Success)
            {
                Loading(match.Value);
                Player player = new Player(match.Value);
                return player;
            }
            else
            {
                throw new ArgumentException("Formatação Invalida...Insira somente letras,sem caracter especias e numeros");
            }
        }
        //Loading
        private static void Loading(string name)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine($"|  Hello {name}  |");

            DrawLoadingBar();
            Console.SetCursorPosition(1, 1);
            DrawLoading();

            Thread.Sleep(1500);
            Console.Clear();
            Console.WriteLine("Welcome...");
            Thread.Sleep(500);
        }
        private static void DrawLoadingBar()
        {
            Console.Write("(");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(" ");
            }
            Console.Write(")");
        }
        private static void DrawLoading()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write("X");
                Thread.Sleep(500);
            }
        }
        
        public static void LoadMenu(string name)
        {
            menu.MenuScreen(ValidateName(name),"GambleGame");
        }
        //ErrorMsg
        private static void ErrorMsg()
        {
            Console.WriteLine("Error...Digite Novamente");
            Thread.Sleep(2500);
            LoginMenu.MenuScreen();
        }
    }
}
