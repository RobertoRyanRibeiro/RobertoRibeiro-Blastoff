using System;
using System.Collections.Generic;
using System.Text;
using Questao3.Models.Entities;
using Questao3.Viewers;
using Questao3.Models.Entities.Enum;
using System.Threading;

namespace Questao3.Models.Services
{
    public static class CamaroteService
    {
        static int filas;
        static int assentos;
        static string[,] matrix;

        static int x = 0;
        static int y = 0;

        static Ingresso ingresso;
        static Camarote camarote;
        static Fila fila;
        static Assento assento;
        static User User = Season.User;


        public static void Navegar(Camarote cam, Ingresso ing)
        {
            ingresso = ing;
            camarote = cam;
            filas = camarote.QuantidadeFilas;
            assentos = camarote.QuantidadeAssentoPorFilas;
            matrix = new string[filas, assentos];

            int contFil = 0;
            foreach (var fila in camarote.Filas)
            {
                int contCad = 0;
                foreach (var ast in fila.Assentos)
                {
                    matrix[contFil, contCad] = ast.GetDado();
                    if (contCad < assentos)
                        contCad++;
                }
                contFil++;
            }

            ConsoleKey key;
            Console.Clear();
            Desenhar();
            do
            {
                DesenharMarca();
                key = Selecionar();
            } while (key != ConsoleKey.Enter);

            AcharLocal(matrix[y, x]);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        static ConsoleKey Selecionar()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            //Console.WriteLine(matrix[y, x]);
            Console.ForegroundColor = ConsoleColor.White;
            ConsoleKey key = Console.ReadKey().Key;

            if (key == ConsoleKey.RightArrow)
                x++;

            if (key == ConsoleKey.LeftArrow)
                x--;

            if (key == ConsoleKey.UpArrow)
                y--;

            if (key == ConsoleKey.DownArrow)
                y++;

            if (x == assentos)
                x = assentos - 1;

            if (y == filas)
                y = filas - 1;

            if (x < 0)
                x = 0;

            if (y < 0)
                y = 0;
            return key;
        }

        static void AcharLocal(string local)
        {
            //Local
            foreach (var fila in camarote.Filas)
            {
                var letra = local.Substring(0, 1);
                var numero = local.Substring(1);
                if (char.Parse(letra) == fila.Letra)
                {
                    foreach (var ast in fila.Assentos)
                    {
                        if (int.Parse(numero) == ast.Numero)
                        {
                            assento = ast;
                            MarcaAssento(letra, int.Parse(numero));
                        }
                    }
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Resolucao();
            UserOpMenu.View();
        }
        static void Resolucao()
        {
            Console.Clear();
            IngressoService.ErrorTreatment(ingresso);
            User.ComprarIngresso(ingresso);
            Thread.Sleep(1000);
        }

        static void MarcaAssento(string letra, int numero)
        {
            if (numero == assento.Numero)
            {
                if (User.Ingresso == null)
                {
                    if (camarote.TipoIngressoAcesso == ETipoIngresso.VIP_Camarote_Inferior)
                        ingresso = new IngressoCamaroteInferior(15, assento);
                    
                    if (camarote.TipoIngressoAcesso == ETipoIngresso.VIP_Camarote_Superior)
                        ingresso = new IngressoCamaroteSuperior(20, assento);
                }
                else
                {
                    if (User.Ingresso.Tipo != ETipoIngresso.VIP_Camarote_Inferior)
                    {
                        if (camarote.TipoIngressoAcesso == ETipoIngresso.VIP_Camarote_Inferior)
                            ingresso = new IngressoCamaroteInferior(15, assento);
                    }
                    if (User.Ingresso.Tipo != ETipoIngresso.VIP_Camarote_Superior)
                    {
                        if (camarote.TipoIngressoAcesso == ETipoIngresso.VIP_Camarote_Superior)
                            ingresso = new IngressoCamaroteSuperior(20, assento);
                    }
                }
            }
        }

        static void Desenhar()
        {
            foreach (var fila in camarote.Filas)
            {
                fila.Draw();
                Console.WriteLine("");
            }
        }
        static void DesenharMarca()
        {
            foreach (var fila in camarote.Filas)
            {
                foreach (var ast in fila.Assentos)
                {
                    if (matrix[y, x] == ast.GetDado())
                    {
                        Console.SetCursorPosition(ast.Xpos, ast.Ypos);
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine(" ");
                    }
                    else
                    {
                        Console.SetCursorPosition(ast.Xpos, ast.Ypos);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine(" ");
                    }
                }
            }
        }
    }
}
