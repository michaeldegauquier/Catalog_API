using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Catalog.API.Models;

namespace Catalog.API.Infrastructure
{
    public class CatalogContext: DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options) { }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductGender> ProductGender { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductGender>().HasKey(o => new { o.GenderId, o.ProductId });
        }
    }
}