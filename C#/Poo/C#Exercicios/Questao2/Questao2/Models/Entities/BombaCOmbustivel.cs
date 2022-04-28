using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using Questao2.Models.Entities.Enums;

namespace Questao2.Models.Entities
{
    public class BombaCombustivel
    {
        public ETipoCombustivel Tipo { get; private set; }
        public double Valor { get; private set; }
        public double QuantidadeCombustivel { get; private set; }

        public BombaCombustivel(double valor,ETipoCombustivel tipo,double quant)
        {
            Valor = valor;
            QuantidadeCombustivel = quant;
            Tipo = tipo;
        }

        public double AbastecerPorValor(double valor)
        {
            var litros = 0.0;
            litros  = valor/Valor;
  
            Console.Clear();
            Console.WriteLine($"|O valor total foi : {valor.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"))}");
            Console.WriteLine($"|A quantidade de litros: {litros}");
            Console.WriteLine("===============================");
            Console.WriteLine("|Digite qualquer tecla para continuar...");
            Console.ReadKey();

            return litros;
        }

        public void  AbastecerPorLitro(double litros)
        {
            var result = litros * Valor;
            Console.Clear();
            Console.WriteLine($"|O valor total foi : {result.ToString("C",CultureInfo.CreateSpecificCulture("pt-BR"))}");
            Console.WriteLine($"|A quantidade de litros: {litros}");
            Console.WriteLine("===============================");
            Console.WriteLine("|Digite qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void EncherCombustivel(double valor)
        {
            QuantidadeCombustivel += valor;
        }


        public void AlterarValor(double valor)
        {
            Valor = valor;
        }

        public void AlterarCombustivel(ETipoCombustivel tipo)
        {
            Tipo = tipo;
        }
        public void AlterarQuantidadeCombustivel(double litros)
        {
            QuantidadeCombustivel -= litros;
        }

        public override string ToString()
        { 
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("|Bomba");
            sb.AppendLine($"|Tipo: {Tipo}");
            sb.AppendLine($"|Valor: {Valor.ToString("C",CultureInfo.CreateSpecificCulture("pt-BR"))}");
            sb.AppendLine($"|Quantidade: {QuantidadeCombustivel}L");

            return sb.ToString();   
        }

    }
}
