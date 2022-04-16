using System;
using System.Collections.Generic;
using System.Text;
using Tarefa2.Entities;

namespace Tarefa2.Viewers
{
    public static class Menu
    {
        //Entities
        //Partida
        public static GambleMatch gambleMatch { get; set; }
        public static bool Confirmed { get; private set; }


        public static void MenuScreen(Player player)
        {
            //DrawView
            DrawScreen();
            //Logic
            ControlerScreen(player);
        }

        //Desenhando a Tela
        private static void DrawScreen()
        {
            //Resetando Config
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            //Desenhando a Tela
            TopBottomMenu();
            MiddleMenu();
            TopBottomMenu();

        }

        //Logica do Menu
        private static void ControlerScreen(Player player)
        {
            //Criando Partida
            if(gambleMatch == null)
               gambleMatch = new GambleMatch(player);

            Confirmed = false;
            int op = 0;
            //Colocando o Curso Invisivel
            Console.CursorVisible = false;

            do
            {
                //Exibindo as Opções
                WriteOp(op);
                op = SelectOption(op, Console.ReadKey().Key);
            } while (!Confirmed);

            HandleOptionsMenu(op, gambleMatch);
        }

        //Escrevendo as Opções
        private static void WriteOp(int op)
        {
            //Colunas
            var colunaOP = 3;
            var colunaSeta = 1;
            //Linhas por Op
            var linhaOp = new int[3] { 5, 7, 9 };
            //Menu
             //Title
            Console.SetCursorPosition(3, 2);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{"Welcome To The GambleGame!!!",10}");
            Console.ForegroundColor = ConsoleColor.White;
             //OP
            Console.SetCursorPosition(colunaOP, linhaOp[0]);
            Console.Write("   Play");
            Console.SetCursorPosition(colunaOP, linhaOp[1]);
            Console.Write("   Edit");
            Console.SetCursorPosition(colunaOP, linhaOp[2]);
            Console.Write("   Exit");
            switch (op)
            {
                case 0:
                    Console.SetCursorPosition(colunaSeta, linhaOp[0]);
                    Console.Write("  =>");
                    break;
                case 1:
                    Console.SetCursorPosition(colunaSeta, linhaOp[1]);
                    Console.Write("  =>");
                    break;
                case 2:
                    Console.SetCursorPosition(colunaSeta, linhaOp[2]);
                    Console.Write("  =>");
                    break;
            }
            //Colocando o mouse fora do menu
            Console.SetCursorPosition(0,15);
            Console.WriteLine("Press Esc To Exit The Application");
            Console.ForegroundColor = ConsoleColor.Black;
        }

        //Movendo a Seta
        private static int SelectOption(int op, ConsoleKey selection)
        {
            //Recebendo a Opção Atual
            var aux = op;

            //Movendo a Seta
            if (selection == ConsoleKey.DownArrow)
                aux++;
            if (selection == ConsoleKey.UpArrow)
                aux--;

            //Verificando se chegou no Max ou Min das Op
            if (aux > 2)
                aux = 0;
            if (aux < 0)
                aux = 2;

            //Verificando se o Enter foi Clicado
            if (selection == ConsoleKey.Enter)
                Confirmed = true;

            //Verificando se o Enter foi Clicado
            if (selection == ConsoleKey.Escape)
            {
                Console.ForegroundColor = ConsoleColor.White;
                System.Environment.Exit(0);
            }

            return aux;
        }

        //Verificando oque cada Opção faz
        private static void HandleOptionsMenu(int op,GambleMatch gambleMatch)
        {
            switch (op)
            {
                case 0:
                    PlayMenu.MenuScreen(gambleMatch);
                    break;
                case 1:
                    EditMenu.MenuScreen(gambleMatch);
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.White;
                    System.Environment.Exit(0);
                    break;
            }
        }

        //Desenhando Parte de cima do Menu
        private static void TopBottomMenu()
        {
            Console.Write("+");
            for (int i = 0; i <= 30; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine("+");
        }

        //Desenhano a Parte de Baixo do Menu
        private static void MiddleMenu()
        {
            for (int l = 0; l <= 10; l++)
            {
                Console.Write("|");
                for (int i = 0; i <= 30; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("|");
            }
        }

    }
}
