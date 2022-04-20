using System;
using System.Collections.Generic;
using System.Text;
using Tarefa2.Entities;
using Tarefa2.Entities.Exceptions;
using Tarefa2.Service;
using System.Threading;

namespace Tarefa2.Viewers
{
    public class EditMenu : MenuGeneric
    {

        protected override void AddOptions()
        { 
            ops = new List<OpGenerics>(){
              new OpGenerics(0,"Edit",Padding,4),
              new OpGenerics(1,"Back",Padding,6),
            };
        }

        protected override void ScreenController()
        {
            switch (OpSelect)
            {
                case 0:
                    try
                    {
                        var editService = new EditService();
                        editService.Edit(GambleMatch);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Dados Invalidos:");
                        ErrorMsg();
                    }
                    catch (ExceptionAboveLimitGamble ex)
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
