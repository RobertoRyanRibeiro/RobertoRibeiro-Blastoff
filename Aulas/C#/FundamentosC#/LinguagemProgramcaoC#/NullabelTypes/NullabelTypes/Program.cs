using System;

namespace NullableTypes
{
    internal class Program
    {
        //Tipo
        //Null = Vazio
        //return
        //Void = Vazio 
        static void Main(string[] args)
        {
            //(?) Simboliza uma variavel NullAble
            //int idade = null; -> Error
            int? idade = 0;
            Console.WriteLine(idade);
            idade = null;
            Console.WriteLine(idade);
            idade = 25;
            Console.WriteLine(idade);

            //int idade = 0;
            //Console.WriteLine(idade);
        }
    }
}
