using System;
using System.Collections.Generic;
using Questao2.Viewers.Menus;
using Questao2.Viewers.MenuModel.OptionModel;

namespace Questao2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu(15, 10,"Menu");
            var opts = new List<Options>()
            {
                new Options(1, "  Bomba"),
                new Options(2, "Abastecer")
            };
            mainMenu.AddOpts(opts);
            mainMenu.View();
        }
    }
}
