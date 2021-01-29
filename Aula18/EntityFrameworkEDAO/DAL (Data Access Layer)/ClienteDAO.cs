using EntityFrameworkEDAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameworkEDAO.DAL__Data_Access_Layer_
{
    class ClienteDAO
    {
        public void Inserir(Cliente obj)
        {
            using (var contexto = new PedidosContext())
            {
                contexto.Clientes.Add(obj);
                contexto.SaveChanges();
            }
        }
        public void Alterar(Cliente obj)
        {
            using (var contexto = new PedidosContext())
            {
                contexto.Update(obj);
                contexto.SaveChanges();
            }
        }
        public void Excluir(Cliente obj)
        {
            using (var contexto = new PedidosContext())
            {
                contexto.Remove(obj);
                contexto.SaveChanges();
            }
        }
        public IList<Cliente> RetornarTodos()
        {
            List<Cliente> retorno;
            using (var contexto = new PedidosContext())
            {
                retorno = contexto.Clientes.ToList();
            }
            return retorno;
        }
        public Cliente RetornarPorId(string id)
        {
            Cliente produto;
            using (var contexto = new PedidosContext())
            {
                produto = contexto.Clientes.Where(x => x.ClienteId == id).FirstOrDefault();
            }
            return produto;
        }
    }
}
