using Questao4.Generics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Questao4.Generics
{

    public sealed class GenericMenuOption
    {
        public GenericMenuOption(string text, Action menu)
        {
            Text = text;
            Menu = menu;
        }

        public int CursoX { get; private set; } = 0;
        public int CursoY { get; private set; } = 0;

        public bool IsSelected { get; private set; }
        public string Text { get; private set; }
        public int OrderPos { get; set; }
        public Action Menu { get; private set; }

        public void Select()
        {
            IsSelected = true;
        }

        public void DeSelect()
        {
            IsSelected = false;
        }

        public void Draw()
        {
            CursoY = Console.CursorTop;
            CursoX = Console.CursorLeft;
            //Precisa de um espaço para n ser engolido pelo marcador
            Console.WriteLine($" {Text}");
        }


        public delegate void OnSelectedHandle(Action sender, EventArgs e);
        public event OnSelectedHandle OnSelectedEvent;
        public void OnSelected()
        {
            OnSelectedHandle eventHandler = OnSelectedEvent;
            eventHandler?.Invoke(Menu, EventArgs.Empty);
        }
    }
}
