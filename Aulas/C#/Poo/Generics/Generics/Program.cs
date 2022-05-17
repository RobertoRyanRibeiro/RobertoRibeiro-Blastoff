using System;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();
            var context = new DataContext<Person>();
            context.Save(person);


            //var context = new DataConktext<Person>();
            //context.Save(Payment); => Error pq a função já está tipada
            //var context = new DataContext<Payment>();
            //context.Save(person); => Error pq a função já está tipada


            //var context = new DataContext<Person,Payment,Subscription>();
            //context.Save(person);
            //context.Save(Payment);
            //context.Save(Subscription);

        }
    }

    //Pode ter quantos tipos quiser no generic
    //public class DataContext<T, V, U>
    public class DataContext<T>
    {
        public void Save(T Entity)
        {
            //T.ToString(); Error 
        }

        //public void Save(V Entity) { }
        //public void Save(U Entity) { }
    }

    public class Person { }

    public class Payment { }

    public class Subscription { }
}
