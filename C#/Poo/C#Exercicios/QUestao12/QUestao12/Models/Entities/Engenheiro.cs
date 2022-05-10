using System;
using System.Collections.Generic;
using System.Text;

namespace Questao12.Models.Entities
{
    public class Engenheiro : Funcionario
    {
        public Engenheiro(string nome, string cpf, double salario,string crea,string categoria,string projeto) : base(nome, cpf, salario)
        {
            Crea = crea;
            Categoria = categoria;
            ProjetoAtual = projeto;
        }

        public string Crea { get; private set; }
        public string Categoria { get; private set; }
        public string ProjetoAtual { get; private set; }

        public override void CalcularBonificacao()
        {
            Total = Salario + Salario * 5 / 100;
        }

        public override void ExibirInfo()
        {
            base.ExibirInfo();
            Console.WriteLine($"|Crea - {Crea}");
            Console.WriteLine($"|Categoria - {Categoria}");
            Console.WriteLine($"|Projeto - {ProjetoAtual}");
        }

    }
}
