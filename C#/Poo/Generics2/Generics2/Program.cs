using System;

namespace Generics2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();
            var payment = new Payment();
            var subscription = new Subscription();
            var context = new DataContext<Person,Payment,Subscription>();
            context.Save(person);
            context.Save(payment);
            context.Save(subscription);

        }
    }

    //Pode ter quantos tipos quiser no generic
    //public class DataContext<T>
    public class DataContext<T, V, U>
        where T : Person
        where V : Payment
        where U : Subscription
    {
        public void Save(T Entity)
        {
            //T.ToString(); Error 
        }

        public void Save(V Entity) { }
        public void Save(U Entity) { }
    }

    public class Person { }

    public class Payment { }

    public class Subscription { }
}
