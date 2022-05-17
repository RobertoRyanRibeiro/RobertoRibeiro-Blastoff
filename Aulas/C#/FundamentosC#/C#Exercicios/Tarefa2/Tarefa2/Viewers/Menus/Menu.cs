using System;
using System.Collections.Generic;
using System.Text;
using Tarefa2.Entities;

namespace Tarefa2.Viewers
{
    public class Menu : MenuGeneric
    {
        static PlayMenu playMenu;
        static EditMenu editMenu;


        private void TitleSet()
        {
            Title = "GambleGame";
        }

        protected override void AddOptions()
        {
            TitleSet();
            ops = new List<OpGenerics>(){
              new OpGenerics(0,"Play",Padding,4),
              new OpGenerics(1,"Edit",Padding,6),
              new OpGenerics(2,"Exit",Padding,8),
            };
        }

        protected override void ScreenController()
        {
            switch (OpSelect)
            {
                case 0:
                    playMenu = new PlayMenu();
                    playMenu.MenuScreen(GambleMatch,"Lets Play!!!");
                    break;
                case 1:
                    editMenu = new EditMenu();
                    editMenu.MenuScreen(GambleMatch,"Settings");
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.White;
                    System.Environment.Exit(0);
                    break;
            }
        }
    }
}
