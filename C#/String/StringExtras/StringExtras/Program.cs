using System;

namespace StringExtras
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Guid
            var id = Guid.NewGuid();
            id = new Guid();
            Console.WriteLine(id);
            
            //Format
            var price = 10.2;
            var text = "O preço do produto é " + price;
            Console.WriteLine(text);

            text = string.Format("O preço do produto é {0}", price);
            Console.WriteLine(text);

            //Comparação
            text = "Testando";
            Console.WriteLine(text.CompareTo("Testando"));
            Console.WriteLine(text.CompareTo("testando"));
            text = "Este texto é um teste";
            Console.WriteLine(text.Contains("testando"));
            Console.WriteLine(text.Contains("test"));
            
            //Ignorando CaseSensitive
            Console.WriteLine(text.Contains("test",StringComparison.OrdinalIgnoreCase));
            
            //StartWith() & EndWith()
           
            //Equals
            text = "Testando";
            Console.WriteLine(text.Equals("testando"));
            Console.WriteLine(text.Equals("Testando"));

            //IndexOf
            text = "Testando";
            Console.WriteLine(text.IndexOf("t"));
            Console.WriteLine(text.LastIndexOf("s"));

            //ToUpper & ToLower

            //Insert
            Console.WriteLine(text.Insert(5,"Aqui"));
            Console.WriteLine(text.Remove(2,3));

            //Replace
            Console.WriteLine(text.Replace("e", "X"));
            
            //Split
            var div = text.Split("e");
            Console.WriteLine(div[0]);
            Console.WriteLine(div[1]);

            //Substring

            //Trim : Remove os espaços do começo e fim
        }
    }
}
