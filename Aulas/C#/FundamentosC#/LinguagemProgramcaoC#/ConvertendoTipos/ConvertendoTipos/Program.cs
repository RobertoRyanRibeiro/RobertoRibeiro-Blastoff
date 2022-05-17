using System;

namespace ConvertendoTipos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int inteiro;
            //Console.WriteLine(inteiro);
            
            int inteiro = 100;
            float real = 25.5f;

            //real = inteiro; -> Conversao Implicita 100.0f

            //inteiro = (int)real; -> Conversao Explicita 
            //Console.WriteLine(inteiro); 

            //Parse & ToString
            //inteiro = int.Parse(real.ToString()); -> Usando Parse() e ToString()
            //inteiro = int.Parse("255");

            //string valorReal = real.ToString();
            //inteiro = int.Parse(valorReal); -> Usando Parse()
            //Console.WriteLine(valorReal); -> Error o int.Parse não consegue converter o tipo
            //Console.WriteLine(inteiro); -> Error o int.Parse não consegue converter o tipo

            //Convert
            //inteiro = Convert.ToInt32(real);
            //Console.WriteLine(inteiro);

            //Console.WriteLine(Convert.ToBoolean(0));
            //Console.WriteLine(Convert.ToBoolean("True"));

            //inteiro = real -> Error;
            Console.WriteLine(inteiro);
        }
    }
}
