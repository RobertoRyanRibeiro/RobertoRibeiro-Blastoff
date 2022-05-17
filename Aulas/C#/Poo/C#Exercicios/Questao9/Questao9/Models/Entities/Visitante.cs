using System;
using System.Collections.Generic;
using System.Text;

namespace Questao9.Models.Entities
{
    public class Visitante
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public byte CodTema { get; private set; }

        public int Quant{ get; private set; }

        public static byte Vintage = 1;
        public static byte Numismatica = 2;
        public static byte Historia_Da_Musica = 3;
        public static byte Pinturas = 4;
        public static byte Escultura = 5;

        public bool CountVintage { get; private set; } = false;
        public bool CountNumismatica { get; private set; } = false;
        public bool CountHistoria { get; private set; } = false;
        public bool CountPinturas { get; private set; } = false;
        public bool CountEscultura { get; private set; } = false;


        public Visitante(string nome,string cpf,DateTime dateTime,byte codTema)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dateTime;
            CodTema = codTema;
            Quant = 0;
        }

        public void SwitchVintage()
        {
            CountVintage = !CountVintage;
        }public void SwitchNumismatica()
        {
            CountNumismatica = !CountNumismatica;
        }public void SwitchHistoria()
        {
            CountHistoria = !CountHistoria;
        }public void SwitchPintura()
        {
            CountPinturas = !CountPinturas;
        }public void SwitchEscultura()
        {
            CountEscultura = !CountEscultura;
        }

        public void Reset()
        {
            CountVintage = false;
            CountNumismatica = false;
            CountHistoria = false;
            CountPinturas = false;
            CountEscultura = false;
        }

        public void CalcularItens()
        {
            if (CountVintage)
                Quant += 135;
            if (CountNumismatica)
                Quant += 300;
            if (CountHistoria)
                Quant += 67;
            if (CountPinturas)
                Quant += 72;
            if (CountEscultura)
                Quant += 46;
        }

        public virtual void ImprimirDados()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" = Visitante =");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"|Nome - {Nome}");
            Console.WriteLine($"|Cpf - {Cpf}");
            Console.WriteLine($"|Data Nascimento - {DataNascimento:dd/MM/yyyy}");
            Console.WriteLine($"|Cod Tema - {CodTema}");
            Console.WriteLine($"|Quantidade de Obras - {Quant}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" = Tema =");
            Console.ForegroundColor = ConsoleColor.White;
            if (CodTema == Vintage)
                Console.WriteLine("|Vintage");
            if (CodTema == Numismatica)
                Console.WriteLine("|Numismatica");
            if (CodTema == Historia_Da_Musica)
                Console.WriteLine("|Historia da Musica");
            if (CodTema == Pinturas)
                Console.WriteLine("|Pinturas");
            if (CodTema == Escultura)
                Console.WriteLine("|Escultura");
        }
    }
}
