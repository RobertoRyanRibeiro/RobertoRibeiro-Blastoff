using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using Questao3.Models.Entities.Enum;

namespace Questao3.Models.Entities
{
    public abstract class IngressoCamarote : Ingresso
    {
        public IngressoCamarote(double valorVipCamarote) : base(valorVipCamarote)
        {
            Localizacao = null;
            Tipo = ETipoIngresso.VIP_Camarote_Inferior;
        }

        public IngressoCamarote(double valorVipCamarote, Assento localizacao) : base(valorVipCamarote)
        {
            Localizacao = localizacao;
            Tipo = ETipoIngresso.VIP_Camarote_Inferior;
        } 
        

        public Assento Localizacao { get; private set; }

        public override string ImprimirIngresso()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ImprimirIngresso());
            if (Localizacao != null)
                sb.AppendLine($"{Localizacao.ImprimirDados()}");

            return sb.ToString();
        }

    }
}
