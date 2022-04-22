using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace Tarefa9.Entities
{
    public class CPF
    {
        static Regex pattern = new Regex(@"^\d{3}[\.]?\d{3}[\.]?\d{3}\-\d{2}$");

        static bool cpfValido = false;
        static string result ;

        public static string Cpf { get; private set; }

        public CPF(string cpf)
        {
            cpfValido = false;
            Cpf = cpf;
        }

        public void Validar()
        {
            ValidandoFormatacao();
        }

        void ValidandoFormatacao()
        {
            Console.Clear();
            Match match = pattern.Match(Cpf);
            if (match.Success)
            {
                var aux = match.Value;
                //Substituindo . -
                aux = aux.Replace("-", "");
                aux = aux.Replace(".", "");

                ValidandoCpf(aux);
            }
            else
            {
                throw new Exception("Padrão de Formatação errado");
            }
        }

        void ValidandoCpf(string aux)
        {
            var numerosVerif = aux.Substring(aux.Length - 2, 2);

            var digitos = new int[aux.Length];
            for (var c = 0; c < aux.Length; c++)
            {
                digitos[c] = int.Parse(aux[c].ToString());
            }

            cpfValido = ValidandoNumerosVerificadores(numerosVerif, digitos);

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
        }

        bool ValidandoNumerosVerificadores(string numVerf, params int[] digitos)
        {
            var valido = false;

            //Calculando a soma de todos os valores Base
            //Retornando o resto da SomaBase%11
            var resto = CalculandoVerificador(digitos);

            var verP = int.Parse(numVerf[0].ToString());
            var verS = int.Parse(numVerf[1].ToString());


            if (resto == 10 )
            {
                resto = 0;
                if (verP == 0)
                {
                    resto = CalculandoVerificador(verP, digitos);
                    if (resto == 10 )
                    {
                        resto = 0;
                      
                        if (verS == 0)
                            valido = true;
                    }
                    else 
                    {
                        if (verS == resto)
                            valido = true;
                    }
                }
            }
            else 
            {
                if (verP == resto)
                {
                    resto = CalculandoVerificador(verP, digitos);
                    if (resto == 10)
                    {
                        resto = 0;
                        if (verS == 0)
                            valido = true;
                    }
                    else
                    {
                        if (verS == resto)
                            valido = true;
                    }
                }
            }
            return valido;
        }

        //Para Calcular o 1 Veriicador
        int CalculandoVerificador(params int[] digitos)
        {
            //Soma dos Numeros base
            var somaBase = 0;
            var multpNum = 1;

            for (var c = 0; c <= digitos.Length - 3; c++)
            {
                   somaBase += multpNum * digitos[c];
                multpNum++;
            }

            var resto = somaBase % 11;

            return resto;
        }
        //Para Calcular o 2 Verificador
        int CalculandoVerificador(int verif, params int[] digitos)
        {
            //Soma dos Numeros base
            var somaBase = 0;
            var multpNum = 0;

            for (var c = 0; c <= digitos.Length - 2; c++)
            {
                    somaBase += multpNum * digitos[c];
                multpNum++;
            }
            return somaBase % 11;
        }

        public override string ToString()
        {
            //Verificando digitos verificadores
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("");
            sb.AppendLine($"CPF: {Cpf}");
            sb.AppendLine("===================================");
            sb.AppendLine($"Resultado: {result}");
            return sb.ToString();
        }
 
    }
}
