using System;

namespace Propriedades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pagamento = new Pagamento();
            pagamento.numeroBoleto = "123456";
            pagamento.DataPagamento = DateTime.Now;



            Console.WriteLine("Hello World!");
        }

        public class Pagamento
        {
            //int counter = 0;
            public string numeroBoleto;


            public DateTime Teste { get; private set; }

            //Auto-Properties
            public DateTime Vencimento { get; set; }
            //public DateTime Vencimento {
            //    get
            //    {
            //        return Vencimento;
            //    }
            //    set { }
            //}



            //private DateTime _dataPagamento;
            private DateTime dataPagamento;
            public DateTime DataPagamento
            {
                get {
                    Console.WriteLine("Lendo Valor");
                    return dataPagamento.AddDays(1); }
                set {
                    Console.WriteLine("Atribuindo Valor");
                    dataPagamento = value; }
            }

            //Metodos
            void Pagar() { }
        }
    }
}
