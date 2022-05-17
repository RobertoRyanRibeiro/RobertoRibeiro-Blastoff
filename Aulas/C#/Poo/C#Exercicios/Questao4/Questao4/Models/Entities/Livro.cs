using System;
using System.Collections.Generic;
using System.Text;

namespace Questao4.Models.Entities
{
    public class Livro
    {

        public Livro() { }

        public Livro(string titulo, int quantidadePag, string isbn)
        {
            Titulo = titulo;
            QuantidadePag = quantidadePag;
            ISBN = isbn;
        }

        public string Titulo { get; private set; }
        public int QuantidadePag { get; private set; }
        public string ISBN { get; private set; }


        public string ExibirDados()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"|Titulo - {Titulo}");
            sb.AppendLine($"|Quantidade de Paginas - {QuantidadePag}");
            sb.AppendLine($"|ISBN - {ISBN}");

            return sb.ToString();
        }

    }
}
