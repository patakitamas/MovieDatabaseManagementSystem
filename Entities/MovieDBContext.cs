using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    internal class MovieDBContext : DbContext
    {
        public MovieDBContext(DbContextOptions<MovieDBContext> options) : base(options) { }

        public DbSet<MovieDB> Movies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieDB>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Director).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Genre).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Rating).HasColumnType("decimal(10,2)");
                });
        }
    }
    
}
