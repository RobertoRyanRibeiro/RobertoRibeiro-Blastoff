using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace Tarefa5.Entities
{
    public class FolhaPagamento
    {
        private CultureInfo ptBr = CultureInfo.CreateSpecificCulture("pt-BR");
        public double HrTrab { get; private set; }
        public double ValorHr { get; private set; }
        public double SalBruto { get; private set; }
        public double SalLiquido { get; private set; }
        public double TotalDesc { get; private set; }
        public double IR { get; private set; }
        public double INSS { get; private set; }
        public double Sindicato { get; private set; }
        public double FGTS { get; private set; }

        public FolhaPagamento(double hrTrab, double valorHr)
        {
            //Negativo
            if (hrTrab < 0 && valorHr < 0)
                throw new ArgumentException("Os Valores não podem ser Negativo...");
            if (hrTrab < 0)
                throw new ArgumentException("A hora de trabalho não pode ser Negativa...");
            if (valorHr < 0)
                throw new ArgumentException("O valor por hora não pode ser Negativa...");
            //Zero
            if (hrTrab == 0 && valorHr == 0)
                throw new ArgumentException("Os Valores não podem ser zero...");
            if (hrTrab == 0)
                throw new ArgumentException("A hora de trabalho não pode ser zero...");
            if (valorHr == 0)
                throw new ArgumentException("O valor por hora não pode ser zero...");

            HrTrab = hrTrab;
            ValorHr = valorHr;
            SalBruto = ValorHr * HrTrab;
        }

        public void CalcularSalLiquido()
        {
                //IR
                if (SalBruto <= 900)
                    IR = 0;
                else if (SalBruto <= 1500)
                    IR = SalBruto * 0.05;
                else if (SalBruto <= 2500)
                    IR = SalBruto * 0.1;
                else if (SalBruto > 2500)
                    IR = SalBruto * 0.2;

            //INSS
            INSS = SalBruto * 0.1;

            //Sindicato
            //Sindicato = SalBruto * 0.03;

            //FGTS
            FGTS = SalBruto * 0.11;

            //Total Desc
            TotalDesc = IR + INSS + Sindicato;

            //SalLiquido
            SalLiquido = SalBruto - TotalDesc;
        }

        public override string ToString()
        {
            Console.Clear();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<FOLHA DE PAGAMENTO>");
            sb.AppendLine($"|Valor da Hora: {ValorHr.ToString("C", ptBr)}");
            sb.AppendLine($"|Horas Trabalhadas: {HrTrab}H");
            sb.AppendLine($"|Salario Bruto: {SalBruto.ToString("C", ptBr)}");
            sb.AppendLine($"|IR: {IR.ToString("C", ptBr)}");
            sb.AppendLine($"|INSS: {INSS.ToString("C", ptBr)}");
            //sb.AppendLine($"|Sindicato: {Sindicato.ToString("C",ptBr)}");
            sb.AppendLine($"|FGTS: {FGTS.ToString("C", ptBr)}");
            sb.AppendLine($"|Total de Desconto: {TotalDesc.ToString("C", ptBr)}");
            sb.AppendLine($"|Salario Liquido: {SalLiquido.ToString("C", ptBr)}");

            return sb.ToString();
        }
    }
}
