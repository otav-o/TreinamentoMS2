﻿using AtividadeFinal_Modulo2_Otavio.DAL;
using AtividadeFinal_Modulo2_Otavio.Models;
using System;

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
                //case "3": ExcluirAlunoMenu(); break;
                //case "4": ConsultarAlunoMatricula(); break;
                //case "5": ConsultarAlunoParteNome(); break;
                default:
                    Console.WriteLine("Opção inválida!");
                    MenuPrincipal();
                    break;
            }
        }

        private static void AlterarAlunoMenu()
        {
            inicio:
            Console.Write("ALTERAR ALUNO\nInsira o n° de matrícula: ");
            var mat = Convert.ToInt32(Console.ReadLine());
            var dao = new AlunoDAO();
            var aluno = dao.RetornarPorMatricula(mat);

            if (aluno == null) { Console.WriteLine("Matrícula inválida!"); goto inicio; }

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
                var end = InserirEnderecoMenu();
                end.Aluno = aluno;
            }
            var dao2 = new DAOGenerica<Aluno>();
            dao2.Alterar(aluno);

            // TODO o endereço ainda não está sendo alterado
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

            Cadastrar<Aluno>(obj);
            var daoAluno = new AlunoDAO();

            obj = daoAluno.RetornarPorMatricula(obj.Matricula);

            Console.Write("Deseja inserir um endereço? ");
            var resp = Console.ReadLine().Trim().ToLower()[0];
            while (resp == 's')
            {
                var end = InserirEnderecoMenu();
                end.Aluno = obj;
                Console.Write("Deseja inserir outro endereço? ");
                resp = Console.ReadLine().Trim().ToLower()[0];
            }
            
        }

        private static Endereco InserirEnderecoMenu()
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

            return end;

            //end.Aluno = obj;
            //Cadastrar<Endereco>(end); // já insere aluno na tabela Alunos
        }
    }
}
