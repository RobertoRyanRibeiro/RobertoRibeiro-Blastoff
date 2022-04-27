using System;
using System.Collections.Generic;
using System.Text;
using Questão1.Viewers.Generics;
using Questão1.Entities.Materials;

namespace Questão1.Viewers.Menu
{
    public class RodapeMenu : MenuGeneric
    {
        public static Baseboard rodape;
        protected override void AddOptions()
        {
            ops = new List<OpGenerics>();
            ops.Add(new OpGenerics(0, "10 cm", 2, 3));
            ops.Add(new OpGenerics(1, "15 cm", 2, 5));
            ops.Add(new OpGenerics(2, "20 cm", 2, 7));
        }

        protected override void ScreenController()
        {

            switch (OpSelect)
            {
                case 0:
                    rodape = new Baseboard(10);
                    break;
                case 1:
                    rodape = new Baseboard(15);
                    break;
                case 2:
                    rodape = new Baseboard(20);
                    break;
            }
        }
        public Baseboard GetBaseboard()
        {
            return rodape;
        }
    }
}
