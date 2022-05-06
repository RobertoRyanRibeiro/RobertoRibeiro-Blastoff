using System;
using System.Collections.Generic;
using System.Text;

namespace Questao8.Models.Entities
{
    public class Automovel
    {
        public string Placa { get; private set; }
        public string Modelo { get; private set; }
        public string Cor { get; private set; }
        public short Ano { get; private set; }

        public static byte Gasolina = 1;
        public static byte Alcool = 2;
        public static byte Diesel = 3;
        public static byte Gas = 4;


        private byte tipoGasosa = 0;
        protected double valor;

        public Automovel(string placa, string modelo, string cor, short ano,byte combustivel)
        {
            Placa = placa;
            Modelo = modelo;
            Cor = cor;
            Ano = ano;
            tipoGasosa = combustivel;
        }

        public virtual void CalcularValor()
        {
            if (tipoGasosa == Gasolina)
            {
                tipoGasosa = Gasolina;
                valor = 12000;
            }
            if (tipoGasosa == Alcool)
            {
                tipoGasosa = Alcool;
                valor = 10500;
            }
            if (tipoGasosa == Diesel)
            {
                tipoGasosa = Diesel;
                valor = 11000;
            }
            if (tipoGasosa == Gas)
            {
                tipoGasosa = Gas;
                valor = 13000;
            }
        }

        public virtual void ImprimirDados()
        {
            Console.WriteLine(" = Carro =");
            Console.WriteLine($"|Placa - {Placa}");
            Console.WriteLine($"|Modelo - {Modelo}");
            Console.WriteLine($"|Cor - {Cor}");
            Console.WriteLine($"|Ano - {Ano}");
            Console.WriteLine($"|Valor - {valor}");
            Console.WriteLine(" = Combustivel =");
            if (tipoGasosa == Gasolina)
                Console.WriteLine("Gasolina");
            if (tipoGasosa == Alcool)
                Console.WriteLine("Alcool");
            if (tipoGasosa == Diesel)
                Console.WriteLine("Diesel");
            if (tipoGasosa == Gas)
                Console.WriteLine("Gas");

        }
    }
}
