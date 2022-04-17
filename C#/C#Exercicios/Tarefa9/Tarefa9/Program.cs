using System;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Tarefa9
{
    internal class Program
    {
        static Regex pattern = new Regex(@"\d{3}[\.]?\d{3}[\.]?\d{3}\-\d{2}");

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {

            Console.Clear();
            Console.WriteLine("Digite um numero de Cpf :  XXX.XXX.XXX-XX");
            Console.WriteLine("========================================");
            var cpf = Console.ReadLine();

            try
            {
                ValidandoFormatacao(cpf);
            }
            catch (OverflowException ex)
            {
                Console.Clear();
                Console.WriteLine(cpf);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                ErrorMsg();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(cpf);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                ErrorMsg();
            }

        }

        static void ValidandoFormatacao(string cpf)
        {
            Console.Clear();
            Match matchTelFormat = pattern.Match(cpf);
            if (matchTelFormat.Success)
            {
                var aux = cpf;
                //Substituindo . -
                aux = aux.Replace("-", "");
                aux = aux.Replace(".", "");

                //Verificando o tamanho
                if (aux.Length > 11)
                    throw new Exception("Numero maximo de digitos é 11");

                ValidandoCpf(cpf, aux);
            }
            else
            {
                throw new Exception("Padrão de Formatação errado");
            }
        }

        static void ValidandoCpf(string cpf, string aux)
        {
            var cpfValido = false;

            var numerosVerif = aux.Substring(aux.Length - 2, 2);

            var digitos = new int[aux.Length];
            for (var c = 0; c < aux.Length; c++)
            {
                digitos[c] = int.Parse(aux[c].ToString());
            }

            cpfValido = ValidandoNumerosVerificadores(numerosVerif, digitos);

            ImprimirNum(cpf, cpfValido);
        }

        static bool ValidandoNumerosVerificadores(string numVerf, params int[] digitos)
        {
            var valido = false;

            //Calculando a soma de todos os valores Base
            //Retornando o resto da SomaBase%11
            var resto = CalculandoVerificador(10, digitos);

            var verP = int.Parse(numVerf[0].ToString());
            var verS = int.Parse(numVerf[1].ToString());


            if (resto == 1 || resto == 0)
            {
                if (verP == 0)
                {
                    resto = CalculandoVerificador(11, verP, digitos);
                    if (resto == 1 || resto == 0)
                    {
                        if (verS == '0')
                            valido = true;
                    }
                    else if (resto >= 2 || resto <= 10)
                    {
                        if (verS == 11 - resto)
                            valido = true;
                    }
                }
            }
            else if (resto >= 2 || resto <= 10)
            {
                if (verP == 11 - resto)
                {
                    resto = CalculandoVerificador(11, verP, digitos);
                    if (resto == 1 || resto == 0)
                    {
                        if (verS == '0')
                            valido = true;
                    }
                    else if (resto >= 2 || resto <= 10)
                    {
                        if (verS == 11 - resto)
                            valido = true;
                    }
                }
            }
            return valido;
        }

        //Calcular o 1 Veriicador
        static int CalculandoVerificador(int multpNum, params int[] digitos)
        {
            //Soma dos Numeros base
            var somaBase = 0;

            for (var c = 0; c <= digitos.Length - 3; c++)
            {
                if (multpNum == 2)
                    somaBase += multpNum * digitos[c];
                else
                    somaBase += multpNum * digitos[c];
                multpNum--;
            }

            var resto = somaBase % 11;

            return resto;
        }
        //Calcular o 2 Verificador
        static int CalculandoVerificador(int multpNum, int verif, params int[] digitos)
        {
            //Soma dos Numeros base
            var somaBase = 0;

            for (var c = 0; c <= digitos.Length - 2; c++)
            {
                if (multpNum == 2)
                    somaBase += 2 * verif;
                else
                    somaBase += multpNum * digitos[c];
                multpNum--;
            }
            return somaBase % 11;
        }

        static void ImprimirNum(string cpf, bool cpfValido)
        {
            //Verificando digitos verificadores
            var result = "";
            if (cpfValido)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                result = "=CPF Valido=";
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                result = "=CPF Invalido=";
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("");
            Console.WriteLine($"CPF: {cpf}");
            Console.WriteLine("===================================");
            Console.WriteLine(result);
        }

        static void ErrorMsg()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-Error: Formatação Errada-");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("|Insira um CPF valido.");
            Console.WriteLine("|No formato XXX.XXX.XXX-XX");
            Console.WriteLine("=======================================");
            Console.WriteLine("Aperte qualquer tecla para continuar...");
            Console.ReadKey();
            Menu();
        }
    }
}
