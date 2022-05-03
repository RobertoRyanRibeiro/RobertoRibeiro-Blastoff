using System;
using System.Collections.Generic;
using System.Text;
using Questao3.Generics;
using Questao3.Models.Services;
using Questao3.Models.Entities;
using Questao3.Controller;
using System.Threading;


namespace Questao3.Viewers
{
    public class ComprarIngressoMenu
    {

        private static int _selectOp = 1;
        private static bool _confirmed;
        public static GenericMenuOption OpSelected { get; private set; }

        public static List<GenericMenuOption> options = new List<GenericMenuOption>
            {
                new GenericMenuOption("Normal", IngressoService.ComprarIngressoNormal),
                new GenericMenuOption("Vip",  IngressoService.ComprarIngressoVip),
                new GenericMenuOption("Camarote Inferior", IngressoService.ComprarIngressoCamaroteInferior),
                new GenericMenuOption("Camarote Superior", IngressoService.ComprarIngressoCamaroteSuperior),
                new GenericMenuOption("Back", UserOpMenu.View)
            };


        static void OrderOptions()
        {
            var cont = 1;
            foreach (var opt in options)
            {
                opt.OrderPos = cont;
                cont++;
            }
        }

        public static void View()
        {
            OrderOptions();
            ControllerModel.ControllerOpts(options);
            Console.Clear();
            try
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" =Compras=");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("|Dinheiro : ");
            Console.WriteLine(Season.User.Dinheiro.ToString("C"));
            Console.WriteLine("");
            //Listando Ingressos
            IngressoService.Listar();

            Console.WriteLine("=================================================");
            Console.WriteLine("  = INGRESSOS =");
            Console.WriteLine("");
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

        static void Bottom() { }

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
