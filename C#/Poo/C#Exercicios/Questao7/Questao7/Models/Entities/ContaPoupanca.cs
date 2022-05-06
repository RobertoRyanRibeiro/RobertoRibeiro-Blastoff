using System;
using System.Collections.Generic;
using System.Text;

namespace Questao7.Models.Entities
{
    public class ContaPoupanca : Conta
    {
        public ContaPoupanca(int numero, string agencia, double saldo, double rendimento) : base(numero, agencia, saldo)
        {
            Rendimento = rendimento;
        }

        public double Rendimento { get; private set; }

        public void CalculaRendimento(int meses)
        {
            SaldoFinal += Saldo + Saldo * Rendimento / 100 * meses;
        }

        public override void ShowDados()
        {
            base.ShowDados();
            Console.WriteLine($"|Rendimento - {Rendimento / 100:P}");
            if (SaldoFinal != 0)
                Console.WriteLine($"|SaldoFinal - {SaldoFinal:C}");
        }
    }
}
