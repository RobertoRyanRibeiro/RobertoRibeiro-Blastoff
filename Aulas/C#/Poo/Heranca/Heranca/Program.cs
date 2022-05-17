using System;

namespace Heranca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var customer = new Customer();
            //customer.Name = "teste";

            var pagamentoBoleto = new PagamentoBoleto();
            pagamentoBoleto.Pagar();
            pagamentoBoleto.Vencimento = DateTime.Now;
            pagamentoBoleto.NumeroBoleto = "123";

            var pagamento = new Pagamento();
            //pagamento.NumeroBoleto => Error esse metodo não existe na classe mãe

            Console.WriteLine("Hello World!");
        }

        class Pagamento
        {
            //Propriedades
            //DateTime Vencimento;
            public DateTime Vencimento;

            //Metodos
            //void Pagar()
            public void Pagar()
            {
            }
        }

        class PagamentoBoleto : Pagamento
        {
            //DateTime Vencimento;
            //void Pagar() {}

            public string NumeroBoleto;
        }

        class PagamentoCartaoCredito : Pagamento 
        {
            public string Numero;
        }

        //class PagamentoCartaoCredito : Pagamento , PagamentoBoleto => Error não aceita herança multipla
        //{
        //    public string Numero;
        //}

    }
}
