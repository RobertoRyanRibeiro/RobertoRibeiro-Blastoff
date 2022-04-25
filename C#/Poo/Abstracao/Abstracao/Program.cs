using System;

namespace Abstracao
{
    internal class Program
    {
        //Objeto : Fisico / Abstrato

        //Objeto é Composto por
        //Propriedades
        //Metodos
        //Eventos

        static void Main(string[] args)
        {
            //var customer = new Customer();
            //customer.Name = "teste";

            Console.WriteLine("Hello World!");
        }

        //Tipo Valor (Caixa Stack)
        //struct Customer
        //{
        //    public string Name;
        //}

        //Tipo Referencia (Endereço Heap)

        class Pagamento
        {
            //Propriedades
            DateTime Vencimento;

            //Metodos
            void Pagar()
            {
                ConsultarSaldoDoCartao();
            }


            //Manter os Conteudos Privado como modo de trabalhar apenas em um lugar caso haja erro => Abstracao & Encapsulamento
            private void ConsultarSaldoDoCartao()
            {

            }
        }
    }
}
