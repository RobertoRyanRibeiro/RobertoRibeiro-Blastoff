using System;
using System.Collections.Generic;
using System.Text;
using Questao4.Models.Entities;

namespace Questao4
{
    public static class Biblioteca
    {
        public static List<Livro> Livros { get; private set; } = new List<Livro>();
        //BookWithTheMostPages 
        static Livro MaiorLivroPorPag { get; set; } = new Livro("DefaultMaior", 0, "000-00-00000-00-0");
        //BookWithTheLessPages
        static Livro MenorLivroPorPag { get; set; } = new Livro("DefaultMaior", int.MaxValue, "000-00-00000-00-0");


        public static void ListarLivros()
        {
            Livros.Sort((x, y) => y.QuantidadePag.CompareTo(x.QuantidadePag));
            foreach (var livro in Livros)
            {
                Console.WriteLine(livro.ExibirDados());
            }
        }

        public static void ExibirMaiorEMenor()
        {
            Console.WriteLine(MaiorLivroPorPag.ExibirDados());
            Console.WriteLine("");
            Console.WriteLine(MenorLivroPorPag.ExibirDados());
        }

        public static void AddLivro(Livro livro)
        {
            if (livro.QuantidadePag > MaiorLivroPorPag.QuantidadePag)
                MaiorLivroPorPag = livro;

            if (livro.QuantidadePag < MenorLivroPorPag.QuantidadePag)
                MenorLivroPorPag = livro;

            Livros.Add(livro);
        }

        public static void RemoverLivro(Livro livro)
        {
            Livros.Remove(livro);
        }
    }
}
