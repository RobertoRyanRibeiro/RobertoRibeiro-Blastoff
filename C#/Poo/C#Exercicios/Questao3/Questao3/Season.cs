using System;
using System.Collections.Generic;
using System.Text;
using Questao3.Models.Entities;

namespace Questao3
{
    public static class Season
    {
        public static User User { get; private set; } = new User("Roberto", 0);
        public static CamaroteInferior CamaroteInferior { get; private set; } = new CamaroteInferior("Bar do Zé",4,3);
        public static CamaroteSuperior CamaroteSuperior { get; private set; } = new CamaroteSuperior("Bar do Jão",4,3);
        
    }
}
