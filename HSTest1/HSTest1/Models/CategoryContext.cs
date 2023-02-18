using HCTest1.Models;
using Microsoft.EntityFrameworkCore;

namespace HCTest.Models
{
    public class CategoryContext : DbContext
    {
        public CategoryContext(DbContextOptions<CategoryContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryAttribute> CategoryAttributes { get; set; }
        public DbSet<Product> Products { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Attributes)
                .WithOne(a => a.Category)
                .HasForeignKey(a => a.CategoryId);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
