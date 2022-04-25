using System;

namespace ClassesEstaticas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var pagamento = new Pagamento(); => Classe Estatica não pode ser instanciada
            Pagamento.Vencimento = DateTime.Now;


            Console.WriteLine("Hello Word");
        }

        public static class Pagamento 
        {

            public static DateTime Vencimento { get; set; }
        }

        public static class Settings
        {
            public static string API_URL { get; set; }
        }
    }
}
