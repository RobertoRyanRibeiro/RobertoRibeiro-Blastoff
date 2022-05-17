using System;
using System.Diagnostics.CodeAnalysis;

namespace ComparandoObjetos
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Word");
            var personA = new Person(1, "André Baltieri");
            var personB = new Person(1, "André Baltieri");

            //Console.WriteLine(personA.Id == personB.Id);  
            Console.WriteLine(personA == personB);  
            //Se a class não possuir IEquatable e não possuir o metodo Equals,esta função não irar retorna true
            Console.WriteLine(personA.Equals(personB));  
        }
    }

    public class Person : IEquatable<Person>    
    {
        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool Equals([AllowNull] Person other)
        {
            return Id == other.Id;
        }
    }

}