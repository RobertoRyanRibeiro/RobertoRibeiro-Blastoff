using System;

namespace InterpolacaoString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var price = 10.2 + 9;
            //var price = 10.2;
            //var texto = "O preço do produto é" + price;

            //var price = 10.2;
            //var texto = "O preço do produto é" + price + "apena na promoção";

            var price = 10.2;
            //var texto = string.Format("O preço do produto é {0} apenas na promoção",price);
            //var texto = string.Format("O preço do produto é {0} apenas na promoção {1}",price,true);
            //var texto = string.Format("O preço do produto é {1} apenas na promoção {0}",price,true);
            //var texto = string.Format("O preço do produto é {1} apenas na promoção {0}",price); -> Error sem valores suficientes
            
            var texto = $"O preço do produto é {price} apenas na promoção";
            /*var texto = $"O preço do produto é {price}
            apenas na promoção                            => Error n entende quebra de linha sem @
            */
            texto = $@"O preço do produto é {price}
            apenas na promoção";
            
            //@ Identifica Regex e Caracters excluindo por exempl \n
            texto = @"O preço do produto é 
            apenas na promoção";

            Console.WriteLine(texto);
        }
    }
}
