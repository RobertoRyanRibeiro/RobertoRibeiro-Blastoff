using System;

namespace UpCastDownCast
{
    public class Program
    {
        static void Main(string[] args)
        {
            //UpCast
            var person = new Person();
            
            person = new Personal();
            person = new Corporate();

            //var personalPerson = new Personal();
            //person = personalPerson;

            //DownCast
            var personalPerson = new Personal();
            var corporatePerson = new Corporate();

            //personalPerson = person as Personal;
            personalPerson = (Personal)person;
            //personalPerson = corporatePerson; Error não pode converter 
            //personalPerson = (Personal)corporatePerson; Error não pode converter 

        }
    }

    public class Person
    {
        public string Name { get; set; }
    }

    public class Personal : Person
    {
        public string CPF { get; set; }
    }

    public class Corporate : Person
    {
        public string CNPJ { get; set; }
    }


}