using EntityFrameworkEDAO.Models;
using Microsoft.EntityFrameworkCore;
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
                // Adiciona o objeto Pedido no contexto e todos os objetos do contexto como unchanged
                contexto.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Added; // aplica o estado somente ao objeto

                // Altera para Added todos os itens de pedido monitorados
                foreach (var item in obj.Itens)
                    contexto.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Added;

                contexto.SaveChanges();
                // talvez possa ser feito de outro jeito, segundo o Camillo.
            }
        }
        public void Alterar(Pedido obj)
        {
            using (var contexto = new PedidosContext())
            {
                // Retorna todos os itens gravados na base em uma lista
                var itensAnteriores = contexto.PedidoItens.Where(x => x.PedidoId == obj.PedidoId).ToList();

                // Para cada item que quero gravar
                foreach (var item in obj.Itens)
                {
                    // Pegar o item se ele existir na base
                    var itemMonitorado = itensAnteriores.Where(x => x.PedidoItemId == item.PedidoItemId).FirstOrDefault();

                    // Se o item existe na base
                    if (itemMonitorado != null)
                    {
                        // Removo a entidade do monitoramento
                        contexto.Entry(itemMonitorado).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                        // Adiciono o item identificando-o como modificado
                        contexto.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        // retira um e adiciona outro

                        // Remove o item da lista de itens já gravados
                        itensAnteriores.Remove(itemMonitorado); // remove cada item que encontra
                    }
                    else
                    {
                        // Adiciono o item que nunca foi gravado com o State Added
                        contexto.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    }
                }

                // Se sobrou item nessa lista, o mesmo foi deletado pelo usuário (Deleted)
                foreach (var item in itensAnteriores)
                {
                    contexto.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                }

                // Por fim, adicionar a entidade Pedido
                contexto.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }
        public void Excluir(Pedido obj)
        {
            using (var contexto = new PedidosContext())
            {
                // Recupera todos os itens gravados na base
                var itensAnteriores = contexto.PedidoItens.Where(x => x.PedidoId == obj.PedidoId).ToList();

                // Altera o state de cada item para deleted
                foreach (var item in itensAnteriores)
                    contexto.Entry(item).State = EntityState.Deleted;

                // Altera o state do pedido para deleted
                contexto.Entry(obj).State = EntityState.Deleted;

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
