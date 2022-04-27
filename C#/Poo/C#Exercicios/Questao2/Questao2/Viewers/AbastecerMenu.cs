using System;
using System.Collections.Generic;
using System.Text;

namespace Questao2.Viewers
{
    public class AbastecerMenu : MenuModel
    {
        protected override void DrawMenu()
        {
            Console.CursorVisible = true;
            Console.Clear();
            Console.WriteLine("+====================+");
            Console.WriteLine("|   1 - Por Valor   |");
            Console.WriteLine("|   2 - Por Litro   |");
            Console.WriteLine("+====================+");
            Console.Write("OP: ");
        }

        protected override void SelectOp(int op)
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

    }
}
