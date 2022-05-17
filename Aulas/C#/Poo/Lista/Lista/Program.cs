using System;
using System.Collections.Generic;


namespace Lista
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var payment = new IEnumerable<Payment>();
            //var payment = new ICollection<Payment>();
            //var payment = new List<Payment>();
            IEnumerable<Payment> payment = new List<Payment>();

            IList<Payment> paymentList = new List<Payment>();
            paymentList.Add(new Payment());
            paymentList.Remove(new Payment());

            var lista = new List<string>();

        }
    }

    public class Payment { }
}
