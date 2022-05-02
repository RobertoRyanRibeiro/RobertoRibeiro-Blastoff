using System;
using System.Collections.Generic;
using System.Text;

namespace Questao3.Models.Entities
{
    public class CamaroteSuperior : Camarote
    {
        public CamaroteSuperior(string nome, uint quantidadeFilas, uint quantidadeAssentoPorFilas) : base(nome, quantidadeFilas, quantidadeAssentoPorFilas)
        {
            TipoIngressoAcesso = Enum.ETipoIngresso.VIP_Camarote_Superior;
        }
    }
}
