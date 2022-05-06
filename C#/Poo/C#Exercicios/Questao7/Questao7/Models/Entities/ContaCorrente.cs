using System;
using System.Collections.Generic;
using System.Text;

namespace Questao7.Models.Entities
{
    public class ContaCorrente : Conta
    {

        public ContaCorrente(int numero, string agencia, double saldo, double mensalidade) : base(numero, agencia, saldo)
        {
            Mensalidade = mensalidade;
        }

        public double Mensalidade { get; private set; }


        public void DescontaMensalidade()
        {
            SaldoFinal = Saldo - Mensalidade;
        }

        public override void ShowDados()
        {
            base.ShowDados();
            Console.WriteLine($"|Mensalidade - {Mensalidade}");
            if (SaldoFinal != 0)
                Console.WriteLine($"|SaldoFinal - {SaldoFinal:C}");
        }


    }
}
