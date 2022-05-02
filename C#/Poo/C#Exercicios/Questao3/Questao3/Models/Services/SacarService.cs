using System;
using System.Collections.Generic;
using System.Text;
using Questao3.Models.Entities;
using Questao3.Viewers;

namespace Questao3.Models.Services
{
    public class SacarService
    {

        User User = Season.User;

        public SacarService(){}

        public void Sacar()
        {
            Console.Clear();
            Console.WriteLine("|Quanto deseja Sacar?");
            Console.WriteLine("====================");
            var value = double.Parse(Console.ReadLine());
            User.SacarDinheiro(value);
            BancoMenu.View();
        }
        
    }
}
