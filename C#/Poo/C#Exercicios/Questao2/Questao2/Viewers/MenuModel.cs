using System;
using System.Collections.Generic;
using System.Text;

namespace Questao2.Viewers
{
    public abstract class MenuModel
    {
        public void View()
        {
            do
            {
                DrawMenu();
                try
                {
                    var op = int.Parse(Console.ReadLine());
                    SelectOp(op);
                    MessageOp();
                }
                catch (FormatException e)
                {
                    Error();
                    continue;
                }
                catch (ArgumentException e)
                {
                    Error();
                    continue;
                }
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        protected virtual void DrawMenu()
        {
            Console.CursorVisible = true;
            Console.Clear();
            Console.WriteLine("+====================+");
            Console.WriteLine("|     1 - Bomba      |");
            Console.WriteLine("|   2 - Abastecer    |");
            Console.WriteLine("+====================+");
            Console.Write("OP: ");
        }

        protected virtual void SelectOp(int op)
        {
            switch (op)
            {
                case 1:
                    BombaMenu bombaMenu = new BombaMenu();
                    bombaMenu.View();
                    break;
                case 2:
                    AbastecerMenu abastecerMenu = new AbastecerMenu();
                    abastecerMenu.View();
                    break;
                default:
                    throw new ArgumentException();
                    break;
            }
        }

        protected void Error()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("|Error: Input ");
            Console.WriteLine("==============");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("|Opção Invalida");
            Console.WriteLine("|Aperte qualquer tecla para continuar...");
        }

        protected void MessageOp()
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.WriteLine("|O Programa foi finalizado");
            Console.WriteLine("|Para sair aperte Esc.Caso queira repetir, aperte qualquer outra tecla..");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
