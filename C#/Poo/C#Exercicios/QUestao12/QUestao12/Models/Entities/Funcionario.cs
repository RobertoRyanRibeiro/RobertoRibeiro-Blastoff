using System;
using System.Collections.Generic;
using System.Text;

namespace Questao12.Models.Entities
{
    public class Funcionario
    {
        public Funcionario(string nome, string cpf, double salario)
        {
            Nome = nome;
            Cpf = cpf;
            Salario = salario;
        }

        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public double Salario { get; private set; }

        protected double Total { get; set; }

        public virtual void CalcularBonificacao()
        {

        }

        public virtual void ExibirInfo()
        {
            Console.Clear();
            Console.WriteLine(" = Dados =");
            Console.WriteLine($"|Nome - {Nome}");
            Console.WriteLine($"|CPF - {Cpf}");
            Console.WriteLine($"|Salario - {Salario:C}");
            Console.WriteLine($"|Salario Total - {Total:C}");
        }

    }
}
