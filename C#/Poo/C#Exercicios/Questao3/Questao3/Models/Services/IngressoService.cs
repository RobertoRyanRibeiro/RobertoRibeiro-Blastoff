using System;
using System.Collections.Generic;
using System.Text;
using Questao3.Models.Entities;
using Questao3.Viewers;

namespace Questao3.Models.Services
{
    public static class IngressoService
    {

        static IngressoNormal ingressoNormal = new IngressoNormal();
        static IngressoVIP ingressoVIP = new IngressoVIP(5);
        static IngressoCamaroteInferior ingressoCamaroteInferior;
        static IngressoCamaroteSuperior ingressoCamaroteSuperior;
        static User User = Season.User;

        public static void Listar()
        {
            Console.WriteLine(ingressoNormal.ImprimirIngresso());
            Console.WriteLine(ingressoVIP.ImprimirIngresso());
            Console.WriteLine(ingressoCamaroteInferior.ImprimirIngresso());
            //Console.WriteLine(ingressoNormal.ToString());
        }


        public static void ComprarIngressoNormal()
        {
            Console.Clear();
            ErrorTreatment(ingressoNormal);
            Season.User.ComprarIngresso(ingressoNormal);
            Console.ReadKey();
            UserOpMenu.View();
        }

        public static void ComprarIngressoVip()
        {
            Console.Clear();
            ErrorTreatment(ingressoVIP);
            Season.User.ComprarIngresso(ingressoVIP);
            Console.ReadKey();
            UserOpMenu.View();
        }

        public static void ComprarIngressoCamaroteSuperior()
        {
            //Season.User.ComprarIngresso(camaroteInferior);
        }
        public static void ComprarIngressoCamaroteInferior()
        {
            Console.Clear();

            CamaroteService camaroteService = new CamaroteService();
            camaroteService.DesenharCamarote(Season.CamaroteInferior);

            ErrorTreatment(ingressoCamaroteInferior);
            Season.User.ComprarIngresso(ingressoCamaroteInferior);
            Console.ReadKey();
            UserOpMenu.View();
        }


        private static void ErrorTreatment(Ingresso ingresso)
        {
            if (User.Ingresso == null)
            {
                if (User.Dinheiro >= ingresso.Valor)
                    return;
                else
                    SemDinheiroSuficienteMsg();
            }

            if (User.Ingresso.Tipo == ingresso.Tipo)
                MesmoIngressoMsg();
            else
            {
                if (User.Dinheiro + User.Ingresso.Valor < ingresso.Valor)
                    SemDinheiroSuficienteMsg();
                TrocarIngressoMsg(ingresso);

            }
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
            ComprarIngressoMenu.View();
        }

        private static void TrocarIngressoMsg(Ingresso ingresso)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("? - [Você já possui um Ingresso, deseja trocar?]...Aperter ENTER para ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Sim");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" e ESC para ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Não");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.White;
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                User.TrocarIngresso(ingresso);
                Console.WriteLine("+================+");
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Ingresso Trocado");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("|");
                Console.WriteLine("+================+");
                Console.WriteLine("|Aperte qualquer tecla para continuar...");
                Console.ReadKey();
                ComprarIngressoMenu.View();
            }
            else
                UserOpMenu.View();
        }
    }
}
