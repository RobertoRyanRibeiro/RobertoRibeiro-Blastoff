using System;
using Questao2.Models.Services;
using Questao2.Viewers.SharedMenu;

namespace Questao2.Viewers
{
    public class BombaMenu : MenuModel
    {
        BombaService service = new BombaService();

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

            Console.WriteLine(bomba.ToString());
            Console.WriteLine("+=============================+");
            Console.WriteLine("|   1 - Alterar Valor         |");
            Console.WriteLine("|   2 - Alterar Combustivel   |");
            Console.WriteLine("|   3 - Encher  Combustivel   |");
            Console.WriteLine("|   4 - Voltar                |");
            Console.WriteLine("+=============================+");
            Console.Write("OP: ");
        }

        protected override void SelectOp(int op)
        {
            switch (op)
            {
                case 1:
                    service.AlterarValor(bomba);
                    break;
                case 2:
                    service.AlterarCombustivel(bomba);
                    break; 
                case 3:
                    service.EncherBomba(bomba);
                    break;
                case 4: break;
                default:
                    throw new ArgumentException();
                    break;
            }
        }
    }
}
