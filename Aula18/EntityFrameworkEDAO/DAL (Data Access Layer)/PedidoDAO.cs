using EntityFrameworkEDAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameworkEDAO.DAL__Data_Access_Layer_
{
    class PedidoDAO
    {
        public void Inserir(Pedido obj)
        {
            using (var contexto = new PedidosContext())
            {
                contexto.Pedidos.Add(obj);
                contexto.SaveChanges();
            }
        }
        public void Alterar(Pedido obj)
        {
            using (var contexto = new PedidosContext())
            {
                contexto.Update(obj);
                contexto.SaveChanges();
            }
        }
        public void Excluir(Pedido obj)
        {
            using (var contexto = new PedidosContext())
            {
                contexto.Remove(obj);
                contexto.SaveChanges();
            }
        }
        public IList<Pedido> RetornarTodos()
        {
            List<Pedido> retorno;
            using (var contexto = new PedidosContext())
            {
                retorno = contexto.Pedidos.ToList();
            }
            return retorno;
        }
        public Pedido RetornarPorId(string id)
        {
            Pedido produto;
            using (var contexto = new PedidosContext())
            {
                produto = contexto.Pedidos.Where(x => x.PedidoId == id).FirstOrDefault();
            }
            return produto;
        }

        /// <summary>
        /// Carrega o cliente e os itens de um pedido
        /// </summary>
        /// <param name="pedido"></param>
        public void CargaTardia(Pedido pedido)
        {
            using (var contexto = new PedidosContext())
            {
                pedido.Cliente = contexto.Clientes.Where(x => x.ClienteId == pedido.ClienteId).FirstOrDefault();
                pedido.Itens = contexto.PedidoItens.Where(x => x.PedidoId == pedido.PedidoId).ToList();

                foreach (var item in pedido.Itens)
                {
                    item.Produto = contexto.Produtos.Where(x => x.ProdutoId == item.ProdutoId).FirstOrDefault();
                    // o entity tem um jeito melhor
                }
            }
        }
        // só faça o join se for necessário, é custoso para o banco
    }
}
