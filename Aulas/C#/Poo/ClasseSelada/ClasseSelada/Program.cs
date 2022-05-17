using System;

namespace ClasseSelada
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var pagamento = new Pagamento(); => Classe Estatica não pode ser instanciada
            Pagamento.Vencimento = DateTime.Now;


            Console.WriteLine("Hello Word");
        }

        public sealed class Pagamento
        {

            public static DateTime Vencimento { get; set; }
        }

        //Error não pode Herda classe selada
        //public class PagamentoBoleto : Pagamento { }

        //Flunt
        //Notification  
    }
}
