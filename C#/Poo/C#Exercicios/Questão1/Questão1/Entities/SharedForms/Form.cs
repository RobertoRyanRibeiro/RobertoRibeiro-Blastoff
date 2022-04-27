using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using Questão1.NotificationContext;

namespace Questão1.Entities.SharedForms
{
    public abstract class Form : Notifiable
    {
        //Atributte
        private double width;
        private double length;

        private Regex pattern = new Regex(@"^\d*$");
        private Match match;

        //Constructor
        public Form()
        {

        }

        public Form(double width, double length)
        {
            Width = width;
            Length = length;
        }

        public Form(double length)
        {
            Length = length;
        }

        //Auto-Property
        public bool IsInvalid { get; private set; } = false;

        //Property
        public double Width
        {
            get { return width; }
            set
            {
                match = pattern.Match(value.ToString());
                if (match.Success)
                    width = double.Parse(match.Value);
                else
                    IsInvalid = true;
            }
        }
        public double Length
        {
            get { return length; }
            set
            {
                match = pattern.Match(value.ToString());
                if (match.Success)
                    length = double.Parse(match.Value);
                else
                    IsInvalid = true;
            }
        }

        //Methods
        public virtual void ChangeValues(double width, double length)
        {
            Width = width;
            Length = length;
        }

        public virtual string PrintSides()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"|Comprimento:{Width} m");
            sb.AppendLine($"|Largura:{Length} m");
            return sb.ToString();
        }
    }
}
