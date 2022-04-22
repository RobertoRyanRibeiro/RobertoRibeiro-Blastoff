using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Tarefa7.Entities
{
    public class Funcionario
    {
        public string Nome { get; private set; }
        public double VendaBrutal { get; private set; }
        public double SalarioFixo { get; private set; }



        public Funcionario(string nome ,double vdBrutal)
        {
            Regex regex = new Regex(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ][A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ\s]*$");
            Match match = regex.Match(nome);

            if (!match.Success)
                throw new ArgumentException("Formatação de Nome Invalido");

            if (vdBrutal < 0)
                throw new ArgumentException("Valor Negativo");


            Nome = nome;
            VendaBrutal = vdBrutal;
            SalarioFixo = 200;
        }
        
        public Funcionario(string nome ,double vdBrutal,double salFixo) 
        {
            if (vdBrutal < 0 || salFixo < 0)
                throw new ArgumentException("Valor Negativo");

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
