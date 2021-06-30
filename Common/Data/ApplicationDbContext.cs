using Common.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        const string ConnectionString = "Server=.;Database=ECommerce;Trusted_Connection=True;MultipleActiveResultSets=true;";
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Size> Size { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<Discount> Discount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // use multiple database
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder);
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }
    }
}
