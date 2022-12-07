using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework
{
    public class DataBaseContext:DbContext
    {

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasMany(c => c.Comments)
                .WithOne(u => u.Author)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Product)
                .IsRequired();
        }
    }
}