using System;
using System.Collections.Generic;
using System.Text;

namespace Questao3.Models.Entities
{
    public class CamaroteInferior : Camarote
    {
        public CamaroteInferior(string nome, uint quantidadeFilas, uint quantidadeAssentoPorFilas) : base(nome, quantidadeFilas, quantidadeAssentoPorFilas)
        {
        }
    }
}
