using System;
using System.Collections.Generic;
using System.Text;
using Questao3.Models.Entities.Enum;

namespace Questao3.Models.Entities
{
    public abstract class Camarote
    {
        protected Camarote(string nome, uint quantidadeFilas,uint quantidadeAssentoPorFilas)
        {
            Nome = nome;
            ID = Guid.NewGuid();
            QuantidadeFilas = quantidadeFilas;
            QuantidadeAssentoPorFilas = quantidadeAssentoPorFilas;
            TipoIngressoAcesso = ETipoIngresso.VIP_Camarote_Inferior;
            AddFila();
        }

        public string Nome { get; private set; }
        public Guid ID { get; }
        public List<Fila> Filas { get; private set; } = new List<Fila>();
        public uint QuantidadeFilas { get; private set; }
        public uint QuantidadeAssentoPorFilas { get; private set; }
        public ETipoIngresso TipoIngressoAcesso { get; protected set; }

        public void MudarNome(string nome)
        {
            Nome = nome;
        }

        void AddFila()
        {
            var letra = 'A';
            for(uint cont = 0; cont < QuantidadeFilas; cont++)
            {
                Filas.Add(new Fila(letra, QuantidadeAssentoPorFilas));
                letra++;
            }
        }

        public int QuantidadeTotalAssentosLivres()
        {
            var cont = 0;
            foreach(var fila in Filas)
            {
                cont += fila.QuantidadeTotalAssentosLivres();
            }
            return cont;
        }

    }
}
