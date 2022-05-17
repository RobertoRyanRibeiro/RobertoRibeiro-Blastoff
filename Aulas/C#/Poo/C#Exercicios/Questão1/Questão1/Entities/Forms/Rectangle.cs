using System;
using System.Collections.Generic;
using System.Text;
using Questão1.Entities.SharedForms;

namespace Questão1.Entities.Forms
{
    public class Rectangle : Form, IForm
    {
        public Rectangle(double width, double length) : base(width, length)
        {
        }
        
        public Rectangle(double length) : base(length)
        {
        }


        public double Area()
        {
            return Width * Length;
        }

        public double Perimeter()
        {
            return 2 * (Width + Length);
        }
    }
}
