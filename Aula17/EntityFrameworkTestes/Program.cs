using EntityFrameworkTestes.DAL;
using EntityFrameworkTestes.Models;
using System;
using System.Linq;

namespace EntityFrameworkTestes
{
    class Program
    {
        static void Main(string[] args)
        {
            IncluirProdutos();
            //AlterarProduto();
            //ExcluirProduto();

            //ImprimirComPrecoMaiorQue(3); // consulta

            Console.WriteLine("Fim do programa");
            Console.ReadKey();
        }

        private static void ImprimirComPrecoMaiorQue(double preco)
        {
            using (var db = new PedidosContext())
            {
                //var produtos = db.Produtos.Where(x => x.Preco > preco);
                var produtos = from x in db.Produtos where x.Preco > preco select x;

                foreach (var p in produtos)
                {
                    Console.WriteLine($"{p.Codigo} - {p.Descricao} - {p.Preco:N2}");
                }
            }
        }

        private static void ExcluirProduto()
        {
            using (var db = new PedidosContext())
            {
                var p2 = (from x in db.Produtos where x.ProdutoId == "Produto2" select x).FirstOrDefault();

                if (p2 == null)
                    Console.WriteLine("Produto de id='Produto2' não encontrado");
                else
                {
                    db.Produtos.Remove(p2);
                    db.SaveChanges();
                }
            }
        }

        private static void AlterarProduto()
        {
            using (var db = new PedidosContext())
            {
                //var p2 = db.Produtos.Where(x => x.ProdutoId == "Produto2").FirstOrDefault();
                var p2 = (from x in db.Produtos where x.ProdutoId == "Produto2" select x).FirstOrDefault(); // comando sql deixa de ser uma string e passa a ser verificado pelo compilador. Tem boa integração com o LINQ

                p2.Descricao = "Produto 2 (Alterado)";
                db.SaveChanges();
            }
        }

        private static void IncluirProdutos()
        {
            using (var db = new PedidosContext())
            {
                var p1 = new Produto { ProdutoId = "Produto1", Codigo = 1, Descricao = "Produto 1", Preco = 1.11 };
                var p2 = new Produto { ProdutoId = "Produto2", Codigo = 2, Descricao = "Produto 2", Preco = 2.22 };
                var p3 = new Produto { ProdutoId = "Produto3", Codigo = 3, Descricao = "Produto 3", Preco = 3.33 };
                var p4 = new Produto { ProdutoId = "Produto4", Codigo = 4, Descricao = "Produto 4", Preco = 4.44 };
                var p5 = new Produto { ProdutoId = "Produto5", Codigo = 5, Descricao = "Produto 5", Preco = 5.55 };

                db.Add(p1); // db é PedidosContext(). Adiciona-se a ele p1, vai para o DbSet<Produto> Produtos
                db.SaveChanges();

                db.Add(p2);
                db.SaveChanges();

                db.Add(p3);
                db.SaveChanges();

                db.Add(p4);
                db.SaveChanges();

                db.Add(p5);
                db.SaveChanges();
            }
        }
    }
}
