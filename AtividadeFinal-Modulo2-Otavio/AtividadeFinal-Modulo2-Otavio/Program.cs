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


        private static void Cadastrar<T> (T obj)
        {
            using (var context = new ApplicationContext())
            {
                context.Add(obj);
                context.SaveChanges();
            }
        }

        //private static void MenuPrincipal()
        //{
        //    Console.Write("GERENCIADOR DE ALUNOS" +
        //        "\n[1] Inserir aluno" +
        //        "\n[2] Alterar aluno" +
        //        "\n[3] Excluir aluno" +
        //        "\n[4] Consultar aluno por matrícula" +
        //        "\n[5] Consultar aluno por parte do nome" +
        //        "\n Digite o número da opção desejada: ");
        //    var resp = Console.ReadLine();
        //    switch (resp)
        //    {
        //        case "1": InserirAlunoMenu(); break;
        //        case "2": AlterarAlunoMenu(); break;
        //        case "3": ExcluirAlunoMenu(); break;
        //        case "4": ConsultarAlunoMatricula(); break;
        //        case "5": ConsultarAlunoParteNome(); break;
        //        default:
        //            Console.WriteLine("Opção inválida!");
        //            MenuPrincipal();
        //            break;
        //    }
        //}
        private static void InserirAlunoMenu()
        {
            Console.WriteLine("--- Cadastro de aluno ---");
            var obj = new Aluno();

            //Console.Write("  Matrícula: ");
            //obj.Matricula = Convert.ToInt32(Console.ReadLine());
            Console.Write("  Nome: ");

            obj.Nome = Console.ReadLine();
            Console.Write("  E-mail: ");
            obj.Email = Console.ReadLine();

            Console.Write("Deseja inserir um endereço? ");
            var resp = Console.ReadLine().Trim().ToLower()[0];
            if (resp == 's')
                InserirEnderecoMenu(obj);

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

            // obj.Endereco.Id = end.Id;

            // TODO associar um aluno a um endereço

        }
    }
}
