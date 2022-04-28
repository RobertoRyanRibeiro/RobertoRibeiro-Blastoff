using System;
using System.Collections.Generic;
using System.Text;
using Questao2.Models.Entities.Enums;

namespace Questao2.Models.Entities
{
    public class BombaCombustivel
    {
        public TipoCombustivel Tipo { get; private set; }
        public double Valor { get; private set; }
        public double QuantidadeCombustivel { get; private set; }

        public BombaCombustivel()
        {

        }
        public double AbastecerPorValor(double valor)
        {
            var litros = 0;

            return litros;
        }

        public void  AbastecerPorLitro(double litros)
        {

        }

        public void AlterarValor()
        {

        }

        public void AlterarCombustivel()
        {

        }
        public void AlterarQuantidadeCombustivel(double litros)
        {
            QuantidadeCombustivel -= litros;
        }

    }
}
