using System;

namespace StructPratica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product mouse = new Product(1,"Mouse gamer",299.97);

            mouse.Id = 55;

            Console.WriteLine(mouse.Id);
            Console.WriteLine(mouse.Name);
            Console.WriteLine(mouse.Price);
        }
    }

    struct Product
    {
        //Propriedades
        public int Id;
        public string Name;
        public double Price;

        public Product(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        //Metodos
        public double PriceInDolar(double dolar)
        {
            return Price * dolar;
        }
    }
}
