using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Tarefa2.Entities;
using Tarefa2.Service;
using Tarefa2.Entities.Exceptions;

namespace Tarefa2.Viewers
{
    public class PlayMenu : MenuGeneric
    {
        protected override void AddOptions()
        {
            ops = new List<OpGenerics>(){
              new OpGenerics(0,"Play",Padding,4),
              new OpGenerics(1,"Back",Padding,6),
            };
        }

        protected override void ScreenController()
        {
            switch (OpSelect)
            {
                case 0:
                    GambleMatch.Start();
                    try
                    {

                        var play = new PlayMatchService();
                        play.PlayMatch(GambleMatch);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Dados Invalidos:");
                        ErrorMsg();
                    }
                    catch (ExceptionPlayGame ex)
                    {
                        Console.WriteLine(ex.Message);
                        ErrorMsg();
                    }
                    MenuScreen(GambleMatch,Title);
                    break;
                case 1:
                    LoginMenu.menu.MenuScreen(GambleMatch.Player,"GambleGame");
                    break;
            }
        }
    }
}
