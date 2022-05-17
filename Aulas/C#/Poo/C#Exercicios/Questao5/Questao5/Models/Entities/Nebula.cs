using System;
using System.Collections.Generic;
using System.Text;

namespace Questao5.Models.Entities
{
    public class Nebula : CelestialBody
    {
        public Nebula(double mass, double height, string name) : base(mass, height, name)
        {
            Type = Enum.ETypeCelestialBody.Nebula;
        }
    }
}
