using System;
using System.Collections.Generic;
using System.Text;
using Questão1.Viewers.Generics;
using Questão1.Entities.Materials;

namespace Questão1.Viewers.Menu
{
    public class PisosMenu : MenuGeneric
    {
        public static Floor floor;
        protected override void AddOptions()
        {
            ops = new List<OpGenerics>();
            ops.Add(new OpGenerics(0, "60x60 m²", 2, 3));
            ops.Add(new OpGenerics(1, "25x25 m²", 2, 5));
            ops.Add(new OpGenerics(2, "60x120 m²", 2, 7));
        }

        protected override void ScreenController()
        {
           
            switch (OpSelect)
            {
                case 0:
                    floor = new Floor(60,60);
                    break;
                case 1:
                    floor = new Floor(25,25);
                    break;
                case 2:
                    floor = new Floor(60,120);
                    break;
            }
        }
        public Floor GetFloor()
        {
            return floor;
        }
    }
}
