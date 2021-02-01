using AtividadeFinal_Modulo2_Otavio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtividadeFinal_Modulo2_Otavio.DAL
{
    class AlunoDAO
    {
        public Aluno RetornarPorMatricula(int matricula)
        {
            Aluno aluno;
            using (var context = new ApplicationContext())
            {
                aluno = context.Alunos.Where(x => x.Matricula == matricula).FirstOrDefault();
            }
            return aluno;
        }

        public List<Aluno> RetornarPorParteNome(string parteNome)
        {
            List<Aluno> aluno;
            using (var context = new ApplicationContext())
            {
                aluno = context.Alunos.Where(x => x.Nome.Contains(parteNome)).ToList();
            }
            return aluno;
        }

    }
}
