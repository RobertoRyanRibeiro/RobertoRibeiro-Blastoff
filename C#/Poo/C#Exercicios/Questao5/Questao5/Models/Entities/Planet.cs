using System;
using System.Collections.Generic;
using System.Text;
using Questao5.Models.Enum;

namespace Questao5.Models.Entities
{
    public class Planet : CelestialBody
    {
        public Planet(double mass, double height, string name) : base(mass, height, name)
        {
            Type = ETypeCelestialBody.Planeta;
        }
    }
}
