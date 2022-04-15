using System;
using System.Collections.Generic;
using System.Text;

namespace Tarefa2.Viewers
{
    public class PlayMenu
    {
        public static bool Confirmed { get; private set; }

        //Desenhando a Tela    /*Working*/
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
            //HandleOptionsMenu(op);
        }

        //Escrevendo as Opções
        private static void WriteOp(int op)
        {
            Console.SetCursorPosition(8, 1);
            Console.Write($"{"GamblerPlay!!!",10}");
            Console.SetCursorPosition(3, 5);
            Console.Write("  1 - Play");
            Console.SetCursorPosition(3, 6);
            Console.Write("  2 - Edit");
            Console.SetCursorPosition(3, 7);
            Console.Write("  0 - Exit");
            switch (op)
            {
                case 0:
                    Console.SetCursorPosition(1, 5);
                    Console.Write("  =>");
                    Console.SetCursorPosition(0, 15);
                    break;
                case 1:
                    Console.SetCursorPosition(1, 6);
                    Console.Write("  =>");
                    Console.SetCursorPosition(0, 15);
                    break;
                case 2:
                    Console.SetCursorPosition(1, 7);
                    Console.Write("  =>");
                    Console.SetCursorPosition(0, 15);
                    break;
            }
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
