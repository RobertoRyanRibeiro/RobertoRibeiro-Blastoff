using System;

namespace TiposComplexos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pagamento = new Pagamento();

            Console.WriteLine("Hello World!");
        }

        public class Pagamento
        {
            //Propriedades
            DateTime Vencimento;

            //string AddressZipCode;
            Address BillingAddress = new Address();

            //Metodos
            void Pagar() { }
        }

        public class Address
        {
            string ZipCode;
        }
    }
}
