using System;
using System.Collections.Generic;
using System.Text;

namespace Questao7.Models.Entities
{
    public abstract class Conta
    {

        protected double SaldoFinal;
        public Conta(int numero, string agencia, double saldo)
        {
            Numero = numero;
            Agencia = agencia;
            Saldo = saldo;
        }

        public int Numero { get; private set; }
        public string Agencia { get; private set; }
        public double Saldo { get; protected set; }

        public virtual void ShowDados()
        {
            Console.WriteLine(" = Conta =");
            Console.WriteLine($"|Agencia - {Agencia}");
            Console.WriteLine($"|Numero - {Numero}");
            Console.WriteLine($"|Saldo - {Saldo:C}");
        }

    }
}
