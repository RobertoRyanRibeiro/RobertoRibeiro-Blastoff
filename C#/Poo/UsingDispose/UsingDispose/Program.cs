using System;

namespace UsingDispose
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var pagamento = new Pagamento();
            //pagamento.Dispose();

            //Se não implementar o IDispose, o using não ira conseguir executar esta função
            using(var pagamento = new Pagamento())
            {
                Console.WriteLine("Processandoo Pagamento");
            }

                Console.WriteLine("Hello Word");
        }

        public class Pagamento : IDisposable
        {
            //Garbage Collector
            //GC.Collect;

            public Pagamento()
            {
                Console.WriteLine("Iniciando o Pagamento");
            }


            public void Dispose()
            {
                Console.WriteLine("Finalizando o Pagamento");
            }
        }
    }
}
