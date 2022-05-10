using System;
using System.Collections.Generic;
using System.Text;

namespace Questao11.Models.Entities
{
    public class ContratoPessoaFisica : Contrato
    {
        public ContratoPessoaFisica(int numero, string contratante, float valor, int prazo, string cpf, short idade) : base(numero, contratante, valor, prazo)
        {
            CPF = cpf;
            Idade = idade;
        }
        public string CPF { get; private set; }
        public short Idade { get; private set; }


        public override void CalcularPrestacao()
        {
            base.CalcularPrestacao();
            if (Idade <= 30)
                ValorPrestacao += 1;
            else if (Idade <= 40)
                ValorPrestacao += 2;
            else if (Idade <= 50)
                ValorPrestacao += 3;
            else if (Idade > 50)
                ValorPrestacao += 4;
        }

        public override void ExibirInfo()
        {
            base.ExibirInfo();
            Console.WriteLine($"|Idade - {Idade}");
        }

    }
}
