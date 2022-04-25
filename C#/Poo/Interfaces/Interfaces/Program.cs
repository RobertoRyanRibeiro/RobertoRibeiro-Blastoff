using System;

namespace Interfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Word");
        }
    }

    //public enum EPagamento { }

    public class Payment : IPayment
    {
        public DateTime Vencimento { get; set; }

        public void Pagar(double valor)
        {

        }
    }

    public class CreditCardPayment : IPayment
    {
        public DateTime Vencimento { get; set; }

        public void Pagar(double valor)
        {

        }
    }

    public interface IPayment
    {
        DateTime Vencimento { get; set; }

        //Pode usar assim,mas é meio raro
        //void Pagar() { }
        void Pagar(double valor);


    }
}