using System;
using System.Collections.Generic;
using System.Text;
using Questão1.Viewers.Generics;
using Questão1.Entities.Materials;
using Questão1.Entities;

namespace Questão1.Viewers.Menu
{
    public class FoundationAreaMenu
    {

        public void MenuScreen(Floor piso,Baseboard rodape)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Digite o Comprimento do Local:");
            var comp = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite a Largura do Local:");
            var larg = double.Parse(Console.ReadLine());

            FoundationArea area = new FoundationArea(comp,larg,piso,rodape);
            area.CalculateTheMaterials();
            Console.WriteLine(area.ToString());
        }

    }
}
