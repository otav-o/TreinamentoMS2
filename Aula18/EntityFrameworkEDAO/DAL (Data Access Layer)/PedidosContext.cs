using EntityFrameworkEDAO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkEDAO.DAL__Data_Access_Layer_
{
    class PedidosContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PedidoItem> PedidoItens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Trusted_Connection=true;Persist Security Info=False;Initial Catalog=TestesEntityManager;Data Source=localhost\SQLEXPRESS");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .Property(x => x.Descricao) // interessante se mudar o nome
                .IsRequired(); // significa que a descrição é required

            modelBuilder.Entity<Cliente>()
                .Property(x => x.Email)
                .HasColumnName("Endereco_Eletronico")
                .HasColumnType("varchar")
                .HasMaxLength(10); // aplica e passa o objeto para frente, já com as modificações.
        }
    }
}
