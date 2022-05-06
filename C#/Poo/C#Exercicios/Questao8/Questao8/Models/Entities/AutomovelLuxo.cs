using System;
using System.Collections.Generic;
using System.Text;

namespace Questao8.Models.Entities
{
    public class AutomovelLuxo : Automovel
    {


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
            HasArCondicionado = true;
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
                valor += arCondicionado;
            if (HasDirecaoHidralica)
                valor += dirHidralica;
            if (HasVidroEletrico)
                valor += vidroEletrico;
        }


        public override void ImprimirDados()
        {
            base.ImprimirDados();
            Console.WriteLine(" = Componentes =");
            if (HasArCondicionado)
                Console.WriteLine("Ar-condicionado");
            if (HasDirecaoHidralica)
                Console.WriteLine("Direção Hidralica");
            if (HasVidroEletrico)
                Console.WriteLine("Vidro Eletrico");
        }
    }
}
