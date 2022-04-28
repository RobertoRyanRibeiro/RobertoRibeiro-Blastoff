using System;
using System.Collections.Generic;
using System.Text;
using Questao2.Models.Entities;

namespace Questao2.Models.Services
{
    public class AbastecerService
    {
        BombaCombustivel bomba = new BombaCombustivel();
        public void PorValor()
        {
            Console.Clear();
            Console.WriteLine("|Digite o valor");
            Console.WriteLine("===============");
            var valor = double.Parse(Console.ReadLine());
            var litros = bomba.AbastecerPorValor(valor);
            bomba.AlterarQuantidadeCombustivel(litros);
        }

        public void PorLitro()
        {
            Console.Clear();
            Console.WriteLine("|Digite a quant de litros");
            Console.WriteLine("===============");
            var litros = double.Parse(Console.ReadLine());
            bomba.AbastecerPorLitro(litros);
            bomba.AlterarQuantidadeCombustivel(litros);
        }

    }
}
