using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtividadeFinal_Modulo2_Otavio.DAL
{
    class DAOGenerica<T>
    {
        public void Inserir(T obj)
        {
            using (var context = new ApplicationContext())
            {
                context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Alterar(T obj)
        {
            using (var context = new ApplicationContext())
            {
                context.Update(obj);
                context.SaveChanges();
            }
        }

        public void Excluir(T obj)
        {
            using (var context = new ApplicationContext())
            {
                context.Remove(obj);
                context.SaveChanges();
            }
        }
    }
}
