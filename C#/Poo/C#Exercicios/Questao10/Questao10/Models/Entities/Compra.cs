using System;
using System.Collections.Generic;
using System.Text;
using Questao10.Models.Enum;

namespace Questao10.Models.Entities
{
    public class Compra
    {
        public double Preco { get; protected set; }
        public int Parcelas { get; protected set; }
        public string Tipo { get; private set; }
        public EStatus Status { get; private set; } 


        public double ValorParcela { get; private set; } 
        public double Total { get; private set; } 
        public double Juros { get; private set; } 

        public Compra(double preco, int parcelas, string tipo)
        {
            Preco = preco;
            Parcelas = parcelas;
            Tipo = tipo;
            Status = EStatus.Pendente;
            SetValores();
        }

        protected void SetValores()
        {
            ValorParcela = Preco / Parcelas;
            Total = Preco;
        }

        public virtual void PagarParcela(int parcelas)
        {
            Parcelas -= parcelas;
            Total -= ValorParcela * parcelas;
        }
        
        public virtual void QuitarCompra()
        {
            Console.WriteLine("|Compra Finalizada");
            Status = EStatus.Finalizada;
            Parcelas = 0;
            Total = 0;
            ValorParcela = 0;
        }

        public void CancelarCompra()
        {
            Console.WriteLine("|Compra Cancelada");
            Status = EStatus.Cancelada;
            Parcelas = 0;
            Total = 0;
            ValorParcela = 0;
        }

        public void AtualizarParcela(double juros, int qtdParcelas)
        {
            Juros = juros;
            Preco = Total + (Total * juros * qtdParcelas);
            Parcelas = qtdParcelas;
            SetValores();
            Console.Clear();
            Console.WriteLine($"|Juros aplicado de {juros*100}%");
            Console.WriteLine("|Parcelas atualizadas e Valor Ajustado");
        }

        public void ImprimirDados()
        {
            Console.WriteLine(" = Compra =");
            Console.WriteLine($"|Preco - {Preco:C}");
            Console.WriteLine($"|Parcelas - {Parcelas}");
            Console.WriteLine($"|Tipo - {Tipo}");
            Console.WriteLine($"|Status - {Status}");
            Console.WriteLine(" = Parcelas & Total =");
            Console.WriteLine($"|Valor por Parcela - {ValorParcela:C}");
            Console.WriteLine($"|Total atual da Conta - {Total:C}");
            if(Juros != 0)
                Console.WriteLine($"|O ultimo juros aplicado foi de {Juros*100}%");
        }
    }
}
