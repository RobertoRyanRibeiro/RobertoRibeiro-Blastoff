using System;

namespace ModificadoresAcesso
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pagamento = new Pagamento();
            //pagamento => Não da para ler se os metodos estão private
            Console.WriteLine(pagamento.ToString());

            Console.WriteLine("Hello World!");
        }

        //Private,Protected, Internal e Public
        //private class Pagamento
        internal class Pagamento
        {
            //Propriedades
            protected DateTime Vencimento;

            //Metodos
            private void Pagar() { }
        }
        
        public class PagamentoBoleto : Pagamento //Error 
        { 
            void Test()
            {
                //base.Pagar(); Não consegue acessar pq esta private
                //base.Vencimento Consegue acessar pq está protected
            }
        }
    }
}
