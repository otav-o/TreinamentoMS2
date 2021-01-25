using CamadaAcessoADados.DAOs;
using CamadaAcessoADados.Models;
using System;

namespace CamadaAcessoADados
{
    class Program
    {
        static void Main(string[] args)
        {
            //InserirProduto();
            AlterarProduto();
            ExcluirProduto();

            ListarProdutos();
        }

        private static void ListarProdutos()
        {
            string parteDescricao = ""; // vazio retorna todos
            Console.WriteLine($"Produtos que contém '{parteDescricao}' em sua descrição");

            var dao = new ProdutoDAO();
            var produtos = dao.RetornarPorParteDescricao(parteDescricao);
            foreach (var prod in produtos)
            {
                Console.WriteLine($"Código: {prod.Codigo}, descrição: {prod.Descricao}");
            }

        }

        private static void ExcluirProduto()
        {
            Console.WriteLine("Excluindo o produto");

            var dao = new ProdutoDAO();
            var obj = dao.RetornarPorId("abc");
            if (obj == null)
            {
                Console.WriteLine("Não existe produto com este código");
                return;
            }

            dao.Excluir(obj);

            Console.WriteLine("Produto excluído");
        }

        private static void AlterarProduto()
        {
            Console.WriteLine("Alterando o produto");

            var dao = new ProdutoDAO();
            var obj = dao.RetornarPorId("abc");
            if (obj == null)
            {
                Console.WriteLine("Não existe produto com este código");
                return;
            }
            obj.Descricao += " Lata";

            dao.Atualizar(obj);

            Console.WriteLine("Produto alterado");

        }

        private static void InserirProduto()
        {
            Console.WriteLine("Inserindo produto...");

            var obj = new Produto
            {
                Codigo = 8,
                Descricao = "Guaraná Dolly",
                Preco = 7
            };
            var dao = new ProdutoDAO();
            dao.Inserir(obj);

            Console.WriteLine("Produto inserido com sucesso.");

        }
    }
}
