using System;
using System.Collections.Generic;
using System.Text;

namespace Tarefa2.Viewers
{
    public class EditMenu
    {
        public static bool Confirmed { get; private set; }

        //Desenhando a Tela     /*Working*/
        public static void DrawScreen()
        {
            Console.Clear();

            //Desenhando a Tela
            TopBottomMenu();
            MiddleMenu();
            TopBottomMenu();

            Confirmed = false;
            int op = 0;

            do
            {
                //Exibindo as Opções
                WriteOp(op);
                op = SelectOption(op, Console.ReadKey().Key);

            } while (!Confirmed);

            /*Working*/
            HandleOptionsMenu(op);
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
            Console.SetCursorPosition(8, 1);
            Console.Write($"{"Config",10}");
            Console.SetCursorPosition(colunaOP, linhaOp[0]);
            Console.Write("   Play");
            Console.SetCursorPosition(colunaOP, linhaOp[1]);
            Console.Write("   Edit");
            Console.SetCursorPosition(colunaOP, linhaOp[2]);
            Console.Write("   Back");
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
            Console.SetCursorPosition(0, 15);
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

            return aux;
        }

        //Verificando oque cada Opção faz
        private static void HandleOptionsMenu(int op)
        {
            switch (op)
            {
                case 0:
                    PlayMenu.DrawScreen();
                    break;
                case 1:
                    EditMenu.DrawScreen();
                    break;
                case 2:
                    Menu.DrawScreen();
                    break;
                default:
                    EditMenu.DrawScreen();
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
