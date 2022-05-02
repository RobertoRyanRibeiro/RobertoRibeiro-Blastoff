using Questao3.Models.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questao3.Models.Entities
{
    public sealed class IngressoCamaroteInferior : IngressoCamarote
    {
        public IngressoCamaroteInferior(double valorVipCamarote, Assento localizacao) : base(valorVipCamarote, localizacao)
        {
            Tipo = ETipoIngresso.VIP_Camarote_Inferior;
        }
    }
}
