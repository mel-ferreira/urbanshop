using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using urbanshop.ProductApi.Models;

using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace urbanshop.ProductApi.Context;
public class ProdutoDbContext : DbContext
{
    public ProdutoDbContext(DbContextOptions<ProdutoDbContext> options) : base(options)
    {
        
    }
    public DbSet<Categoria> Categorias {get; set;}
    public DbSet<Produto> Produtos {get; set;}

    //Fluent API
    protected override void OnModelCreating(ModelBuilder mb)
    {

        base.OnModelCreating(mb);
        
        //Categoria
        mb.Entity<Categoria>().HasKey(cp => cp.CategoriaId);

        mb.Entity<Categoria>().
            Property(cp => cp.Nome).
                HasMaxLength(100).
                    IsRequired();
        //Produto
        mb.Entity<Produto>().HasKey(cp => cp.ProdutoId);

        mb.Entity<Produto>().
            Property(cp => cp.Nome).
                HasMaxLength(100).
                    IsRequired();
        mb.Entity<Produto>().
            Property(cp => cp.Descricao).
                HasMaxLength(255).
                    IsRequired();
        mb.Entity<Produto>().
            Property(cp => cp.ImagemURL).
                HasMaxLength(255).
                    IsRequired();
        mb.Entity<Produto>().
            Property(cp => cp.Preco).
                HasPrecision(12,2).
                    IsRequired();
        //Relacionamento
        mb.Entity<Categoria>()
            .HasMany(x => x.Produtos)
            .WithOne(x => x.Categoria)
            .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        
        // Seeding

        mb.Entity<Categoria>().HasData(
            new Categoria
            {
                CategoriaId = 1,
                Nome = "Eletrônicos",
            },
            new Categoria
            {
                CategoriaId = 2,
                Nome = "Acessórios",
            }
        );
    } 
}