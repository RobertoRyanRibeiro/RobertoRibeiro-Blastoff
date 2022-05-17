using System;
using System.Collections.Generic;
using System.Text;

namespace Questao12.Models.Entities
{
    public class Gerente : Funcionario
    {
        public Gerente(string nome, string cpf, double salario,float senhaEspecial,int qtdFuncionario) : base(nome, cpf, salario)
        {
            SenhaEspecial = senhaEspecial;
            QtdFuncionario = qtdFuncionario;
        }

        public float SenhaEspecial { get; private set; }
        public int QtdFuncionario { get; private set; }

        public override void CalcularBonificacao()
        {
            Total = Salario + Salario * 10 / 100;
        }

        public override void ExibirInfo()
        {
            base.ExibirInfo();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" == Extra ==");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"|SenhaEspecial - {SenhaEspecial}");
            Console.WriteLine($"|QtdFuncionario - {QtdFuncionario}");
        }

    }
}
