using System;
using System.Collections.Generic;
using System.Text;
using Questao2.Models.Entities;

namespace Questao2.Models.Services
{
    public class AbastecerService
    {
        public void PorValor(BombaCombustivel bomba)
        {
            Console.Clear();
            Console.WriteLine("|Digite o valor");
            Console.WriteLine("===============");
            var valor = double.Parse(Console.ReadLine());
            if(valor < 0)
                throw new ArgumentException();
            var litros = bomba.AbastecerPorValor(valor);
            bomba.AlterarQuantidadeCombustivel(litros);
        }

        public void PorLitro(BombaCombustivel bomba)
        {
            Console.Clear();
            Console.WriteLine("|Digite a quant de litros");
            Console.WriteLine("===============");
            var litros = double.Parse(Console.ReadLine());
            if (litros < 0)
                throw new ArgumentException();
            bomba.AbastecerPorLitro(litros);
            bomba.AlterarQuantidadeCombustivel(litros);
        }

    }
}
