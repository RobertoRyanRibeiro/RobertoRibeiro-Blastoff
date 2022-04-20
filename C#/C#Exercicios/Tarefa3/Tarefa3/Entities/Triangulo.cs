﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tarefa3.Entities
{
    public class Triangulo
    {

        public string Result { get; private set; }
        public double[] Lados { get; private set; }

        public Triangulo(params double[] lados)
        {
            Lados = new double[3];
            Lados[0] = lados[0];
            Lados[1] = lados[1];
            Lados[2] = lados[2];
        }

        public void OrganizandoLados()
        {
            //Auxiliar
            double aux;

            Console.Clear();
            //Organizando do maior para o menor
            for (var current = 0; current < Lados.Length; current++)
            {
                for (var prox = current + 1; prox <= Lados.Length - 1; prox++)
                {
                    if (Lados[prox] > Lados[current])
                    {
                        aux = Lados[current];
                        Lados[current] = Lados[prox];
                        Lados[prox] = aux;
                    }
                }
            }

            //Imprimindo os lados em ordem
            Console.WriteLine("Ordem de Maior para menor");
            Console.WriteLine("=========================");
            Console.Write("| ");
            for (var cont = 0; cont < 3; cont++)
            {
                Console.Write($"{Lados[cont]} | ");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Analisar()
        {
            //Verificando se é um triangulo
            Console.WriteLine(" ");
            if (Lados[0] < Lados[1] + Lados[2])
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Result = "+As retas formam um triangulo+";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Result = "-As retas não formam um triangulo-";
            }
        }

        public override string ToString()
        {
            return Result;
        }
    }
}
