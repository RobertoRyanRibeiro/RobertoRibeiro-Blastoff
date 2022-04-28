using System;
using System.Collections.Generic;
using System.Text;
using Questao2.Models.Services;
using Questao2.Models.Entities;

namespace Questao2.Viewers
{
    public class AbastecerMenu : MenuModel
    {
        AbastecerService service = new AbastecerService();

        public override void View()
        {
            DrawMenu();
            var op = int.Parse(Console.ReadLine());
            SelectOp(op);
        }

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
                    service.PorValor();
                    break;
                case 2:
                    service.PorLitro();
                    break;
                default:
                    throw new ArgumentException();
                    break;
            }
        }

    }
}
