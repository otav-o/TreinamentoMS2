using AtividadeFinal_Modulo2_Otavio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtividadeFinal_Modulo2_Otavio.DAL
{
    class EnderecoDAO
    {
        /// <summary>
        /// Retorna os endereços de um aluno
        /// </summary>
        /// <param name="aluno"></param>
        /// <returns></returns>
        public List<Endereco> RetornarPorAluno(Aluno aluno)
        {
            List<Endereco >endereco;
            using (var context = new ApplicationContext())
            {
                endereco = context.Enderecos.Where(x => x.Aluno == aluno).ToList();
            }
            return endereco;
        }
    }
}
