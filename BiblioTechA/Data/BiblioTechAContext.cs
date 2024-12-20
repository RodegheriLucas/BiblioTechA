﻿using BiblioTechA.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BiblioTechA.Data
{
    public class BiblioTechAContext : DbContext
    {
        public BiblioTechAContext(DbContextOptions<BiblioTechAContext> options) : base(options)
        {
        }
        public DbSet<Leitor> Leitores { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<LivroPedido> LivroPedidos { get; set; } 
        public DbSet<BiblioTechA.Models.Biblioteca> Biblioteca { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LivroPedido>()
                .HasKey(lp => new { lp.LivroId, lp.PedidoId });
        }
    }
}
