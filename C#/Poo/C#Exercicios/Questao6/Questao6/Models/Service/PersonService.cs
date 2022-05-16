using System;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Questao6.Models.Entities;
using Questao6.Viewers;

namespace Questao6.Models.Service
{
    public static class PersonService
    {
        static Person person;

        public static void Entrada()
        {
            Console.Clear();
            //=================================== Formatos =======================================
            var nomeFormato = new Regex(@"^[a-zA-zà-ÿÀ-ÿ'][a-zA-zà-ÿÀ-ÿ'\s]*$");
            var cepFormato = new Regex(@"^[\da-zA-zà-ÿÀ-ÿ'][\da-zA-zà-ÿÀ-ÿ'\s]*$");
            var telFormato = new Regex(@"^\(?\d{2}\)?\s?[9]\d{4}[\-\s]?\d{4}$");
            //var dateFormato = new Regex(@"^\d{2}\/?\d{2}\/?\d{4}$");
            //=================================== Nome =======================================
            Console.WriteLine("|Digite o Nome");
            Console.WriteLine("========================================");
            var nome = Console.ReadLine();
            if (!nomeFormato.IsMatch(nome))
                throw new ArgumentException("|Error - Formato Nome Invalido");
            //=================================== Bairro =======================================
            Console.WriteLine("|Digite o Bairro");
            Console.WriteLine("========================================");
            var bairro = Console.ReadLine();
            if (!cepFormato.IsMatch(bairro))
                throw new ArgumentException("|Error - Formato Bairro Invalido");
            //=================================== Rua =======================================
            Console.WriteLine("|Digite a Rua");
            Console.WriteLine("========================================");
            var rua = Console.ReadLine();
            if (!cepFormato.IsMatch(rua))
                throw new ArgumentException("|Error - Formato Rua Invalido");
            //=================================== Numero =======================================
            Console.WriteLine("|Digite o Numero");
            Console.WriteLine("========================================");
            var numero = int.Parse(Console.ReadLine());
            if (numero < 0)
                throw new ArgumentException("|Error - Numero não pode ser negativo");
            //=================================== Telefone =======================================
            Console.WriteLine("|Digite o Telefone : (92) 90000-0000/92 90000 0000");
            Console.WriteLine("========================================");
            var telefone = Console.ReadLine();
            if (!telFormato.IsMatch(telefone))
                throw new ArgumentException("|Error - Formato Telfone Invalido : (92) 90000-0000/92900000000");
            //=================================== Idade =======================================
            Console.WriteLine("|Digite a Data Nascimento dd/MM/yyyy");
            Console.WriteLine("========================================");
            var dataNasc = DateTime.Parse(Console.ReadLine(),CultureInfo.CreateSpecificCulture("pt-BR"));  
            if (dataNasc >=  DateTime.Now)
                throw new ArgumentException("|Error - Não é possivel nascer no futuro...");
            var idade = DateTime.Now.Year - dataNasc.Year;
            if (DateTime.Now.Year < dataNasc.Year)
                idade -= 1;
            //=================================== Altura =======================================
            Console.WriteLine("|Digite a Altura");
            Console.WriteLine("========================================");
            var altura = float.Parse(Console.ReadLine());
            if (numero < 0)
                throw new ArgumentException("|Error - A Altura não pode ser negativo");
            if (numero == 0)
                throw new ArgumentException("|Error - A Altura não pode ser zero");
            //=================================== Object =======================================
            person = new Person(nome, bairro, rua, numero, telefone, idade, altura);
            MenuPerson.View();
        }

        public static void CreatePerson()
        {
            try
            {
                Entrada();
            }
            catch (FormatException ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine("|Error - Formatação Invalida");
                Thread.Sleep(1000);
                CreatePerson();
            }
            catch (OverflowException ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                CreatePerson();
            }
            catch (ArgumentException ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                CreatePerson();

            }
            catch (Exception ex)
            {
                Console.Clear();
                ErrorMsg();
                Console.WriteLine(ex.Message);
                Thread.Sleep(1000);
                CreatePerson();
            }

        }
        public static void Message()
        {
            Console.Clear();
            if (person == null)
            {
                Console.Clear();
                ErrorPerson();
            }
            Console.WriteLine("|Digite a frase");
            var frase = Console.ReadLine();
            person.CreateMessage(frase);
            WaitUntilClick();
        }

        public static void Show()
        {
            Console.Clear();
            if (person == null)
            {
                Console.Clear();
                ErrorPerson();
            }

            person.ImprimirDados();
            WaitUntilClick();
        }

        static void ErrorMsg()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("|Error - Na Entrada de Dados");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("===========================");
        }

        static void ErrorPerson()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("|Error - Está vazio");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
            MenuPerson.View();
        }

        static void WaitUntilClick()
        {
            Console.WriteLine("Digite qualquer tecla para continuar...");
            Console.ReadKey();
            MenuPerson.View();
        }

    }
}
