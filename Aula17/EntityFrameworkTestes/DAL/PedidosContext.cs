﻿using EntityFrameworkTestes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkTestes.DAL
{
    class PedidosContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; } 
        // DbSet é uma coleção especial do Entity em que se consegue passar o tipo da entidade que se vai mapear
        // consegue fazer consultas e adicionar dados de forma simples

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(@"Integrated Security=SSPI;Trusted_Connection=true;Persist Security Info=False;Initial Catalog=TestesEntityManager;Data Source=OTAVIO-VIVOBOOK\SQLEXPRESS");
    }
}