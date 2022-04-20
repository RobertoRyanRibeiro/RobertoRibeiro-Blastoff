using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Tarefa2.Entities;

namespace Tarefa2.Viewers
{
    public abstract class MenuGeneric
    {
        private static bool confirmedOp;

        //Margin & Padding
        protected const int Margin = 0;
        protected const int Padding = 3;


        //GambleMatch
        public static GambleMatch GambleMatch { get; private set; }

        //Quant OpSelect
        protected static List<OpGenerics> ops;
        public static int OpSelect { get; protected set; }

        public static int Width { get; protected set; }
        public static int Height { get; protected set; }

        //Titulo
        public static string Title { get; protected set; }

        //Adicionar Op
        protected virtual void AddOptions() { }

        //Controle Fluxo
        public void MenuScreen(Player player, string title)
        {
            Width = 30;
            Height = 10;
            Console.CursorVisible = false;
            OpSelect = 0;

            if(GambleMatch == null)
                GambleMatch = new GambleMatch(player);

            AddOptions();
            Console.CursorVisible = false;
            //DrawView
            View();
            //Logic
            ScreenController();
        }

        public void MenuScreen(GambleMatch gambleMatch,string title)
        {
            Title = title;
            Width = 30;
            Height = 10;
            Console.CursorVisible = false;
            OpSelect = 0;

            GambleMatch = gambleMatch;

            AddOptions();
            Console.CursorVisible = false;
            //DrawView
            View();
            //Logic
            ScreenController();
        }

        //View
        private void View()
        {
            ResetConfig();
            try
            {
                //Desenhando a Tela
                DrawBox();
                if (ops != null)
                {
                    do
                    {
                        //Exibindo as Opções
                        DrawContent();
                        OpSelect = SelectOption(Console.ReadKey().Key);
                    } while (!confirmedOp);
                }
                else
                    throw new ArgumentException("Não existe Op");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.ReadKey();
            }

        }

        //Movendo A seta OpSelect
        private int SelectOption(ConsoleKey selection)
        {
            confirmedOp = false;

            var maxOp = ops.Count - 1;
            var minOp = 0;

            //Recebendo a Opção Atual
            var aux = OpSelect;

            //Movendo a Seta
            if (selection == ConsoleKey.DownArrow)
                aux++;
            if (selection == ConsoleKey.UpArrow)
                aux--;

            //Verificando se chegou no Max ou Min das OpSelect
            if (aux > maxOp)
                aux = minOp;
            if (aux < minOp)
                aux = maxOp;

            //Verificando se o Enter foi Clicado
            if (selection == ConsoleKey.Enter)
                confirmedOp = true;

            //Verificando se o Enter foi Clicado
            if (selection == ConsoleKey.Escape)
            {
                Console.ForegroundColor = ConsoleColor.White;
                System.Environment.Exit(0);
            }

            return aux;
        }

        //Resetando Config Do Menu
        private void ResetConfig()
        {
            //Resetando Config
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        //Escrevendo o Conteudo do Menu
        private void DrawContent()
        {
            Head();
            Content();
            Footer();
        }
        private void Content()
        {
            var colunaSeta = Padding;
            int posSeta = 0;

            foreach (var opS in ops)
            {
                opS.Draw();
                if (opS.Id == OpSelect)
                {
                    posSeta = opS.Line;
                }
            }
                Console.SetCursorPosition(colunaSeta, posSeta);
                Console.Write("=>");
        }
        private void Head()
        {
            //Title
            Console.SetCursorPosition(3, 2);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{Title,10}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void Footer()
        {
            //Colocando o mouse fora do menu
            Console.SetCursorPosition(0, Height + 5);
            Console.WriteLine("Press Esc To Exit The Application");
            Console.ForegroundColor = ConsoleColor.Black;
        }


        //Desenhando a Box do Menu
        private void DrawBox()
        {
            Console.ForegroundColor = ConsoleColor.White;
            TopBottomMenu();
            MiddleMenu();
            TopBottomMenu();
        }
        private void TopBottomMenu()
        {
            Console.Write("+");
            for (int i = 0; i <= Width; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine("+");
        }
        private void MiddleMenu()
        {
            for (int l = 0; l <= Height; l++)
            {
                Console.Write("|");
                for (int i = 0; i <= Width; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("|");
            }
        }

        //Logic

        //Verificando oque cada Opção faz
        protected virtual void ScreenController() {}

        protected static void ErrorMsg()
        {
            Console.WriteLine("Error...Digite Novamente");
            Thread.Sleep(2500);
        }
    }
}