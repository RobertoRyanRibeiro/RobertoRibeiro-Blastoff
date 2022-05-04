using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using Questao3.Models.Entities.Enum;

namespace Questao3.Models.Entities
{
    public class IngressoVIP : Ingresso
    {
        protected double extra;

        public IngressoVIP(double value) : base()
        {
            extra = value;
            Tipo = ETipoIngresso.VIP;
        }

        public override string ImprimirIngresso()
        {
            return base.ImprimirIngresso();
        }

        public override double GetValor()
        {
            return Valor + extra;
        }

        protected override string ExibirValor()
        {
            return $"|Valor - {GetValor().ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"))}";
        }
    }
}
