using System;
using System.Collections.Generic;
using System.Text;

namespace Questao6.Models.Entities
{
    public class Person
    {
        public Person() { }

        public Person(string nome, string bairro,string rua,int numero, string telefone, int idade, float altura)
        {
            Nome = nome;
            Endereco.Bairro = bairro;
            Endereco.Rua = rua;
            Endereco.Numero = numero;
            Telefone = telefone;
            Idade = idade;
            Altura = altura;
        }

        public string Nome { get; private set; }
        public Endereco Endereco { get; private set; } = new Endereco();
        public string Telefone { get; private set; }
        public int Idade { get; private set; }
        public float Altura { get; private set; }
        public string Message { get; private set; }


        public void CreateMessage(string msg)
        {
            Message = msg;
        }

        public void ShowMessage()
        {
            Console.WriteLine("   = Messagem =");
            Console.WriteLine($"|Message - {Message}");
        }

        public void ImprimirDados()
        {
            Console.WriteLine("   = Dados =");
            Console.WriteLine($"|Nome - {Nome}");
            Console.WriteLine($"|Telefone - {Telefone}");
            Console.WriteLine($"|Idade - {Idade} Anos");
            Console.WriteLine($"|Altura - {Altura:F2} m");
            Console.WriteLine("");
            Console.WriteLine("  =Endereco=");
            Console.WriteLine($"|Bairro - {Endereco.Bairro}");
            Console.WriteLine($"|Rua - {Endereco.Rua}");
            Console.WriteLine($"|Numero - {Endereco.Bairro}");
            ShowMessage();
        }
    }
}
