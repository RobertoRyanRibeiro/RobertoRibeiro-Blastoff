using System;

namespace Structs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var product = new Product();
            //product.Id = 1;
            //product.Title = "Mouse gamer";
            //product.Price = 197.32f;
            //Console.WriteLine(product.Id);
            //Console.WriteLine(product.Title);
            //Console.WriteLine(product.Price);

            var product = new Product(1,"Mouse gamer",128.75f);
            Console.WriteLine(product.Id);
            Console.WriteLine(product.Title);
            Console.WriteLine(product.Price);
            Console.WriteLine(product.PriceInDolar(5.70f));
        }
    }

    //struct Product
    //{
    //    //Propriedades

    //    public int Id;
    //    public float Price;

    //    //Metodos
    //    public float PriceInDolar(float dolar)
    //    {
    //        return Price * dolar;
    //    }
    //}

    struct Product
    {
        //Propriedades
        public int Id;
        public float Price;
        public string Title;

        public Product(int id, string title, float price)
        {
            Id = id;
            Title = title;
            Price = price;
        }

        //Metodos
        public float PriceInDolar(float dolar)
        {
            return Price * dolar;
        }
    }
}
