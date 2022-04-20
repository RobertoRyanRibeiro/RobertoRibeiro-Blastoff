using System;
using System.Collections.Generic;

namespace Var
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Var se adapta ao valor recebido
            
            var idade = 25;
            //int idade = 25;
            //idade = "André"; -> Error porque o var só pode se modificar uma vez
            
            var nome = "André ";
            
            //var aluno = new IEnumerable<MeuTipoComplexo>();
            //IEnumerable<MeuTipoComplexo> aluno = new IEnumerable<MeuTipoComplexo>();


            Console.WriteLine("Hello World!");
        }
    }
}
