using System;
using System.Collections.Generic;
using System.Text;

namespace Tarefa7.Entities
{
    public class Funcionario
    {
        public string Nome { get; private set; }
        public double VendaBrutal { get; private set; }
        public double SalarioFixo { get; private set; }

        public Funcionario(string nome ,double vdBrutal)
        {
            Nome = nome;
            VendaBrutal = vdBrutal;
            SalarioFixo = 200;
        }
        
        public Funcionario(string nome ,double vdBrutal,double salFixo) 
        {
            Nome = nome;
            VendaBrutal = vdBrutal;
            SalarioFixo = salFixo;
        }

        public double Total()
        {
            var vdLiqui = VendaBrutal * 0.09;
            return SalarioFixo + vdLiqui;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("====================================");
            sb.AppendLine("<FOLHA DE PAGAMENTO>");
            sb.AppendLine($"|Nome: {Nome}");
            sb.AppendLine($"|Total: {Total().ToString("C")}");

            return sb.ToString();
        }

    }
}
