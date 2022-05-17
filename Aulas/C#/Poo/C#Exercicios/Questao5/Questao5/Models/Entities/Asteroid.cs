using System;
using System.Collections.Generic;
using System.Text;

namespace Questao5.Models.Entities
{
    public class Asteroid : CelestialBody
    {
        public Asteroid(double mass, double height, string name) : base(mass, height, name)
        {
            Type = Enum.ETypeCelestialBody.Asteroide;
        }
    }
}
