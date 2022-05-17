using System;
using System.Collections.Generic;
using System.Text;

namespace Questao8.Models.Entities
{
    public class AutomovelLuxo : Automovel
    {


        private double totalExtra = 0;
        private double total = 0;

        public bool HasArCondicionado { get; private set; } = false;
        const double arCondicionado = 2000;


        public bool HasDirecaoHidralica { get; private set; } = false;
        const double dirHidralica = 1500;


        public bool HasVidroEletrico { get; private set; } = false;
        const double vidroEletrico = 800;

        public AutomovelLuxo(string placa, string modelo, string cor, short ano, byte combustivel) : base(placa, modelo, cor, ano, combustivel)
        {
        }


        public void SwitchArcondicionado()
        {
            HasArCondicionado = !HasArCondicionado;
        }
        public void SwitchDirecaoHidralica()
        {
            HasDirecaoHidralica = !HasDirecaoHidralica;
        }
        
        public void SwitchVidroEletrico()
        {
            HasVidroEletrico = !HasVidroEletrico;
        }

        public void Reset()
        {
            HasArCondicionado = false;
            HasDirecaoHidralica = false;
            HasVidroEletrico = false;
        }

        public override void CalcularValor()
        {
            base.CalcularValor();

            if (HasArCondicionado)
                totalExtra += arCondicionado;
            if (HasDirecaoHidralica)
                totalExtra += dirHidralica;
            if (HasVidroEletrico)
                totalExtra += vidroEletrico;
            total = valor + totalExtra;
        }


        public override void ImprimirDados()
        {
            base.ImprimirDados();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" = Componentes =");
            Console.ForegroundColor = ConsoleColor.White; 
            if (HasArCondicionado)
                Console.WriteLine("|Ar-condicionado : Adicional($2.000)");
            if (HasDirecaoHidralica)
                Console.WriteLine("|Direção Hidralica : Adicional($1.500)");
            if (HasVidroEletrico)
                Console.WriteLine("|Vidro Eletrico : Adicional($800)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" = Total =");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"|Total Extras - {totalExtra:C}");
            Console.WriteLine($"|Valor Total - {total:C}");
        }
    }
}
