using AtividadeFinal_Modulo2_Otavio.DAL;
using AtividadeFinal_Modulo2_Otavio.Models;
using System;
using System.Collections.Generic;

namespace AtividadeFinal_Modulo2_Otavio
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuPrincipal();

            Console.WriteLine("Fim do programa");
        }

        private static void Cadastrar<T>(T obj)
        {
            DAOGenerica<T> dao = new DAOGenerica<T>();
            dao.Inserir(obj);
        }


        private static void MenuPrincipal()
        {
            Console.Write("GERENCIADOR DE ALUNOS" +
                "\n[1] Inserir aluno" +
                "\n[2] Alterar aluno" +
                "\n[3] Excluir aluno" +
                "\n[4] Consultar aluno por matrícula" +
                "\n[5] Consultar aluno por parte do nome" +
                "\n Digite o número da opção desejada: ");
            var resp = Console.ReadLine();
            switch (resp)
            {
                case "1": InserirAlunoMenu(); break;
                case "2": AlterarAlunoMenu(); break;
                case "3": ExcluirAlunoMenu(); break;
                case "4": ConsultarAlunoMatricula(); break;
                case "5": ConsultarAlunoParteNome(); break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                    MenuPrincipal();
                    break;
            }
        }

        private static void ConsultarAlunoParteNome()
        {
            Console.Write("Insira parte do nome do aluno: ");
            string parteNome = Console.ReadLine();
            var dao = new AlunoDAO();
            var alunos = dao.RetornarPorParteNome(parteNome);
            if (alunos.Count == 0) 
                Console.WriteLine("Nenhum aluno encontrado.");
            else 
                foreach (Aluno a in alunos) 
                    ImprimirDados(a);
        }

        private static void ConsultarAlunoMatricula()
        {
            Aluno aluno = RetornarAlunoPorMatriculaMenu("CONSULTAR");
            ImprimirDados(aluno);
        }

        private static void ImprimirDados(Aluno obj)
        {
            Console.WriteLine($"---- ALUNO {obj.Matricula} ----" +
                $"\nNome: {obj.Nome}" +
                $"\nE-mail: {obj.Email}");
            ImprimirEndereco(obj);
        }

        private static void ImprimirEndereco(Aluno obj)
        {
            var enderecos = RetornarEnderecosPorAluno(obj);
            if (enderecos.Count == 0) Console.WriteLine("Sem endereço cadastrado.");
            else
            {
                foreach (Endereco e in enderecos)
                Console.WriteLine($"{e.Logradouro}, {e.Numero}/{e.Complemento}, {e.Bairro}, {e.Cidade}");
            }
        }

        private static List<Endereco> RetornarEnderecosPorAluno(Aluno aluno)
        {
            var dao = new EnderecoDAO();
            return dao.RetornarPorAluno(aluno);
        }

        private static Aluno RetornarAlunoPorMatriculaMenu(string texto)
        {
        inicio:
            Console.Write($"{texto} ALUNO\nInsira o n° de matrícula: ");
            var mat = Convert.ToInt32(Console.ReadLine());
            var dao = new AlunoDAO();
            var aluno = dao.RetornarPorMatricula(mat);

            if (aluno == null) { Console.WriteLine("Matrícula inválida!"); goto inicio; }
            else return aluno;
        }

        private static void ExcluirAlunoMenu()
        {
            Aluno aluno = RetornarAlunoPorMatriculaMenu("EXCLUIR");
            ExcluirEnderecos(aluno); // para evitar chave estrangeira inconsistente
            var dao = new DAOGenerica<Aluno>();
            dao.Excluir(aluno);
            Console.WriteLine($"Aluno n° {aluno.Matricula} excluído com sucesso");
        }

        private static void ExcluirEnderecos(Aluno obj)
        {
            var daoEndereco = new DAOGenerica<Endereco>();
            var enderecos = RetornarEnderecosPorAluno(obj);
            foreach(var e in enderecos) daoEndereco.Excluir(e);
        }

        private static void AlterarAlunoMenu()
        {
            Aluno aluno = RetornarAlunoPorMatriculaMenu("ALTERAR");
            List<Endereco> enderecos = RetornarEnderecosPorAluno(aluno);

            Console.Write("Deseja alterar o nome? [S/N] "); string resp = Console.ReadLine().Trim().ToUpper();
            if (resp == "S")
            {
                Console.Write("Novo nome: "); 
                aluno.Nome = Console.ReadLine();
            }
            Console.Write("Deseja alterar o e-mail? [S/N] "); resp = Console.ReadLine().Trim().ToUpper();
            if (resp == "S")
            {
                Console.Write("Novo e-mail: ");
                aluno.Email = Console.ReadLine();
            }
            Console.Write("Deseja alterar o endereço? [S/N] "); resp = Console.ReadLine().Trim().ToUpper();
            if (resp == "S")
            {
                if (enderecos.Count == 0) Console.WriteLine("Não há endereços para alteração");
                else
                {
                    Console.WriteLine("Qual o tipo de endereço que deseja alterar?");
                    var respTipo = Console.ReadLine();
                    foreach (var e in enderecos)
                    {
                        if (e.Tipo == respTipo) AlterarEndereco(e);
                    }
                }
            }
            var dao = new DAOGenerica<Aluno>();
            dao.Alterar(aluno);
        }

        private static void AlterarEndereco(Endereco e)
        {
            PreenchimentoEndereco(e);
            var dao = new DAOGenerica<Endereco>();
            dao.Alterar(e);
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

            Cadastrar<Aluno>(obj); // insere o aluno da base de dados
            var daoAluno = new AlunoDAO();

            obj = daoAluno.RetornarPorMatricula(obj.Matricula); // pega o aluno de volta

            Console.Write("Deseja inserir um endereço? ");
            var resp = Console.ReadLine().Trim().ToLower()[0];
            while (resp == 's')
            {
                var end = InserirEnderecoMenu(); // recebe um endereço preenchido
                end.Aluno = obj; // adiciona o aluno ao objeto endereço
                Cadastrar<Endereco>(end); // não adiona o aluno também (contexto.State está Added)
                Console.Write("Deseja inserir outro endereço? ");
                resp = Console.ReadLine().Trim().ToLower()[0];
            }

        }

        private static Endereco InserirEnderecoMenu()
        {
            Console.WriteLine("    -- Cadastro de endereço");

            var end = new Endereco();

            PreenchimentoEndereco(end);
            
            return end;
        }

        private static void PreenchimentoEndereco(Endereco end)
        {
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
        }
    }
}
