using System;
using System.Collections.Generic;
using System.Linq;

namespace Lista2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var payments = new List<Payment>();
            payments.Add(new Payment(1));
            payments.Add(new Payment(2));
            payments.Add(new Payment(3));
            payments.Add(new Payment(4));
            payments.Add(new Payment(5));

            foreach (var payment in payments)
            {
                //payment.Id;
                Console.WriteLine(payment.Id);
            }
            //var paidPayments = new List<Payment>();
            //paidPayments.AddRange(payments);



            //var paymentTest = payments.Where(x => x.Id == 3);
            var paymentTest = payments.First(x => x.Id == 3);
            payments.Remove(paymentTest);
            //payments.RemoveRange();
            //payments.Clear();   

            foreach (var payment in payments)
            {
                //payment.Id;
                Console.WriteLine(payment.Id);
            }

            //foreach(var item in payments.Any) { }


            var exists = payments.Any(x => x.Id == 3);
            Console.WriteLine(exists);
        
            var count = payments.Count(x => x.Id == 3);

            foreach(var item in payments.Skip(1))
            {
                Console.WriteLine(item.Id);
            }
            
            foreach(var item in payments.Skip(1).Take(3))
            {
                Console.WriteLine(item.Id);
            }
        }


        public class Payment
        {
            public int Id { get; set; }

            public Payment(int id)
            {
                Id = id;
            }


        }
    }
}
