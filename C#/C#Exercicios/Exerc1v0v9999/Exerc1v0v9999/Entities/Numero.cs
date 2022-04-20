using System;
using System.Collections.Generic;
using System.Text;
using Exerc1v0v9999.Entities.Enum;

namespace Exerc1v0v9999.Entities
{
    public struct Numero
    {
        public uint Value { get; set; }
        public ParImpar EparImpar { get; private set; }
        public uint Unidade { get; private set; }
        public uint? Dezena { get; private set; }
        public uint? Centena { get; private set; }
        public uint? Milhar { get; private set; }

        public Numero(uint value)
        {
            Value = value;
            EparImpar = Enum.ParImpar.Padrao;
            Unidade = 0     ;
            Dezena = null;
            Centena = null;
            Milhar = null;
            ParImpar();
            DivNum();
        }

        private void DivNum()
        {
            if (Value < 0 || Value >= 9999)
                throw new ArgumentException("Error: O valor está fora do límite...");

            uint aux = Value;
            Unidade = aux % 10;
            aux = aux / 10;
            Dezena = aux % 10;
            aux = aux / 10;
            Centena = aux % 10;
            aux = aux / 10;
            Milhar = aux;
        }

        private void ParImpar()
        {
            if (Value % 2 == 0)
                EparImpar = Enum.ParImpar.Par;
            else
                EparImpar = Enum.ParImpar.Impar;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"|Valor: {Value,-25}");
            result.AppendLine($"|Unidade: {Unidade,-25}");
            result.AppendLine($"|Dezena: {Dezena,-25}");
            result.AppendLine($"|Centena: {Centena,-25}");
            result.AppendLine($"|Milhar: {Milhar,-25}");
            result.AppendLine($"|Par/Impar: {EparImpar,-25}");

            return result.ToString();
        }

    }
}
