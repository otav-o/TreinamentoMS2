using EntityFrameworkEDAO.DAL__Data_Access_Layer_;
using EntityFrameworkEDAO.Models;
using System;

namespace EntityFrameworkEDAO
{
    class Program
    {
        static void Main(string[] args)
        {
            var dao = new ProdutoDAO();
            var obj = new Produto { ProdutoId = "123", Codigo = 1, Descricao = "Coca-cola", Preco = 5.5 };
            dao.Inserir(obj);

            obj.Descricao = "Coca-Cola Lata";
            dao.Alterar(obj);

            dao.Inserir(new Produto { ProdutoId = "124", Descricao = "Pepsi", Codigo = 2, Preco = 5 });

            var listaProdutos = dao.RetornarTodos();
            foreach (var p in listaProdutos)
                Console.WriteLine($"{p.Codigo} - {p.Descricao} - {p.Preco}");

            Console.ReadKey();
        }
    }
}
