using Questao3.Models.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questao3.Models.Entities
{
    public sealed class IngressoNormal : Ingresso
    {
        public IngressoNormal() : base()
        {
            Tipo = ETipoIngresso.Normal;
        }
    }
}
