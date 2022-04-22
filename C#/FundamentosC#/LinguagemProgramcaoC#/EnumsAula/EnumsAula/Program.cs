using System;

namespace EnumsAula
{
    //Exemplo 1
    internal class Program
    {
        static void Main(string[] args)
        {
            //Sem enumeradores
            //var cliente = new Cliente("João Silva",1);

            //Com enumerador
            var cliente = new Cliente("João Silva",EEstadoCivil.Casado);
            Console.WriteLine(cliente.Nome);
            Console.WriteLine(cliente.EstadoCivil); //Escreve Casado
            Console.WriteLine((int)cliente.EstadoCivil); //Escreve 2
        }
    }

    struct Cliente 
    {
        public string Nome;
        public EEstadoCivil EstadoCivil;
     
        public Cliente(string nome,EEstadoCivil estadoCivil)
        {
            Nome = nome;
            EstadoCivil = estadoCivil;
        }
    }

    enum EEstadoCivil
    {
        Solteiro = 1,
        Casado = 2,
        Divorciado = 3,
    }

    //Exemplo 2
    internal class Program2
    {
        static void Main(string[] args)
        {
            Product mouse = new Product(1, "Mouse gamer", 299.97,EProductType.Product);
            var manutencaoEletrica = new Product(2,"Manutenção Elétrica residencial",500,EProductType.Service);

            mouse.Id = 55;

            Console.WriteLine(mouse.Id);
            Console.WriteLine(mouse.Name);
            Console.WriteLine(mouse.Price);
            Console.WriteLine(mouse.Type);
            Console.WriteLine((int)mouse.Type);
        }
    }

    struct Product
    {
        //Propriedades
        public int Id;
        public string Name;
        public double Price;
        public EProductType Type;

        public Product(int id, string name, double price,EProductType type)
        {
            Id = id;
            Name = name;
            Price = price;
            Type = type;
        }

        //Metodos
        public double PriceInDolar(double dolar)
        {
            return Price * dolar;
        }
    }

    enum EProductType
    {
        Product = 1,
        Service = 2
    }

}
