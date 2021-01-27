using EntityFrameworkTestes.DAL;
using EntityFrameworkTestes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkTestes
{
    class Program
    {
        static void Main(string[] args)
        {
            //IncluirProdutos();
            //AlterarProduto();
            //ExcluirProduto();
            //ImprimirComPrecoMaiorQue(3); // consulta
            AdicionarRegistros();

            Console.WriteLine("Fim do programa");
            Console.ReadKey();
        }
        private static void ImprimirProdutos()
        {
            using (var db = new PedidosContext())
            {
                var pedidos = db.Pedidos.Include(a => a.Cliente).Include(y => y.Itens).ThenInclude(b => b.Produto); // passa uma função com o que quer ser incluído
                // incluir clientes, itens e, para cada item, os produtos.
                // só seleciona na primeira iteração (no foreach abaixo). Obs.: colocar ToArray() para executar o comando imediatamente
                // também poderia carregar os pedidos e depois carregar os itens em uma segunda consulta (cuidado para não deixar conexão aberta)
                foreach (var p in pedidos)
                {
                    Console.WriteLine($"{p.Numero} - {p.Cliente.Nome}");
                    foreach (var item in p.Itens)
                    {
                        Console.WriteLine($"    {item.Produto.Descricao, 20}");
                    }
                    Console.WriteLine($"Total do pedido: {p.Total} - ");
                }
            }
        }
        private static void AdicionarRegistros()
        {
            using (var db = new PedidosContext())
            {
                var c1 = new Cliente { ClienteId = "Cliente1", Nome = "Cliente 1", Email = "cliente1@gmail.com" };
                var c2 = new Cliente { ClienteId = "Cliente2", Nome = "Cliente 2", Email = "cliente2@gmail.com" };

                db.Clientes.AddRange(c1, c2);
                db.SaveChanges();

                var p1 = new Pedido
                {
                    PedidoId = "Pedido1",
                    Numero = 1,
                    Cliente = c1,
                    Itens = new List<PedidoItem>
                    {
                        new PedidoItem { PedidoItemId = "PedidoItem1", PedidoId = "Pedido1", Produto = RetornaProdutoPorId(db, "Produto1"), Quantidade = 5},
                        new PedidoItem { PedidoItemId = "PedidoItem2", PedidoId = "Pedido1", Produto = RetornaProdutoPorId(db, "Produto2"), Quantidade = 4}
                    }
                };

                var p2 = new Pedido
                {
                    PedidoId = "Pedido1",
                    Numero = 2,
                    Cliente = c2,
                    Itens = new List<PedidoItem>
                    {
                        new PedidoItem { PedidoItemId = "PedidoItem3", PedidoId = "Pedido2", Produto = RetornaProdutoPorId(db, "Produto3"), Quantidade = 5},
                        new PedidoItem { PedidoItemId = "PedidoItem4", PedidoId = "Pedido2", Produto = RetornaProdutoPorId(db, "Produto4"), Quantidade = 4},
                        new PedidoItem { PedidoItemId = "PedidoItem5", PedidoId = "Pedido2", Produto = RetornaProdutoPorId(db, "Produto5"), Quantidade = 4}
                    }
                };
                

                db.Pedidos.AddRange(p1, p2); // mesmo adicionando só pedidos, a tabela itens também é preenchida
                db.SaveChanges();
            }
        }

        static Produto RetornaProdutoPorId(PedidosContext db, string id)
        {
            return db.Produtos.Where(x => x.ProdutoId == id).FirstOrDefault();
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
