using System;
using System.Collections.Generic;
using System.Text;

namespace Questao3.Models.Entities
{
    public class User
    {
        public User(string nome, double dinheiro)
        {
            Nome = nome;
            Dinheiro = dinheiro;
        }

        public Ingresso Ingresso { get; private set; }
        public string Nome { get; private set; }
        public double Dinheiro { get; private set; }

        public void ComprarIngresso(Ingresso ingresso)
        {
            Dinheiro -= ingresso.GetValor();
            Ingresso = ingresso;
            Console.WriteLine(ingresso.ImprimirIngresso());
        }

        public void TrocarIngresso(Ingresso ingresso)
        {
            var dif = 0.0;
            if(Ingresso.GetValor() > ingresso.GetValor())
            {
                dif = Ingresso.GetValor() - ingresso.GetValor();
                Dinheiro += dif;
                Ingresso = ingresso;
                Console.WriteLine($"|O Reembolso foi: {dif:C}");
            }
            else
            {
                dif = ingresso.GetValor() - Ingresso.GetValor();
                Dinheiro -= dif;
                Ingresso = ingresso;
                Console.WriteLine($"|A Diferença foi: {dif:C}");
            }
        }

        public void SacarDinheiro(double valor)
        {
            if (valor > 0)
                Dinheiro += valor;
            else
                Console.WriteLine("O valor é negativo.");
        }

    }
}
