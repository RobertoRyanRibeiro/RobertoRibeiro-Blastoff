using System;

namespace ValueTypesReferencesTypesAula
{
    public class Program
    {
        //Heap => ReferencesTypes (Tem GBC - Garbage Collector)
        //Stack => ValueTypes

        static void Main(string[] args)
        {

            //Tipo Valor TypeValue
            int x = 25;
            int y = x; // Y é uma copia de X
            Console.WriteLine(x); // 25
            Console.WriteLine(y); // 25
            x = 32;
            Console.WriteLine(x); // 32
            Console.WriteLine(y); // 25

            //Tipo Referencia ReferencesTypes
            var arr = new string[2];
            arr[0] = "Item 1";
            var arr2 = arr; //Não cria uma cópia

            Console.WriteLine(arr[0]);
            Console.WriteLine(arr2[0]);

            //Altera as duas listas
            arr[0] = "Item Alterado";
            Console.WriteLine(arr[0]); 
            Console.WriteLine(arr[2]); 
        }
    }
}
