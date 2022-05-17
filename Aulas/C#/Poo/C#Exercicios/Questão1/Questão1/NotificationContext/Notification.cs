using System;
using System.Collections.Generic;
using System.Text;

namespace Questão1.NotificationContext
{
    public class Notification
    {
        public Notification(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }

        public string Message()
        {
            StringBuilder sb = new StringBuilder();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            sb.AppendLine("Error - Excepetion");
            sb.AppendLine("-=============================-");
            Console.ForegroundColor = ConsoleColor.White;
            sb.AppendLine($"Title - {Title}");
            sb.AppendLine($"Descp: {Description}");
            sb.AppendLine("Aperte qualquer tecla para continuar");
            return sb.ToString();
        }
    }
}
