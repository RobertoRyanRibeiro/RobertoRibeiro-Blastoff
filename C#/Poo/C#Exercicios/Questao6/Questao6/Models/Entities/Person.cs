using System;
using System.Collections.Generic;
using System.Text;

namespace Questao6.Models.Entities
{
    public class Person
    {
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public string Telefone { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public float Altura { get; private set; }


        public void Message(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
