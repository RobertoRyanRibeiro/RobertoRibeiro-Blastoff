using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using Questao3.Models.Entities;
using Questao3.Viewers;

namespace Questao3.Models.Services
{
    public static class IngressoService
    {

        static IngressoNormal ingressoNormal = new IngressoNormal();
        static IngressoVIP ingressoVIP = new IngressoVIP(10);
        static IngressoCamaroteInferior ingressoCamaroteInferior = new IngressoCamaroteInferior(15);
        static IngressoCamaroteSuperior ingressoCamaroteSuperior = new IngressoCamaroteSuperior(20);
        static User User = Season.User;

        public static void Listar()
        {
            Console.WriteLine(ingressoNormal.ImprimirIngresso());
            Console.WriteLine(ingressoVIP.ImprimirIngresso());
            Console.WriteLine(ingressoCamaroteInferior.ImprimirIngresso());
            Console.WriteLine(ingressoCamaroteSuperior.ImprimirIngresso());
        }


        public static void ComprarIngressoNormal()
        {
            Console.Clear();
            ErrorTreatment(ingressoNormal);
            Season.User.ComprarIngresso(ingressoNormal);
            Thread.Sleep(1000);
            UserOpMenu.View();
        }

        public static void ComprarIngressoVip()
        {
            Console.Clear();
            ErrorTreatment(ingressoVIP);
            Season.User.ComprarIngresso(ingressoVIP);
            Thread.Sleep(1000);
            UserOpMenu.View();
        }

        public static void ComprarIngressoCamaroteSuperior()
        {
            Console.Clear();
            CamaroteService.Navegar(Season.CamaroteSuperior, ingressoCamaroteSuperior);
            UserOpMenu.View();
        }
        public static void ComprarIngressoCamaroteInferior()
        {
            Console.Clear();
            CamaroteService.Navegar(Season.CamaroteInferior, ingressoCamaroteInferior);
            UserOpMenu.View();
        }
        public static void ErrorTreatment(Ingresso ingresso)
        {
            if (User.Ingresso == null)
            {
                if (User.Dinheiro >= ingresso.GetValor())
                    return;
                else
                    SemDinheiroSuficienteMsg();
            }

            if (User.Ingresso.Tipo == ingresso.Tipo)
                MesmoIngressoMsg();
            else
            {
                if (User.Dinheiro + User.Ingresso.GetValor() < ingresso.GetValor())
                    SemDinheiroSuficienteMsg();
                TrocarIngressoMsg(ingresso);
            }
            UserOpMenu.View();
        }

        private static void SemDinheiroSuficienteMsg()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("? - [Você não possui Dinheiro Suficiente]...Clique qualquer tecla para continuar");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
            ComprarIngressoMenu.View();
        }

        private static void MesmoIngressoMsg()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("? - [Você já possui este Ingresso]...Clique qualquer tecla para continuar");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
            UserOpMenu.View();
        }

        private static void TrocarIngressoMsg(Ingresso ingresso)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("? - [Você já possui um Ingresso, deseja trocar?]...Aperter SPACE para ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Sim");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" e ESC para ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Não");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.White;
            if (Console.ReadKey().Key == ConsoleKey.Spacebar)
            {
                Console.Clear();
                User.TrocarIngresso(ingresso);
                Console.WriteLine("+================+");
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Ingresso Trocado");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("|");
                Console.WriteLine("+================+");
                Thread.Sleep(1000);
            }
        }
    }
}
