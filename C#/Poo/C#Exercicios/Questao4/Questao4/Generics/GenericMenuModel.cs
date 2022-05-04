using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Questao4.Controller;

namespace Questao4.Generics
{
    public static class GenericMenuModel
    {
        private static int _selectOp = 1;
        private static bool _confirmed;

        public static GenericMenuOption OpSelected { get; private set; }


        private static List<GenericMenuOption> options;

        static void OrderOptions()
        {
            var cont = 1;
            foreach (var opt in options)
            {
                opt.OrderPos = cont;
                cont++;
            }
        }

        static public void View()
        {
            OrderOptions();
            ControllerModel.ControllerOpts(options);
            Console.Clear();
            try
            {
                Head();
                Body();
                Bottom();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            OpSelected.OnSelected();
        }

        static void Head()
        {

        }

        static void Body()
        {
            Console.CursorVisible = false;
            DrawOption();
            do
            {
                SelectOption();
                DrawMarkOption();
                _confirmed = MoveOption(Console.ReadKey().Key);

            } while (!_confirmed);
        }

        static void Bottom()
        {

        }

        static bool MoveOption(ConsoleKey selection)
        {
            if (selection == ConsoleKey.UpArrow)
            {
                try
                {
                    _selectOp--;
                    if (_selectOp <= 0)
                        _selectOp = options.Count;
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            if (selection == ConsoleKey.DownArrow)
            {
                try
                {
                    _selectOp++;
                    if (_selectOp > options.Count)
                        _selectOp = 1;
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (selection == ConsoleKey.Escape)
                System.Environment.Exit(0);

            if (selection == ConsoleKey.Enter)
                return true;
            else
                return false;
        }

        static void SelectOption()
        {
            try
            {
                foreach (var opt in options)
                {
                    if (opt.OrderPos == _selectOp)
                    {
                        opt.Select();
                        OpSelected = opt;
                    }
                    else
                        opt.DeSelect();
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void DrawOption()
        {
            foreach (var opt in options)
            {
                opt.Draw();
            }
        }

        static void DrawMarkOption()
        {
            foreach (var opt in options)
            {
                if (opt.IsSelected)
                {
                    Console.SetCursorPosition(opt.CursoX, opt.CursoY);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("[");
                    Console.SetCursorPosition(opt.CursoX + opt.Text.Length + 1, opt.CursoY);
                    Console.Write("]");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.SetCursorPosition(opt.CursoX, opt.CursoY);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" ");
                    Console.SetCursorPosition(opt.CursoX + opt.Text.Length + 1, opt.CursoY);
                    Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
