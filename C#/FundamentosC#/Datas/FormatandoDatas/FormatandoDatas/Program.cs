using System;

namespace FormatandoDatas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            var data = DateTime.Now;

            //var formato = "";
            //var formato = String.Format("{0:y}",data);
            //var formato = String.Format("{0:yyy}",data);
            //var formato = String.Format("{0:M}",data);
            //var formato = String.Format("{0:yyyy-MM-dd}",data);
            //var formato = String.Format("{0:yyyy*MM*dd}",data);
            //var formato = String.Format("{0:yyyy/MM/d}", data);
            //var formato = String.Format("{0:dd/MM/yyyy}", data);
            //var formato = String.Format("{0:dd/MM/yyyy hh:mm:ss ff z}", data);
            var formato = String.Format("{0:dd/MM/yyyy hh:mm:ss ff}", data);
            Console.WriteLine(formato);


        }
    }
}
