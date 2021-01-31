using AtividadeFinal_Modulo2_Otavio.DAL;
using AtividadeFinal_Modulo2_Otavio.Models;
using System;

namespace AtividadeFinal_Modulo2_Otavio
{
    class Program
    {
        static void Main(string[] args)
        {
            InserirAlunoMenu();

            Console.WriteLine("Fim do programa");
        }

        private static void Cadastrar<T>(T obj)
        {
            DAOGenerica<T> dao = new DAOGenerica<T>();
            dao.Inserir(obj);
        }

        private static void InserirAlunoMenu()
        {
            Console.WriteLine("--- Cadastro de aluno ---");
            var obj = new Aluno();

            Console.Write("  Matrícula: ");
            obj.Matricula = Convert.ToInt32(Console.ReadLine());

            Console.Write("  Nome: ");
            obj.Nome = Console.ReadLine();

            Console.Write("  E-mail: ");
            obj.Email = Console.ReadLine();

            Console.Write("Deseja inserir um endereço? ");
            var resp = Console.ReadLine().Trim().ToLower()[0];
            while (resp == 's')
            {
                InserirEnderecoMenu(obj);
                Console.Write("Deseja inserir outro endereço? ");
                resp = Console.ReadLine().Trim().ToLower()[0];
            }
            Cadastrar<Aluno>(obj);
        }

        private static void InserirEnderecoMenu(Aluno obj)
        {
            Console.WriteLine("    -- Cadastro de endereço");
            var end = new Endereco();

            Console.Write("      Qual o tipo do endereço?[residencial/comercial] ");
            end.Tipo = Console.ReadLine();

            Console.Write("      Logradouro: ");
            end.Logradouro = Console.ReadLine();

            Console.Write("      Número: ");
            end.Numero = Convert.ToInt32(Console.ReadLine());

            Console.Write("      Complemento: ");
            end.Complemento = Convert.ToInt32(Console.ReadLine());

            Console.Write("      Bairro: ");
            end.Bairro = Console.ReadLine();

            Console.Write("      Cidade: ");
            end.Cidade = Console.ReadLine();

            Cadastrar<Endereco>(end);

            // TODO associar um aluno a um endereço

        }
    }
}
