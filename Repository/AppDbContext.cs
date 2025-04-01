using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace App.Repositories
{
    public class AppDbContext(DbContextOptions options) : DbContext(options) // bu yapıya primary constructor denir.
    {
        public DbSet<Product> Products { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Configurasyon işlemleri
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // IEntityTypeConfiguration'ı implemente eden her class'ı ekle
            base.OnModelCreating(modelBuilder);
        }
    }
}
