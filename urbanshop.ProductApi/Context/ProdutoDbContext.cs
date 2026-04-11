using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using urbanshop.ProductApi.Models;

using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace urbanshop.ProductApi.Context
{
    public class ProdutoDbContext : DbContext
    {
        public ProdutoDbContext(DbContextOptions<ProdutoDbContext> options) : base(options)
        {
            
        }
        public DbSet<Categoria> Categorias {get; set;}
        public DbSet<Produto> Produtos {get; set;}
    }
}