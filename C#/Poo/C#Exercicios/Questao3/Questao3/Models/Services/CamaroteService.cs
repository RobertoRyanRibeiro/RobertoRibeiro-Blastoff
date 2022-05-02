using System;
using System.Collections.Generic;
using System.Text;
using Questao3.Models.Entities;

namespace Questao3.Models.Services
{
    public static class CamaroteService
    {
        private static int op;

        public static void DesenharCamarote(Camarote camarote)
        {
            foreach (var fila in camarote.Filas)
            {
                fila.Draw();
                Console.WriteLine("");
            }

        }

        public static void Navegar(ConsoleKey  key)
        {
            if (key == ConsoleKey.RightArrow)

                if (key == ConsoleKey.LeftArrow)

                    if (key == ConsoleKey.UpArrow)

                        if (key == ConsoleKey.DownArrow) ;

        }

        private static Assento AcharLocal(Assento local, Camarote camarote)
        {
            //Local
            var lc = new Assento();
            foreach (var fila in camarote.Filas)
            {
                if (local.Letra == fila.Letra)
                {
                    foreach (var assento in fila.Assentos)
                    {
                        if (local.Numero == assento.Numero)
                        {
                            assento.AdicionarReservar();
                            lc = assento;
                        }
                    }

                }
            }
            return lc;
        }

    }
}
