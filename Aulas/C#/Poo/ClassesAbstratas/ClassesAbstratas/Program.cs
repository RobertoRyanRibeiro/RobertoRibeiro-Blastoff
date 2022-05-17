using System;

namespace ClassesAbstratas
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Word");
            //var pagamento = new Payment(); => Não pode instanciar uma classe abstrata
            var ticketPayment = new ticketPayment();
        }
    }

    //public enum EPagamento { }

    public abstract class Payment : IPayment
    {
        public DateTime Vencimento { get; set; }

        public virtual void Pagar(double valor)
        {
            //Executar
        }
    }

    public class CreditCardPayment : Payment
    {
        public override void Pagar(double valor)
        {
            base.Pagar(valor);
        }
    }
   
    public class ticketPayment : Payment
    {
        public override void Pagar(double valor)
        {
            base.Pagar(valor);
        }
    }

    public class ApplePayPayment : Payment
    {
        public override void Pagar(double valor)
        {
            base.Pagar(valor);
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