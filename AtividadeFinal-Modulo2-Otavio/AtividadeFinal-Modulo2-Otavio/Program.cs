using AtividadeFinal_Modulo2_Otavio.Models;
using System;

namespace AtividadeFinal_Modulo2_Otavio
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
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
