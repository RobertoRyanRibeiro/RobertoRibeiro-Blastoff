using System;
using System.Collections.Generic;
using System.Text;

namespace Questao11.Models.Entities
{
    public abstract class Contrato
    {
        public Contrato(int numero, string contratante, float valor, int prazo)
        {
            Numero = numero;
            Contratante = contratante;
            Valor = valor;
            Prazo = prazo;
        }

        public int Numero { get; private set; }
        public string Contratante { get; private set; }
        public float Valor { get; private set; }
        public int Prazo { get; private set; }


        protected double ValorPrestacao { get; set; }


        public virtual void CalcularPrestacao()
        {
            ValorPrestacao = Valor / Prazo;
        }


        public virtual void CalcularPrestacao(Contrato obj)
        {
            ValorPrestacao = Valor / Prazo;
            if(obj.GetType() == typeof(ContratoPessoaFisica))
            {
                var aux = obj as ContratoPessoaFisica;
                if (aux.Idade <= 30)
                    ValorPrestacao += 1;
                else if (aux.Idade <= 40)
                    ValorPrestacao += 2;
                else if (aux.Idade <= 50)
                    ValorPrestacao += 3;
                else if (aux.Idade > 50)
                    ValorPrestacao += 4;
            }
            else if(obj.GetType() == typeof(ContratoPessoaJuridica))
            {
                ValorPrestacao += 3;
            }
        }


        public virtual void ExibirInfo()
        {
            Console.WriteLine(" = Contrato =");
            Console.WriteLine($"|Valor - {Valor}");
            Console.WriteLine($"|Prazo - {Prazo}");
            Console.WriteLine($"|Valor da Prestação - {ValorPrestacao}");
        }

    }
}
