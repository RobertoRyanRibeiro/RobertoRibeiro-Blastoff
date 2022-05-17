using System;

namespace MetodosAula
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pagamento = new Pagamento(DateTime.Now);
            //var pagamento = new PagamentoCartao();
            pagamento.Pagar("1234");

        }

        public class Pagamento
        {
            public DateTime DataPagamento { get; set; }

            //Contrutor
            //public Pagamento() { }

            public Pagamento(DateTime vencimento)
            {
                Console.WriteLine("Inciando Pagamento");
                DataPagamento = DateTime.Now;
            }


            //Metodos
            //SobreCarga
            //public void Pagar(string numero) { }
            //public void Pagar(string numero,DateTime vencimento) { }
            //public void Pagar(string numero,DateTime vencimento,bool pagarAposVencimento = false) { }
            //public void Pagar(string numero, DateTime vencimento, bool vouPagarAposVencimento= false) { }

            //SobreEscrita
            //public void Pagar(string numero) { }
            public virtual void Pagar(string numero)
            {
                Console.WriteLine("Pagar");
            }
        }

        public class PagamentoCartao : Pagamento
        {
            //public PagamentoCartao(DateTime vencimento) { }

            public PagamentoCartao(DateTime vencimento) : base(vencimento) { }

            //SobreEscrita
            //public void PagarComCartao(string numero) { }
            public override void Pagar(string numero)
            {
                base.Pagar(numero);
                Console.WriteLine("Pagar Cartão");
            }
        }

        public class Address
        {
            string ZipCode;
        }
    }
}
