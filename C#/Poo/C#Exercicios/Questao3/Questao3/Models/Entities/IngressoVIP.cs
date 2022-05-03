﻿using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using Questao3.Models.Entities.Enum;

namespace Questao3.Models.Entities
{
    public class IngressoVIP : Ingresso
    {
        public IngressoVIP(double value) : base(value)
        {
            Tipo = ETipoIngresso.VIP;
        }

        public override string ImprimirIngresso()
        {
            return base.ImprimirIngresso();
        }

        protected override string ExibirValor()
        {
            return $"|Valor - {Valor.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"))}";
        }
    }
}
