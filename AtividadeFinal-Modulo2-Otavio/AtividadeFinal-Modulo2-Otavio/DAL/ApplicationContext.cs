using AtividadeFinal_Modulo2_Otavio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtividadeFinal_Modulo2_Otavio.DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Trusted_Connection=true;Persist Security Info=False;Initial Catalog=CadastroDeAlunos;Data Source=localhost\SQLEXPRESS");
        }
    }
}
