using System;
using System.Collections.Generic;
using System.Text;

namespace Questao11.Models.Entities
{
    public class ContratoPessoaJuridica : Contrato
    {
        public ContratoPessoaJuridica(int numero, string contratante, float valor, int prazo,string cnpj,string ieec) : base(numero, contratante, valor, prazo)
        {
            CNPJ = cnpj;
            IEEC = ieec;
        }

        public string CNPJ { get; private set; }
        //##.###.###-#
        public string IEEC { get; private set; }

        public override void CalcularPrestacao()
        {
            base.CalcularPrestacao();
            ValorPrestacao += 3;
        }

        public override void ExibirInfo()
        {
            base.ExibirInfo();
            Console.WriteLine(" = DADOS EXTRA =");
            Console.WriteLine($"|CPNJ - {CNPJ}");
            Console.WriteLine($"|IEEC - {IEEC}");
        }

    }
}
