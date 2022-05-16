using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Questao6.Viewers;

namespace Questao6.Models.Entities
{
    public class ArrayMatriz
    {

        const int linha = 3;
        const int coluna = 4;
        float[,] array = new float[linha, coluna];
        public bool isNotEmpty = false;

        public void AddValues()
        {
            Console.Clear();
            isNotEmpty = true;
            for (var l = 0; l < linha; l++)
            {
                for (var c = 0; c < coluna; c++)
                {
                    var rng = new Random();
                    array[l, c] = rng.Next(0, 51);
                }
            }
        }

        public void ShowValues()
        {
            for (var l = 0; l < linha; l++)
                for (var c = 0; c < coluna; c++)
                {
                    Console.WriteLine($"|{c + 1}º Valor - {array[l, c]}");
                }
        }

        public float Sum()
        {
            var sum = 0.0f;
            for (var l = 0; l < linha; l++)
                for (var c = 0; c < coluna; c++)
                {
                    sum += array[l, c];
                }
            return sum;
        }

        public void MajorAndMinor()
        {
            var major = 0.0f;
            var minor = float.MaxValue;
            for (var l = 0; l < linha; l++)
                for (var c = 0; c < coluna; c++)
                {
                    if (array[l, c] > major)
                        major = array[l, c];
                    if (array[l, c] < minor)
                        minor = array[l, c];
                }
            Console.WriteLine("==== Maior & Menor ====");
            Console.WriteLine($"|Maior - {major}");
            Console.WriteLine($"|Menor - {minor}");
        }

        public float Media()
        {
            var media = Sum() / array.Length;
            return media;
        }
    }
}
