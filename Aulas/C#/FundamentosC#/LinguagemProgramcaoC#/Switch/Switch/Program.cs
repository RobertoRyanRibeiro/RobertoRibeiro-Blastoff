using System;

namespace Switch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int valor = 1;
            //switch (valor) 
            //{

            //    case 1: Console.WriteLine("1"); break;
            //    case 2: Console.WriteLine("2"); break;
            //    case 3: Console.WriteLine("3"); break;
            //    default: Console.WriteLine("4"); break; // Se não for 1,2 ou 3
            //}

            string valor = "andre";
            //string valor = "paulo";
            switch (valor)
            {
                case "joao": Console.WriteLine("Não é o cara!"); break;
                case "marcelo": Console.WriteLine("Não é o cara!"); break;
                case "andre": Console.WriteLine("É este!"); break;
                default: Console.WriteLine("Não encontrei"); break; // Se não for 1,2 ou 3
            }

            //bool valor = true;
            //bool? valor = true;
            //bool? valor = null;
            //switch (valor)
            //{
            //case true: Console.WriteLine("Verdadeiro"); break;
            //case false: Console.WriteLine("Falso"); break;
            //default: Console.WriteLine("Nulo"); break;
            //}


        }
    }
}
