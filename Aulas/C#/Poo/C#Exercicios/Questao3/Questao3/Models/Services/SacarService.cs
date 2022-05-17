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

        public SacarService() { }

        public void Sacar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("|Quanto deseja Sacar?");
                Console.WriteLine("====================");
                var value = double.Parse(Console.ReadLine());
                if (value < 0)
                    throw new ArgumentException("Valor negativo");
                User.SacarDinheiro(value);
                BancoMenu.View();
            }
            catch (FormatException ex)
            {
                Console.WriteLine("|Error : Formatação Invalida");
                ErrorMsg();
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("|Error : Ultrapassou os limmites");
                ErrorMsg();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                ErrorMsg();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                ErrorMsg();
            }
        }

        void ErrorMsg()
        {
            Console.WriteLine("Digite qualquer tecla para continuar...");
            Console.ReadKey();
            Sacar();
        }

    }
}
