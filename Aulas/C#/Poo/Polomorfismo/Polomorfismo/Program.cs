using System;

namespace Polomorfismo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var pagamentoBoleto = new PagamentoBoleto();
            pagamentoBoleto.Pagar();
            pagamentoBoleto.Vencimento = DateTime.Now;
            pagamentoBoleto.NumeroBoleto = "123";

            var pagamento = new Pagamento();
            Console.WriteLine(pagamento.ToString());

            Console.WriteLine("Hello World!");
        }

        class Pagamento
        {
            //Propriedades
            //DateTime Vencimento;
            public DateTime Vencimento;

            //Metodos
            //void Pagar()
            public virtual void Pagar()
            {
            }
            public override string ToString()
            {
                return Vencimento.ToString("dd/MM/yyyy");
            }
        }

        class PagamentoBoleto : Pagamento
        {

            public string NumeroBoleto;

            public override void Pagar()
            {
                //Regra do Boleto
            }
        }

        class PagamentoCartaoCredito : Pagamento
        {
            public string Numero;

            public override void Pagar()
            {
                //Regra do Cartao
            }
        }
    }
}
