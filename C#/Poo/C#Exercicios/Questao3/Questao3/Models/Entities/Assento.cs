using System;
using System.Collections.Generic;
using System.Text;

namespace Questao3.Models.Entities
{
    public class Assento
    {
        public Assento() { }
        public Assento(char letra, uint numero)
        {
            Letra = letra;
            Numero = numero;
            EstaReservado = false;
        }

        public bool EstaReservado { get; private set; }
        public char Letra { get; private set; }
        public uint Numero { get; private set; }

        public void AdicionarReservar()
        {
            EstaReservado = true;
        }

        public void RemoverReserva()
        {
            EstaReservado = false;
        }
        public string ImprimirDados()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"|Fila:Letra - {Letra}");
            sb.AppendLine($"|Numero - {Numero}");
            sb.AppendLine($"|Assento - {Letra}{Numero}");

            return sb.ToString();
        }

        public void Draw()
        {
            if (EstaReservado)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"[{Letra}{Numero}]");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"[{Letra}{Numero}]");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }


    }
}
