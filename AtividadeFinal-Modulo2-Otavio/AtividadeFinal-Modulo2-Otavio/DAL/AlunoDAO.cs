using AtividadeFinal_Modulo2_Otavio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtividadeFinal_Modulo2_Otavio.DAL
{
    class AlunoDAO
    {
        public void Inserir(Aluno obj)
        {
            using (var context = new ApplicationContext())
            {
                context.Alunos.Add(obj);
                context.SaveChanges();
            }
        }

        public void Alterar(Aluno obj)
        {
            using (var context = new ApplicationContext())
            {
                context.Update(obj);
                context.SaveChanges();
            }
        }

        public void Excluir(Aluno obj)
        {
            using (var context = new ApplicationContext())
            {
                context.Remove(obj);
                context.SaveChanges();
            }
        }

        public Aluno RetornarPorMatricula(int matricula)
        {
            Aluno aluno;
            using (var context = new ApplicationContext())
            {
                aluno = context.Alunos.Where(x => x.Matricula == matricula).FirstOrDefault();
            }
            return aluno;
        }
    }
}
