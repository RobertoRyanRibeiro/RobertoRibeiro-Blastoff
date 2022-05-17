using Questao3.Models.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questao3.Models.Entities
{
    public sealed class IngressoCamaroteSuperior : IngressoCamarote
    {
        public IngressoCamaroteSuperior(double valorVipCamarote) : base(valorVipCamarote)
        {
            Tipo = ETipoIngresso.VIP_Camarote_Superior;
        }

        public IngressoCamaroteSuperior(double valorVipCamarote, Assento localizacao) : base(valorVipCamarote, localizacao)
        {
            Tipo = ETipoIngresso.VIP_Camarote_Superior;
        }
    }
}
