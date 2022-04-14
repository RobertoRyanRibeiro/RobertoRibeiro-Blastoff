using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace EditorHtml
{
    public static class Editor
    {
        public static void Show() 
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("MODO EDITOR");
            Console.WriteLine("-----------");
            Start();
        }

        public static void Start()
        {
            var file = new StringBuilder();
            
            do
            {
                file.Append(Console.ReadLine());
                file.Append(Environment.NewLine);
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.WriteLine("-----------");
            Console.WriteLine("1Deseja Salvar o arquivo S/N");
            char op = char.Parse(Console.ReadLine().ToUpper());
            if (op == 'S')
            {
                Save(file);
            }
            else if (op == 'N')
            {
                Console.Clear();
                Console.WriteLine("Voltando pro menu...");
                Thread.Sleep(2500);
                Menu.Show();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Opção Invalida");
                Thread.Sleep(1000);
                Menu.Show();
            }
                
        }

        public static void Save(StringBuilder s)
        {
            Console.WriteLine("Digite o caminho do arquivo");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(s.ToString());  
            }

            Console.WriteLine("Dados Salvos com sucesso");
            Menu.Show();
        }
    }
}
