using System;

namespace Delegates
{
    internal class Program
    {

        static void ExecutePayment(double value)
        {
            Console.WriteLine($"Pago o valor de {value}");
        } 

        static void Main(string[] args)
        {
            //Delegates => Anonymous Methods
            var pay = new Payment.Pay(ExecutePayment);
            pay(25);
        }
    }

    public class Payment
    {
        public delegate void Pay(double value);   
    }
}
