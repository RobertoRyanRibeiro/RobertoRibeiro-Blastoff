using System;
using System.Collections.Generic;
using System.Text;
using Questão1.Entities.Materials;
using Questão1.Viewers.Generics;
using Questão1.NotificationContext;

namespace Questão1.Viewers.Menu
{
    public class Menu : MenuGeneric
    {
        PisosMenu pisoMenu;
        RodapeMenu rodapeMenu;
        FoundationAreaMenu area;
        protected override void AddOptions()
        {
            ops = new List<OpGenerics>();
            ops.Add(new OpGenerics(0, "Pisos", 2, 3));
            ops.Add(new OpGenerics(1, "Rodape", 2, 5));
            ops.Add(new OpGenerics(2, "Area", 2, 7));
        }
        protected override void ScreenController()
        {
            try
            {
           
                if (area == null && pisoMenu == null && rodapeMenu == null)
                {
                    pisoMenu = new PisosMenu();
                    rodapeMenu = new RodapeMenu();
                    area = new FoundationAreaMenu();
                }
                
                do
                {
                    switch (OpSelect)
                    {
                        case 0:
                            pisoMenu.MenuScreen("Pisos");
                            break;
                        case 1:
                            rodapeMenu.MenuScreen("Rodapes");
                            break;
                        case 2:
                            area.MenuScreen(pisoMenu.GetFloor(), rodapeMenu.GetBaseboard());
                            Console.ReadLine();
                            break;
                    }
                    this.MenuScreen("Menu");
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
            }
            catch (FormatException ex)
            {
                AddNotification(new Notification("Formatação", "O valor Inserido está Invalido"));
                PrintNotification();
                Console.ReadLine();
                this.MenuScreen("Menu");
            }
        }
    }
}
