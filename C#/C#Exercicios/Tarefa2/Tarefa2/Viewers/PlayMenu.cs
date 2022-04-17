﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Tarefa2.Entities;
using Tarefa2.Entities.Exceptions;

namespace Tarefa2.Viewers
{
    public class PlayMenu
    {
        //Partida
        public static bool Confirmed { get; private set; }


        public static void MenuScreen(GambleMatch gambleMatch)
        {
            //DrawView
            DrawScreen();
            //Logic
            ControlerScreen(gambleMatch);
        }

        //Desenhando a Tela
        private static void DrawScreen()
        {
            //Resetando Config
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            //Desenhando a Tela
            TopBottomMenu();
            MiddleMenu();
            TopBottomMenu();

        }

        //Logica do Menu
        private static void ControlerScreen(GambleMatch gambleMatch)
        {
            Confirmed = false;
            int op = 0;
            //Colocando o Curso Invisivel
            Console.CursorVisible = false;

            do
            {
                //Exibindo as Opções
                WriteOp(op);
                op = SelectOption(op, Console.ReadKey().Key);
            } while (!Confirmed);

            HandleOptionsMenu(op, gambleMatch);
        }

        //Escrevendo as Opções
        private static void WriteOp(int op)
        {
            //Colunas
            var colunaOP = 3;
            var colunaSeta = 1;
            //Linhas por Op
            var linhaOp = new int[2] { 5, 7 };
            //Menu
            //Title
            Console.SetCursorPosition(3, 2);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{"Readyyy!!!",10}");
            Console.ForegroundColor = ConsoleColor.White;
            //OP
            Console.SetCursorPosition(colunaOP, linhaOp[0]);
            Console.Write("   Play");
            Console.SetCursorPosition(colunaOP, linhaOp[1]);
            Console.Write("   Back");
            switch (op)
            {
                case 0:
                    Console.SetCursorPosition(colunaSeta, linhaOp[0]);
                    Console.Write("  =>");
                    break;
                case 1:
                    Console.SetCursorPosition(colunaSeta, linhaOp[1]);
                    Console.Write("  =>");
                    break;
            }
            //Colocando o mouse fora do menu
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("Press Esc To Exit The Application");
            Console.ForegroundColor = ConsoleColor.Black;
        }

        //Movendo a Seta
        private static int SelectOption(int op, ConsoleKey selection)
        {
            //Recebendo a Opção Atual
            var aux = op;

            //Movendo a Seta
            if (selection == ConsoleKey.DownArrow)
                aux++;
            if (selection == ConsoleKey.UpArrow)
                aux--;

            //Verificando se chegou no Max ou Min das Op
            if (aux > 1)
                aux = 0;
            if (aux < 0)
                aux = 1;

            //Verificando se o Enter foi Clicado
            if (selection == ConsoleKey.Enter)
                Confirmed = true;

            //Verificando se o Enter foi Clicado
            if (selection == ConsoleKey.Escape)
            {
                Console.ForegroundColor = ConsoleColor.White;
                System.Environment.Exit(0);
            }

            return aux;
        }

        //Verificando oque cada Opção faz
        private static void HandleOptionsMenu(int op, GambleMatch gambleMatch)
        {
            try
            {
                switch (op)
                {
                    case 0:
                        gambleMatch.Start();
                        PlayMatch(gambleMatch);
                        break;
                    case 1:
                        Menu.MenuScreen(gambleMatch.player);
                        break;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error:");
                Console.WriteLine(ex.Message);
            }
            catch (ExceptionAboveLimitGamble ex)
            {
                Console.WriteLine("Error:");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Thread.Sleep(1000);
                PlayMenu.MenuScreen(gambleMatch);
            }
        }

        //Desenhando Parte de cima do Menu
        private static void TopBottomMenu()
        {
            Console.Write("+");
            for (int i = 0; i <= 30; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine("+");
        }

        //Desenhano a Parte de Baixo do Menu
        private static void MiddleMenu()
        {
            for (int l = 0; l <= 10; l++)
            {
                Console.Write("|");
                for (int i = 0; i <= 30; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("|");
            }
        }

        private static void PlayMatch(GambleMatch gambleMatch)
        {

            var value = 0;
            while (gambleMatch.player.Life > 0 && !gambleMatch.Win)
            {
                //Setando Tela
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();

                Console.WriteLine($"|LimitMax : {gambleMatch.MaxLimiter}");
                Console.WriteLine($"|Lives: {gambleMatch.player.Life}");
                Console.WriteLine("=========================");
                Console.Write("|What's The Number::");
                value = int.Parse(Console.ReadLine());
                Console.WriteLine("");

                //Tratamento
                if (value < 0)
                {
                    throw new ExceptionPlayGame("The value is wrong.");
                }

                gambleMatch.Play(value);
                Thread.Sleep(1000);
            }

            Console.WriteLine(gambleMatch.ToString());
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("====================================");
            Console.WriteLine("Aperte Qualquer tecla para continuar");
            Console.ReadKey();
            PlayMenu.MenuScreen(gambleMatch);
        }
    }
}