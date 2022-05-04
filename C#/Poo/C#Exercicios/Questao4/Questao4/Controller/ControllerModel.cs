using System;
using System.Collections.Generic;
using System.Text;
using Questao4.Viewers;
using Questao4.Generics;
using Questao4.Models.Entities;

namespace Questao4.Controller
{
    public static class ControllerModel
    {

        public static void ControllerOpts(List<GenericMenuOption> opts)
        {
            foreach (var opt in opts)
            {
                opt.OnSelectedEvent += ViewPath;
            }
        }

        static void ViewPath(Action sender, EventArgs e)
        {
            sender.Invoke();
        }
    }
}
