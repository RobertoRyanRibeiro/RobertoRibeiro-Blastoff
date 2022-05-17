using System;
using System.Collections.Generic;
using System.Text;
using Questao2.Models.Entities;
using Questao2.Models.Entities.Enums;

namespace Questao2.Models.Services
{
    public class BombaService
    {
        public void EncherBomba(BombaCombustivel bomba)
        {
            Console.Clear();
            Console.WriteLine("|Digite o valor");
            Console.WriteLine("===============");
            var valor = double.Parse(Console.ReadLine());
            if (valor < 0)
                throw new ArgumentException();
            bomba.EncherCombustivel(valor);
        }

        public void AlterarValor(BombaCombustivel bomba)
        {
            Console.Clear();
            Console.WriteLine("|Digite o valor");
            Console.WriteLine("===============");
            var valor = double.Parse(Console.ReadLine());
            if (valor < 0)
                throw new ArgumentException();
            bomba.AlterarValor(valor);
        }

        public void AlterarCombustivel(BombaCombustivel bomba)
        {
            Console.Clear();
            Console.WriteLine("| 1 - Diesel");
            Console.WriteLine("| 2 - Gasolina");
            Console.WriteLine("| 3 - Aditivada");
            Console.WriteLine("===============");
            var op = int.Parse(Console.ReadLine());
            ETipoCombustivel tipo;
            switch (op)
            {
                case 1:
                    tipo = ETipoCombustivel.Diesel;
                    break;
                case 2:
                    tipo = ETipoCombustivel.Gasolina;
                    break;
                case 3:
                    tipo = ETipoCombustivel.Aditivada;
                    break;
                default:
                    throw new ArgumentException();
                    break;
            }

            bomba.AlterarCombustivel(tipo);
        }
    }
}
