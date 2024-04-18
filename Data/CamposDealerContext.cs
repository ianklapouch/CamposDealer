using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CamposDealer.Models;

namespace CamposDealer.Data
{
    public class CamposDealerContext(DbContextOptions<CamposDealerContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Venda>()
                .HasOne(v => v.Cliente)
                .WithMany()
                .HasForeignKey(v => v.IdCliente);

            modelBuilder.Entity<Venda>()
                .HasOne(v => v.Produto)
                .WithMany()
                .HasForeignKey(v => v.IdProduto);
        }

        public DbSet<Cliente> Cliente { get; set; } = default!;
        public DbSet<Produto> Produto { get; set; } = default!;
        public DbSet<Venda> Venda { get; set; } = default!;
    }
}
