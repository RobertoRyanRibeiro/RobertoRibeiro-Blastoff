using System;
using System.Collections.Generic;
using System.Text;

namespace Questao10.Models.Entities
{
    public class ContaEstudante : Compra
    {
        public ContaEstudante(double preco, int parcelas, string tipo) : base(preco, parcelas, tipo)
        {
        }

        public override void PagarParcela(int parcelas)
        {
            base.PagarParcela(parcelas);
        }

        public override void QuitarCompra()
        {
            base.QuitarCompra();
        }

        public void Especial(Object obj)
        {
            
            if (obj.GetType() == typeof(Compra))
            {
                var aux = (Compra)obj;
                Preco += aux.Preco;
                Parcelas += aux.Parcelas;
                SetValores();
            }
            else if(obj.GetType() == typeof(ContaEstudante))
            {
                var aux = (ContaEstudante)obj;
                Preco = Preco/2;
                Parcelas = Parcelas/2;
                SetValores();
            }
        }

    }
}
