using System;
using System.Collections.Generic;
using System.Text;

namespace Tarefa2.Viewers
{
    public struct OpGenerics
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Colum { get; private set; }
        public int Line { get; private set; }
        public MenuGeneric Path { get; private set; }

        public OpGenerics(int id, string name, int colum, int line)
        {
            Id = id;
            Name = name;
            Colum = colum;
            Line = line;
            Path = null;
        }

        public OpGenerics(int id, string name, int colum, int line, MenuGeneric path)
        {
            Id = id;
            Name = name;
            Colum = colum;
            Line = line;
            Path = path;
        }

        public void Draw()
        {
            Console.SetCursorPosition(Colum, Line);
            Console.Write($"   {Name}");
        }

    }
}
