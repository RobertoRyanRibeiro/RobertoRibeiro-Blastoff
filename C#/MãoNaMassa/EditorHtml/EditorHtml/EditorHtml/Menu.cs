using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace EditorHtml
{
    public static class Menu
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            DrawScren();
            WriteOptions();
            try
            {
                short op = short.Parse(Console.ReadLine());
                HandleMenuOption(op);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Menu.Show();
            }

        }

        public static void DrawScren()
        {
            TopBottomLabel();

            MiddleLabel();

            TopBottomLabel();
        }

        public static void TopBottomLabel()
        {
            Console.Write("+");
            for (int i = 0; i <= 30; i++)
                Console.Write("-");

            Console.Write("+");
            Console.Write("\n");
        }

        public static void MiddleLabel()
        {
            for (int lines = 0; lines <= 10; lines++)
            {
                Console.Write("|");
                for (int i = 0; i <= 30; i++)
                    Console.Write(" ");

                Console.Write("|");
                Console.Write("\n");
            }
        }

        public static void WriteOptions()
        {
            Console.SetCursorPosition(3, 2);
            Console.Write("Editor HTML");
            Console.SetCursorPosition(3, 3);
            Console.Write("==========================");
            Console.SetCursorPosition(3, 4);
            Console.Write("Selecione uma opção abaixo");
            Console.SetCursorPosition(3, 6);
            Console.Write("1- Novo arquivo");
            Console.SetCursorPosition(3, 7);
            Console.Write("2- Abrir");
            Console.SetCursorPosition(3, 9);
            Console.Write("0- Sair");
            Console.SetCursorPosition(3, 10);
            Console.Write("Opção: ");
        }

        public static void HandleMenuOption(short op)
        {
            switch (op)
            {
                case 1: Editor.Show(); break;
                case 2:
                    {
                        Console.Clear();
                        Console.WriteLine("Digite o path:");
                        var path = Console.ReadLine();
                        Viewer.Show(path);
                        break;
                    }
                case 0:
                    {
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    }
                default: Show(); break;
            }
        }
    }
}
