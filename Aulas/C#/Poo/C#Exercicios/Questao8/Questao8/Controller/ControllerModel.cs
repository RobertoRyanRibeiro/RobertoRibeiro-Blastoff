using System;
using System.Collections.Generic;
using System.Text;
using Generics;
using Questao8.Viewers;
using Questao8.Models.Entities;

namespace Controller
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
