using AtividadeFinal_Modulo2_Otavio.DAL;
using AtividadeFinal_Modulo2_Otavio.Models;
using System;

namespace AtividadeFinal_Modulo2_Otavio
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ApplicationContext())
            {
                context.Add(new Aluno { Email = "aluno@gmail.com", Nome = "Camillo" });
                context.SaveChanges();
            }

            Console.WriteLine("Fim do programa");
        }

        private static void InserirAlunoMenu()
        {
            Console.WriteLine("--- Cadastro de aluno ---");
            var obj = new Aluno();
            Console.Write("  Nome: ");
            obj.Nome = Console.ReadLine();
        }
    }
}
