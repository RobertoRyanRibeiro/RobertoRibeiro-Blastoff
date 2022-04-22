using System;
using System.Collections.Generic;
using System.Text;

namespace Tarefa7.Entities
{
    public struct SalarioDados
    {

        public int Id { get; private set; }
        public int Cont { get; private set; }
        public double MinLimite { get; private set; }
        public double MaxLimite { get; private set; }



        public SalarioDados(int id, double minLimit, double maxLimt)
        {
            if (minLimit < 0 || maxLimt < 0)
                throw new ArgumentException("O limite não pode ser negativo");
            if (minLimit == maxLimt)
                throw new ArgumentException("Os limites não podem ser iguais");
            if (minLimit > maxLimt)
                throw new ArgumentException("O limite minimo não pode ser maior que o maximo");

            Id = id;
            Cont = 0;
            MinLimite = minLimit;
            MaxLimite = maxLimt;
        }

        public SalarioDados(int id, double minLimit)
        {
            if (minLimit < 0)
                throw new ArgumentException("O limite não pode ser negativo");

            Id = id;
            Cont = 0;
            MinLimite = minLimit;
            MaxLimite = 0;
        }



        public void Intervalo(double value)
        {
            if (value < 0)
                throw new ArgumentException("O valor não pode ser negativo");

            if (MinLimite == 1000)
            {
                if (value >= MinLimite)
                    Cont++;
                return;
            }

            if (value >= MinLimite && value <= MaxLimite)
                Cont++;

        }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Id [{Id}]");
            if (MinLimite == 1000)
                sb.AppendLine($"Intervalo[{MinLimite.ToString("C")} - Em diante]");
            else
                sb.AppendLine($"Intervalo[{MinLimite.ToString("C")} - {MaxLimite.ToString("C")}]");
            sb.AppendLine($"Quantidade : {Cont}");

            return sb.ToString();
        }

    }
}
