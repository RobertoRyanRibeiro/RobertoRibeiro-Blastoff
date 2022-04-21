using System;

namespace DisparandoExceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[3];

            try
            {
                //for (var index = 0; index < 10; index++)
                //{
                //    //System.IndexOutOfRangeException
                //    Console.WriteLine(arr[index]);
                //}

                Cadastrar("");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                Console.WriteLine("Não encontrei o index na lista");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                Console.WriteLine("Falha a Cadastrar o texto!");
            }  catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                Console.WriteLine("Ops, algo deu errado!");
            }
        }

        static void Cadastrar(string texto)
        {
            if (String.IsNullOrEmpty(texto))
                throw new ArgumentNullException("O texto não pode ser nulo ou vazio");

        }
    }
}
