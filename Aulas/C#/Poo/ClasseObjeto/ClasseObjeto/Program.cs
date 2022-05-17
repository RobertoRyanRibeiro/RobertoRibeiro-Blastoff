using System;

namespace ClasseObjeto
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
            var customer = new Customer();
            customer.Name = "teste";

            Console.WriteLine("Hello World!");
        }
    }

    //Tipo Valor (Caixa Stack)
    //struct Customer
    //{
    //    public string Name;
    //}

    //Tipo Referencia (Endereço Heap)
    class Customer
    {
        public string Name;
    }
}
