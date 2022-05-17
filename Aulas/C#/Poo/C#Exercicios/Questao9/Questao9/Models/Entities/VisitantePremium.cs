using System;
using System.Collections.Generic;
using System.Text;

namespace Questao9.Models.Entities
{
    public class VisitantePremium : Visitante
    {
        public double Saldo { get; private set; }
        public int NumeroVale { get; private set; }

        public VisitantePremium(string nome, string cpf, DateTime dateTime, byte codTema,int numVale) : base(nome, cpf, dateTime, codTema)
        {
            Saldo = 100;
            NumeroVale = numVale;
        }

        public void Comprar(double value)
        {
            Saldo -= value;
        }

        public override void ImprimirDados()
        {
            base.ImprimirDados();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" = Saldo =");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"|Saldo - {Saldo:C}");
            Console.WriteLine($"|NumVale - {NumeroVale}");
            Console.WriteLine("");
        }
    }
}
