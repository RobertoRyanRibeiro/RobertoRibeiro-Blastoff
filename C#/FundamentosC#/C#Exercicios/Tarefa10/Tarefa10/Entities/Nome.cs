using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Tarefa10.Entities
{
    internal class Nome
    { 
        public string Name { get; private set; }

        public Nome(string name)
        {
            Name = name;
        }

        static string pattern = @"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ][A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]*$";
        public void VerificarNome()
        {
            Match match = Regex.Match(Name, pattern);

            //Verificando Formatação
            if (Regex.IsMatch(Name, pattern))
            {
                Name = match.Value;
                TransformaNome();
            }
            else
            {
                throw new ArgumentException("Error:Formatação Invalida");
            }
        }

        void TransformaNome()
        {
            //Quantidade do 1 Nome
            var nomeCortado = Name.Split(' ');
            var quant1Nome = nomeCortado[0].Length;

            //Quantidade Total do Nome
            var quantNomeCompleto = 0;
            var aux = Name;
            aux = aux.Replace(" ", "");
            quantNomeCompleto = aux.Length;

            Console.WriteLine("==================================");
            Console.WriteLine($"Quantidade de letras nome completo: {quantNomeCompleto} ");
            Console.WriteLine($"Quantidade de letras 1º nome: {quant1Nome} ");
            Console.WriteLine($"Nome Em Caixa Alta: {Name.ToUpper()} ");
            Console.WriteLine($"Nome Em Caixa Alta: {Name.ToLower()} ");
        }
    }
}
