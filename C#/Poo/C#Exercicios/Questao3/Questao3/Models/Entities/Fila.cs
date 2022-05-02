using System;
using System.Collections.Generic;
using System.Text;

namespace Questao3.Models.Entities
{
    public class Fila
    {
        public Fila(char letra, uint quantidadeAssentos)
        {
            Letra = letra;
            QuantidadeAssentos = quantidadeAssentos;
            AddAssentos();
        }

        public char Letra { get; private set; }
        public List<Assento> Assentos { get; private set; } = new List<Assento>();
        public uint QuantidadeAssentos { get; private set; }

        void AddAssentos()
        {
            for(uint cont = 1; cont <= QuantidadeAssentos; cont++)
            {
                Assentos.Add(new Assento(Letra,cont));
            }
        }

        public int QuantidadeTotalAssentosLivres()
        {
            var cont = 0;
            foreach (var assento in Assentos)
            {
                if (assento.EstaReservado == false)
                    cont++;
            }
            return cont;
        }

        public string ImprimirDados()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"|Fila - {Letra}");

            return sb.ToString();
        }

        public void Draw()
        {
            foreach(var assento in Assentos)
            {
                assento.Draw();
            }
        }

    }
}
